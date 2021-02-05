using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TavSystem.Models;
using TavSystem.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TavSystem.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet]  
       // [HttpGet("{pageNumber}/{pageSize}")]
        public Response<IEnumerable<InventoryInfoDto>> Get([FromQuery] int pageNumber,int pageSize)
        {
            return _inventoryService.GetAll(pageNumber, pageSize);
        }

        [HttpPost]
        public Response Post(DeliveryDto model)
        {
            if (ModelState.IsValid)
            {
                return _inventoryService.Add(model);
            }
            return new Response
            {
                IsSuccess = false,
                Errors = new Error("", "اطلاعات ورودی صحیح نمی باشد"),
            };
        }
    }
}
