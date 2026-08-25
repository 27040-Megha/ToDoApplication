using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public class AuthenticationService
    {
        private readonly UserService _userService;

        public AuthenticationService(UserService userService)
        {
            this._userService = userService;
        }

        public Result Login(string employeeId, string password)
        {
            var userList = this._userService.GetAllUsers();
            var user = userList.FirstOrDefault(u => u.EmployeeId == employeeId);
            if (user == null)
            {
                return new Result(false, "No user with the ID found");
            }

            if (!string.Equals(user.Password, password))
            {
                return new Result(false, "Password doesn't match");
            }

            CurrentUserSession.CurrentUserId = user.UserId;
            return new Result(true, "Login Successfull");
        }
    }
}
