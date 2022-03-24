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
        public List<Userdata> GetAllUserdata()
        {
            using var db = new NpgsqlConnection(@"Host=localhost;Username=postgres;Password=password;Database=acme");
            var result = db.Query<Userdata>("SELECT * FROM userdata").ToList();
            return result;
        }

        [HttpGet("search")]
        public List<Userdata> SearchUserdata(string q)
        {
 
            using var db = new NpgsqlConnection(@"Host=localhost;Username=postgres;Password=password;Database=acme");

            string Q = @"SELECT * FROM userdata 
                        WHERE id LIKE '%KEYWORD%' OR name LIKE '%KEYWORD%' OR lastname LIKE '%KEYWORD%'";
            string replace = Q.Replace("KEYWORD", q);
            var result = db.Query<Userdata>(replace).ToList();
                
            return result;


        }

        [HttpPost]
        public string CreateUserdata(Userdata data)
        {
            using var db = new NpgsqlConnection(@"Host=localhost;Username=postgres;Password=password;Database=acme");
            db.Query<Userdata>(@"
                INSERT INTO userdata (id, name, lastname)
                VALUES (@id, @name, @lastname)
            ", data);
            return "Create userdata successful";
        }

        [HttpDelete("{id}")]
        public string DeleteUserdata(string id)
        {
            using var db = new NpgsqlConnection(@"Host=localhost;Username=postgres;Password=password;Database=acme");
            db.Query<Userdata>(@"
                DELETE FROM userdata
                WHERE id = @id
            ", new { id = id });
            return "Delete userdata successful";
        }

        
        [HttpPut("{id}")]
        public string EditUserdata(string id, Userdata data)
        {
            using var db = new NpgsqlConnection(@"Host=localhost;Username=postgres;Password=password;Database=acme");
            db.Query<Userdata>(@"
                UPDATE userdata
                SET name = @name, lastname = @lastname
                WHERE id = @id
            ", data);
            return "Edit userdata suscessful";
        }
        
    }
}