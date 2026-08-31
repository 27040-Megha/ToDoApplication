using System;

namespace ToDoApplication.Model
{
    /// <summary>
    /// Model for User
    /// </summary>
    public class User
    {
        public User(Guid userId, string employeeId, string userName, string password)
        {
            this.UserId = userId;
            this.EmployeeId = employeeId;
            this.UserName = userName;
            this.Password = password;
        }

        public Guid UserId { get; set; }

        public string EmployeeId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
