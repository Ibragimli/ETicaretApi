using ETicaretApi.API.Configurations;
using ETicaretApi.API.Extensions;
using ETicaretApi.API.Filters;
using ETicaretApi.Application;
using ETicaretApi.Application.Validators.Products;
using ETicaretApi.Infrastructure;
using ETicaretApi.Infrastructure.Filters;
using ETicaretApi.Infrastructure.Service.Storage.Azure;
using ETicaretApi.Infrastructure.Service.Storage.Local;
using ETicaretApi.Persistence;
using ETicaretApi.Persistence.Contexts;
using ETicaretApi.SignalR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddSignalRServices();

builder.Services.AddStorage<LocalStorage>();
//builder.Services.AddStorage<AzureStorage>();
builder.Services.AddStorage(ETicaretApi.Infrastructure.Enums.StorageType.Local);


builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:7151").WithOrigins("http://localhost:7151").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

builder.Services.AddControllers(options => {
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<RolePermissionFilter>();
})
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());
//.ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Log


SqlColumn sqlColumn = new SqlColumn();
sqlColumn.ColumnName = "Username";
sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
sqlColumn.PropertyName = "Username";
sqlColumn.DataLength = 50;
sqlColumn.AllowNull = true;
ColumnOptions columnOpts = new ColumnOptions();
columnOpts.Store.Remove(StandardColumn.Properties);
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

// Logger log = new LoggerConfiguration().CreateLogger();
Logger log = new LoggerConfiguration()
    // ConsoleLog
    .WriteTo.Console()
    // Filelog
    .WriteTo.File("logs/log.txt")
    // DB log
    .WriteTo.MSSqlServer(connectionString: builder.Configuration.GetConnectionString("Default"),

          sinkOptions: new MSSqlServerSinkOptions
          {
              AutoCreateSqlTable = true,
              TableName = "LogEvents",
          }, appConfiguration: null, columnOptions: columnOpts)
    .WriteTo.Seq(builder.Configuration["Seq:ServerURL"])
    .Enrich.FromLogContext()
    .Enrich.With<CustomUserNameColumnWriter>()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
#endregion 
//htttpLog
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});
//htttpLog


//JwtBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer("Admin", opt =>
        opt.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null && expires > DateTime.UtcNow.AddSeconds(-1),
        });
//JwtBearer

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseStaticFiles();
app.UseSerilogRequestLogging();
//htttpLog
app.UseHttpLogging();
//htttpLog

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated == true ? context.User.Identity.Name : "Anonymous";
    LogContext.PushProperty("UserName", username);
    await next();
});

app.MapControllers();
app.MapHubs();

app.Run();
