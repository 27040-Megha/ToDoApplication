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

        public bool UpdateDailyTask(int index, List<Tasks> tasksToUpdate)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }


            this._taskRepo.ModifyDailyTask(index, tasksToUpdate);
            return true;
        }

        public bool MarkAsComplete(int index)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }

            this._taskRepo.MarkAsComplete(index);
            return true;
        }

        public List<Tasks> FetchRecentTwoTasks()
        {
            var listOfAllTasks = this.FetchaAllToDoTasks().Where(tasks => !tasks.IsCompleted);
            var recentTasks = listOfAllTasks.OrderBy(tasks => tasks.TargetDate).Take(2).ToList();
            return recentTasks;
        }
    }
}
