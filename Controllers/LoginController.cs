using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using aureliadotnet.Models;
using aureliadotnet.Interfaces;
using aureliadotnet.Services;

namespace aureliadotnet.Controllers
{
    
    [Route("api/[controller]")]
    public class LoginController : Controller, ILoginController
    {
        private RepositoryService _repoService;

        public LoginController(RepositoryService RepositoryService)
        {
            this._repoService=RepositoryService;
        }
        // [HttpGet("[action]")]
        // public JsonResult Test()
        // {
        //     Dictionary<string, string> testdata = new Dictionary<string, string>();
        //     testdata.Add("test", "test");
        //     return Json(testdata);
        // }

        [HttpPost("[action]")]
        public JsonResult LoginUser([FromBody] Login credentials)
        {
            if (ModelState.IsValid)
            {
                Tuple<User, Dictionary<string, string>> loginAttempt = this._repoService.TryLogin(credentials);
                if(loginAttempt.Item2.Any(x=>x.Value=="Error")){
                    return Json(loginAttempt.Item2);
                }
                else{
                    //success
                    HttpContext.Session.SetInt32("UserId", loginAttempt.Item1.UserId);

                    return Json(loginAttempt.Item2);
                }
            }
            else
            {
                return Json(ModelState);
            }
        }
        
        [HttpPost("[action]")]
        public async Task<JsonResult> RegisterUser([FromBody] Register newUser)
        {
            if (ModelState.IsValid)
            {
                Tuple<User, Dictionary<string, string>> loginAttempt = await this._repoService.TryRegisterUser(newUser);
                if(loginAttempt.Item2.Any(x=>x.Value=="Error")){
                    return Json(loginAttempt.Item2);
                }
                else{
                    //success
                    HttpContext.Session.SetInt32("UserId", loginAttempt.Item1.UserId);

                    return Json(loginAttempt.Item2);
                }
            }
            else
            {
                return Json(ModelState);
            }
        }
    }
}