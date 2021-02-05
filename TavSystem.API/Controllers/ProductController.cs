using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavSystem.Models;
using TavSystem.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TavSystem.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return _productService.GetAll(); ;
        }

        [HttpPost]
        public Response Post(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                return _productService.Add(model);
            }
            return new Response
            {
                IsSuccess = false,
                Errors = new Error("", "اطلاعات ورودی صحیح نمی باشد"),
            };
        }
    }
}
