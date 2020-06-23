using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApi.Models;
using DemoApi.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DataContext db;
        public UserController(DataContext db)
        {
           this.db = db;
        }


        [HttpGet("Users")]
        public async Task<List<User>> GetList()
        {
            var result = await this.db.Users.Where(k=>k.IsDeleted == false).ToListAsync();
            return result;
        }

        [HttpGet("Allusers")]
        public async Task<List<User>> GetAllList()
        {
            var result = await this.db.Users.Where(k => k.Id != null).ToListAsync();
            return result;
        }

        /*  // GET api/values
          [HttpGet] 
          public ActionResult<List<User>> Get()
          {
              var result = this.db.Users.ToList();
              var user =  this.db.Users.AddAsync(new Models.User
              {
                 Name = "DENEME"
              });
              db.SaveChangesAsync();

              return result;
          }*/

        [HttpGet("deleteUser")]

        public async Task<bool> GetDeletedId(int UserId)
        {
            var user = await this.db.Users.SingleOrDefaultAsync(k=>k.Id==UserId);
            if (user==null) 
            {
                return false;
            }
            user.IsDeleted = true;
            await this.db.SaveChangesAsync();

            return true;
        }
        [HttpPost("AddUser")]
        public async Task<User> AddUser(AddUserRequest request) 
        {
            var user= this.db.Users.Add(new Models.User
            {
                Name= request.name,
                Surname = request.surname
            });
           
            await this.db.SaveChangesAsync();

            return user.Entity;


        }

        [HttpPost("UpdateUser")]
        public async Task<bool> UpdateUser(UpdateUserRequest request)
        {
            var user = await this.db.Users.SingleOrDefaultAsync(k => k.Id == request.id);
            {
                if (user == null)
                {
                    return false;

                }

                user.Id = request.id;
                user.Name = request.name;
                user.Surname = request.surname;
                

            }
            await this.db.SaveChangesAsync();
            return true;
        }

        // GET api/values/5
        /* [HttpGet("{id}")]
         public ActionResult<string> Get(int id)
         {
             return "value";
         }*/


    }
}
