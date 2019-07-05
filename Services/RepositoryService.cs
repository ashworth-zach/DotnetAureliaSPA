using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using aureliadotnet.Models;
using Microsoft.EntityFrameworkCore;
using aureliadotnet.Interfaces;

namespace aureliadotnet.Services
{
    public class RepositoryService: IRepositoryService
    {
        public Context _context;
        public RepositoryService(Context DbContext)
        {
            this._context=DbContext;
        }
        public Tuple<User,Dictionary<string,string>> TryLogin(Login credentials)
        {
            User userInDb = this._context.users.FirstOrDefault(u => u.email == credentials.email);
            
            Dictionary<string, string> error = new Dictionary<string, string>();
            
            Tuple<User,Dictionary<string,string>> UserAndStatus = new Tuple<User, Dictionary<string, string>>(userInDb, error);
            
            
            if (userInDb == null)
            {
                UserAndStatus.Item2.Add("Message", "Error");
                UserAndStatus.Item2.Add("email", "Invalid email");
                return UserAndStatus;
            }
            var hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(credentials, userInDb.password, credentials.password);

            if (result == 0)
            {
                UserAndStatus.Item2.Add("Message", "Error");
                UserAndStatus.Item2.Add("password", "Invalid password");
                return UserAndStatus;
            }

            Dictionary<string, string> success = new Dictionary<string, string>();
            success.Add("Message", "Success");
            return new Tuple<User, Dictionary<string, string>>(userInDb, success);;
        }
        public async Task<Tuple<User,Dictionary<string,string>>> TryRegisterUser(Register newUser)
        {
            if (this._context.users.Any(u => u.email == newUser.email))
            {
                Dictionary<string, string> error = new Dictionary<string, string>();
                error.Add("Message", "Error");
                error.Add("email", "Email is already in use");
                Tuple<User,Dictionary<string,string>> failedLogin = new Tuple<User, Dictionary<string, string>>(null, error);
                return failedLogin;
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
            this._context.users.Add(usertoAdd);
            await this._context.SaveChangesAsync();
            User User = this._context.users.FirstOrDefault(x => x.email == newUser.email);

            Dictionary<string, string> success = new Dictionary<string, string>();
            success.Add("Message", "Success");
            Tuple<User,Dictionary<string,string>> UserAndStatus = new Tuple<User, Dictionary<string, string>>(User, success);
            return UserAndStatus;
        }
    }
}