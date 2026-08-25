using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Repository
{
    /// <summary>
    /// Storage and CRUD Operations for user repo
    /// </summary>
    public class UserRepo
    {
        /// <summary>
        /// Add user inside repo
        /// </summary>
        /// <param name="user"></param>
        public void Createuser(User user)
        {
            var listOfUsers = FileRepoService.ReadFile<User>(FilePath.UserFile);
            listOfUsers.Add(user);
            FileRepoService.WriteFile(listOfUsers, FilePath.UserFile);
        }

        /// <summary>
        /// Fetch All Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> FetchAllUsers()
        {
            var listOfUsers = FileRepoService.ReadFile<User>(FilePath.UserFile);
            return listOfUsers;
        }
    }
}
