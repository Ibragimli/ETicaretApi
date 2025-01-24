using ETicaretApi.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretApi.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<ProductCreateVM>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ad qeyd edin.")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Adi 5 ile 150 arasi herf girin!");

            RuleFor(p => p.Stock)
             .NotEmpty()
             .NotNull()
                 .WithMessage("Stok sayini girin")
             .Must(s => s >= 0)
                .WithMessage("Stok menfi ola bilmez");

            RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
                .WithMessage("Qiymet  girin")
            .Must(s => s >= 0)
               .WithMessage("Qiymet menfi ola bilmez");
        }
    }
}
