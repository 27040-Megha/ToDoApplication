using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ToDoApplication.Helper;
using ToDoApplication.Model;
using ToDoApplication.Model.Enums;
using ToDoApplication.Service;

namespace ToDoApplication.View
{
    public class ConsoleOperations
    {
        private readonly TaskService _taskService;

        public ConsoleOperations(TaskService taskService)
        {
            this._taskService = taskService;
        }

        public void Run()
        {
            var recentTasks = this._taskService.FetchRecentTwoTasks();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Recent two tasks: ");
            if (recentTasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("No DailyTask for you to complete");
            }
            else
            {
                foreach (var task in recentTasks)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Task Heading: {task.TaskHeading}");
                    Console.WriteLine("Task Description: " + task.Description);
                    Console.WriteLine("Target Date: " + task.TargetDate);
                    Console.WriteLine("Task Recurrance: " + task.TaskRecurranceType);
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                }
            }
            Console.ResetColor();

            MenuOptions choice;
            do
            {
                this.DisplayMenu();
                bool isValidChoice = int.TryParse(Console.ReadLine(), out int userChoice);
                if (!isValidChoice)
                {
                    choice = MenuOptions.Invalid;
                }

                choice = (MenuOptions)userChoice;
                switch (choice)
                {
                    case MenuOptions.AddTask:
                        this.AddTask();
                        break;
                    case MenuOptions.DeleteTask:
                        this.DeleteTask();
                        break;
                    case MenuOptions.EditTask:
                        this.EditTask();
                        break;
                    case MenuOptions.MarkTaskAsComplete:
                        this.MarkTaskAsComplete();
                        break;
                    case MenuOptions.ViewToDo:
                        this.ViewToDoTasks();
                        break;
                    case MenuOptions.Exit:
                        Console.WriteLine("Exiting Application..Bye!");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (choice != MenuOptions.Exit);
        }

        private void MarkTaskAsComplete()
        {
            if (this._taskService.FetchaAllToDoTasks().Count == 0)
            {
                Console.WriteLine("No Daily Tasks to mark as complete right now!");
            }

            Console.WriteLine("Enter an index to update a daily task: ");
            int index = this.GetValidIndex();
            if (index == -1)
            {
                return;
            }

            if (!this._taskService.MarkAsComplete(index))
            {
                Console.WriteLine("Index out of range");
            }

            Console.WriteLine("Marked as Done Successfully!");
        }

        private void AddTask()
        {

            var toDoTasks = this.GetTaskDetails();
            if (toDoTasks is null)
            {
                return;
            }

            this._taskService.SaveToDoTasks(toDoTasks);
        }

        private List<Tasks> GetTaskDetails()
        {
            Console.WriteLine("Enter Task Heading: ");
            string taskHeading = Console.ReadLine();
            if (!InputValidation.ValidateString(taskHeading))
            {
                Console.WriteLine("Task Heading should not be null or empty and should contain only characters");
                return null;
            }

            Console.WriteLine("Enter Task Description:");
            string taskDescription = Console.ReadLine();
            if (!InputValidation.ValidateString(taskDescription))
            {
                Console.WriteLine("Task Description should not be null or empty");
                return null;
            }

            Console.WriteLine("Enter Target Date: ");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out DateTime targetDate);
            if (!isValidDate)
            {
                Console.WriteLine("Invalid Date format");
                return null;
            }

            if (!InputValidation.ValidateDate(targetDate))
            {
                Console.WriteLine("Date should not be in the past, It should be from today or in future");
                return null;
            }

            Console.WriteLine("Enter Task Recurrance (1-Daily, 2-Weekly, 3-Monthly): ");
            if (!int.TryParse(Console.ReadLine(), out int taskRecurrance) || !(taskRecurrance >= 1 && taskRecurrance <= 3))
            {
                Console.WriteLine("Enter valid Integer (1 0r 2 or 3)!");
                return null;
            }

            var taskRecurranceType = (TaskRecurrance)taskRecurrance;

            var toDoList = new List<Tasks>();

            toDoList.Add(new Tasks(taskHeading, taskDescription, DateTime.Now, false, taskRecurranceType, Guid.Empty));

            if (taskRecurranceType == TaskRecurrance.Daily)
            {
                for (var date = DateTime.Now.Date; date <= targetDate.Date; date = date.AddDays(1))
                {
                        toDoList.Add(new Tasks(taskHeading, taskDescription, date, false, taskRecurranceType, Guid.Empty));
                }
            }
            else if (taskRecurranceType == TaskRecurrance.Monthly)
            {
                for (var date = DateTime.Now.Date; date <= targetDate.Date; date = date.AddDays(30))
                {
                    toDoList.Add(new Tasks(taskHeading, taskDescription, date, false, taskRecurranceType, Guid.Empty));
                }
            }
            else if (taskRecurranceType == TaskRecurrance.Weekly)
            {
                for (var date = DateTime.Now.Date; date <= targetDate.Date; date = date.AddDays(7))
                {
                    toDoList.Add(new Tasks(taskHeading, taskDescription, date, false, taskRecurranceType, Guid.Empty));
                }
            }

            return toDoList;
        }

