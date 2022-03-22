using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
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
            using var db = new NpgsqlConnection("Host=localhost;Username=postgres;Password=password;Database=acme");
            var result = db.Query<Userdata>("SELECT * FROM userdata").ToList();
            
            // result.Add(new Userdata()
            // {
            //     Id = "0001",
            //     Name = "John",
            //     Lastname = "Doe"
            // });
            //
            // result.Add(new Userdata()
            // {
            //     Id = "0002",
            //     Name = "Jane",
            //     Lastname = "Doe"
            // });
            
            return result;
        }
    }
}