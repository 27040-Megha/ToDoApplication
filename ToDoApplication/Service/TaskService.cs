using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;
using ToDoApplication.Repository;

namespace ToDoApplication.Service
{
    public class TaskService
    {
        private readonly TaskRepo _taskRepo;

        public TaskService(TaskRepo taskRepo)
        {
            this._taskRepo = taskRepo;
        }

        public void SaveToDoTasks(List<Tasks> toDoTasks)
        {
            this._taskRepo.AddToDoTasks(toDoTasks);
        }

        public List<Tasks> FetchaAllToDoTasks()
        {
            return this._taskRepo.ReturnAllToDoTasks();
        }

        public bool DeleteDailyTask(int index)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }

            this._taskRepo.RemoveDailyTask(index);
            return true;
        }
    }
}