        private void DeleteTask()
        {
            if (this._taskService.FetchaAllToDoTasks().Count == 0)
            {
                Console.WriteLine("No Daily Tasks to delete right now!");
            }

            Console.WriteLine("Enter an index to delete a daily task: ");
            int index = this.GetValidIndex();
            if (index == -1)
            {
                return;
            }

            if (!this._taskService.DeleteDailyTask(index))
            {
                Console.WriteLine("No Daily Tasks found with that index, Index out of range!");
                return;
            }

            Console.WriteLine("Daily Tasks Deleted Successfully!");
        }

        private int GetValidIndex()
        {
            var isValidIndex = int.TryParse(Console.ReadLine(), out int index);
            if (!isValidIndex || index < 1)
            {
                Console.WriteLine("Enter valid index greater than 1");
                return -1;
            }

            return index - 1;
        }


        private void EditTask()
        {
            if (this._taskService.FetchaAllToDoTasks().Count == 0)
            {
                Console.WriteLine("No Daily Tasks to update right now!");
            }

            Console.WriteLine("Enter an index to update a daily task: ");
            int index = this.GetValidIndex();
            if (index == -1)
            {
                return;
            }

            var taskToUpdate = this.GetTaskDetails();
            if (taskToUpdate is null)
            {
                return;
            }

            if (!this._taskService.UpdateDailyTask(index, taskToUpdate))
            {
                Console.WriteLine("No Daily Tasks found with that index, Index out of range!");
                return;
            }

            Console.WriteLine("Daily Tasks Updated Successfully!");
        }

        private void ViewToDoTasks()
        {
            var toDoTasks = this._taskService.FetchaAllToDoTasks();
            Console.WriteLine("Your To-Do tasks: ");
            int index = 1;
            foreach(var task in toDoTasks)
            {
                Console.WriteLine($"{index++}. Task Heading: {task.TaskHeading}");
                Console.WriteLine("Task Description: " + task.Description);
                Console.WriteLine("Target Date: " + task.TargetDate);
                Console.WriteLine("Task Recurrance: " + task.TaskRecurranceType);
                Console.WriteLine("Completed Task: " + task.IsCompleted);
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Welcome to To-Do application");
            Console.WriteLine("1. Add To-Do Daily tasks");
            Console.WriteLine("2. Delete To-Do Daily tasks");
            Console.WriteLine("3. Edit To-Do Daily tasks");
            Console.WriteLine("4. Mark To-Do Daily tasks as Complete");
            Console.WriteLine("5. View All To-Do Daily Tasks");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice (1-7): ");
        }
    }
}
