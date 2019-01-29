using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using aureliadotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace aureliadotnet.Controllers
{
    
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private Context dbContext;

        public LoginController(Context context)
        {
            dbContext = context;
        }
        // [HttpGet("[action]")]
        // public JsonResult Test()
        // {
        //     Dictionary<string, string> testdata = new Dictionary<string, string>();
        //     testdata.Add("test", "test");
        //     return Json(testdata);
        // }

        [HttpPost("[action]")]
        public JsonResult Login([FromBody] Login credentials)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.users.FirstOrDefault(u => u.email == credentials.email);
                Dictionary<string, string> error = new Dictionary<string, string>();
                if (userInDb == null)
                {
                    error.Add("Message", "Error");
                    error.Add("email", "Invalid email");
                    return Json(error);
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(credentials, userInDb.password, credentials.password);

                if (result == 0)
                {
                    error.Add("Message", "Error");
                    error.Add("password", "Invalid password");
                    return Json(error);
                }

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                Dictionary<string, string> success = new Dictionary<string, string>();
                success.Add("Message", "Success");
                return Json(success);
            }
            else
            {
                return Json(ModelState);
            }
        }
        
        [HttpPost("[action]")]
        public JsonResult RegisterUser([FromBody] Register newUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(u => u.email == newUser.email))
                {
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("email", "Email is already in use");
                    return Json(error);
                }
                PasswordHasher<Register> Hasher = new PasswordHasher<Register>();
                newUser.password = Hasher.HashPassword(newUser, newUser.password);
                User usertoAdd = new User
                {
                    firstname = newUser.firstname,
                    lastname = newUser.lastname,
                    password = newUser.password,
                    email = newUser.email,
                };
                dbContext.users.Add(usertoAdd);
                dbContext.SaveChanges();
                User User = dbContext.users.FirstOrDefault(x => x.email == newUser.email);
                HttpContext.Session.SetInt32("UserId", User.UserId);

                Dictionary<string, string> success = new Dictionary<string, string>();
                success.Add("Message", "Success");
                return Json(success);
            }
            else
            {
                return Json(ModelState);
            }
        }
    }
}