using System.Threading.Tasks;
using aureliadotnet.Models;
using System;
using System.Collections.Generic;

namespace aureliadotnet.Interfaces
{
    public interface IRepositoryService
    {
        Tuple<User,Dictionary<string,string>> TryLogin(Login credentials);
        Task<Tuple<User,Dictionary<string,string>>> TryRegisterUser(Register newUser);
    }
    
}