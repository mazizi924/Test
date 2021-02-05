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
    public class InvitemController : ControllerBase
    {
        private readonly IInvItemService _invItemService;

        public InvitemController(IInvItemService invItemService)
        {
            _invItemService = invItemService;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public Response Post(InvitemInfoDto model)
        {
            if (ModelState.IsValid)
            {
                return _invItemService.Add(model);
            }
            return new Response
            {
                IsSuccess = false,
                Errors = new Error("", "اطلاعات ورودی صحیح نمی باشد"),
            };
        }
    }
}
