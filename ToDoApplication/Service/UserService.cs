using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;
using ToDoApplication.Repository;

namespace ToDoApplication.Service
{
    /// <summary>
    /// Contains Business Logic for User Service
    /// </summary>
    public class UserService
    {
        private readonly UserRepo _userRepo;

        /// <summary>
        /// Constructor for User Service
        /// </summary>
        /// <param name="userRepo"></param>
        public UserService(UserRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        /// <summary>
        /// Business Logic to create only unique user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Adduser(User user)
        {
            var listOfUsers = this._userRepo.FetchAllUsers().Where(employee => employee.EmployeeId == user.EmployeeId).ToList();
            if (listOfUsers.Count > 0)
            {
                return false;
            }

            this._userRepo.Createuser(user);
            return true;
        }

        /// <summary>
        /// Fetch all users from userRepo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            return this._userRepo.FetchAllUsers();
        }
    }
}
