using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Repositories.Product;
using ETicaretMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace ETicaretMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public HomeController(IStorageService storageService,IConfiguration  configuration)
        {
            _storageService = storageService;
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            ErrorViewModel errorViewModel = new()
            {
                Images =  _storageService.GetFiles("files"),
                //Products = _productReadRepository.GetAll().ToList(),
                Path = _configuration.GetConnectionString("StoragePath")
            };
            return View(errorViewModel);
        }


    }
}