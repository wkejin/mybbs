using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.Models;
using MyBBSWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public bool Login(string username, string password)
        {
            return UserService.CheckLogin(username, password);
        }

        [HttpGet]
        public bool CheckUserName(string username)
        {
            return UserService.CheckUserName(username);
        }

        [HttpPost]
        public bool CreateUser(User user)
        {
            return UserService.CreateUser(user);
        }

        [HttpGet]
        public User GetUser(int id)
        {
            return UserService.GetUser(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return UserService.GetUsers();
        }
    }
}
