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
            using var db = new NpgsqlConnection(@"Host=172.16.0.49;Username=postgres;Password=p@ssw0rd;Database=milk_practice");
            var result = db.Query<Userdata>("SELECT * FROM userdata").ToList();
            return result;
        }
        [HttpPost]
        public string Post()
        {
            return "POST";
        }
    }
}