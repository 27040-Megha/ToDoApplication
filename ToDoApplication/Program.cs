using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Repository;
using ToDoApplication.Service;
using ToDoApplication.View;

namespace ToDoApplication
{
    /// <summary>
    /// Entry Point of Application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var taskRepo = new TaskRepo();

                var taskService = new TaskService(taskRepo);

                var userRepo = new UserRepo();

                var userService = new UserService(userRepo);

                var authService = new AuthenticationService(userService);

                var consoleOperator = new ConsoleOperations(taskService, userService, authService);

                consoleOperator.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}
