using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;

namespace TavSystem.API.Controllers
{
    [Route("[controller]")] 
    public class HomeController : ControllerBase
    {
        private readonly ITest repository;

        public HomeController(ITest repository)
        {
            this.repository = repository;
        } 
        public void Get()
        {
            repository.AddTestData(); 
        }
         
    }
}
