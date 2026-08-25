using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;
using ToDoApplication.Repository;

namespace ToDoApplication.Service
{
    public class UserService
    {
        private readonly UserRepo _userRepo;

        public UserService(UserRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        public bool Adduser(User user)
        {
            //var listOfUsers = this._userRepo.FetchAllUsers().Where(employee => employee.EmployeeId == user.EmployeeId).ToList();
            //if (listOfUsers.Count > 0)
            //{
            //    return false;
            //}

            this._userRepo.Createuser(user);
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._userRepo.FetchAllUsers();
        }
    }
}
