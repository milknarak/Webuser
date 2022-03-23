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
            using var db = new NpgsqlConnection(@"Host=172.16.0.49;Username=postgres;Password=p@ssw0rd;Database=milk_practice");
            var result = db.Query<Userdata>("SELECT * FROM userdata").ToList();
            return result;
        }

        [HttpPost]
        public string CreateUserdata(Userdata data)
        {
            using var db = new NpgsqlConnection(@"Host=172.16.0.49;Username=postgres;Password=p@ssw0rd;Database=milk_practice");
            db.Query<Userdata>(@"
                INSERT INTO userdata (id, name, lastname)
                VALUES (@id, @name, @lastname)
            ", data);
            return "Create userdata successful";
        }

        [HttpDelete("{id}")]
        public string DeleteUserdata(string id)
        {
            using var db = new NpgsqlConnection(@"Host=172.16.0.49;Username=postgres;Password=p@ssw0rd;Database=milk_practice");
            db.Query<Userdata>(@"
                DELETE FROM userdata
                WHERE id = @id
            ", new { id = id });
            return "Delete userdata successful";
        }

        [HttpPut]
        public string EditUserdata(string id)
        {
            using var db = new NpgsqlConnection(@"Host=172.16.0.49;Username=postgres;Password=p@ssw0rd;Database=milk_practice");
            db.Query<Userdata>(@"
            UPDATE username
            SET id = @id, name = @name, lastname = @lastname
            WHERE id = @id
            "), id);
            return "Edit userdata suscessful";
        }
    }
}