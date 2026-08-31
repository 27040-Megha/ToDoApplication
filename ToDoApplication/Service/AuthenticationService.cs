using System.Linq;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    /// <summary>
    /// Contains Login method
    /// </summary>
    public class AuthenticationService
    {
        private readonly UserService _userService;

        public AuthenticationService(UserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
