using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aureliadotnet.Models;

namespace aureliadotnet.Interfaces
{
    public interface ILoginController
    {
        JsonResult LoginUser(Login credentials);
        Task<JsonResult> RegisterUser([FromBody] Register newUser)
    }
    
}