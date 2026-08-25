using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Repository
{
    public class UserRepo
    {
        public void Createuser(User user)
        {
            var listOfUsers = FileRepoService.ReadFile<User>(FilePath.UserFile);
            listOfUsers.Add(user);
            FileRepoService.WriteFile(listOfUsers, FilePath.UserFile);
        }

        public IEnumerable<User> FetchAllUsers()
        {
            var listOfUsers = FileRepoService.ReadFile<User>(FilePath.UserFile);
            return listOfUsers;
        }
    }
}
