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
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var taskRepo = new TaskRepo();

                var taskService = new TaskService(taskRepo);

                var consoleOperator = new ConsoleOperations(taskService);

                consoleOperator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}
