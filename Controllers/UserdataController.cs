using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUser.Models;

namespace WebUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserdataController : ControllerBase
    {
        [HttpGet]
        public List<Userdata> Get()
        {
            var result = new List<Userdata>();
            
            result.Add(new Userdata()
            {
                Id = "0001",
                Name = "John",
                Lastname = "Doe"
            });
            
            return result;
        }
    }
}