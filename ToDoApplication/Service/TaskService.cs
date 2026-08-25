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
    /// Contains Business Logic for Task Service
    /// </summary>
    public class TaskService
    {
        private readonly TaskRepo _taskRepo;

        public TaskService(TaskRepo taskRepo)
        {
            this._taskRepo = taskRepo;
        }

        /// <summary>
        /// Save To Do Tasks to repo
        /// </summary>
        /// <param name="toDoTasks"></param>
        public void SaveToDoTasks(List<Tasks> toDoTasks)
        {
            this._taskRepo.AddToDoTasks(toDoTasks);
        }

        /// <summary>
        /// Fetch All To-Do tasks
        /// </summary>
        /// <returns></returns>
        public List<Tasks> FetchaAllToDoTasks()
        {
            return this._taskRepo.ReturnAllToDoTasks();
        }

        /// <summary>
        /// Delete a Daily Task
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteDailyTask(int index)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }

            this._taskRepo.RemoveDailyTask(index);
            return true;
        }

        /// <summary>
        /// Update DailyTask
        /// </summary>
        /// <param name="index"></param>
        /// <param name="tasksToUpdate"></param>
        /// <returns></returns>
        public bool UpdateDailyTask(int index, List<Tasks> tasksToUpdate)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }


            this._taskRepo.ModifyDailyTask(index, tasksToUpdate);
            return true;
        }

        /// <summary>
        /// Mark a task as completed
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool MarkAsComplete(int index)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }

            this._taskRepo.MarkAsComplete(index);
            return true;
        }

        /// <summary>
        /// Returns only recent two tasks that has not yet been marked as complete
        /// </summary>
        /// <returns></returns>
        public List<Tasks> FetchRecentTwoTasks()
        {
            var listOfAllTasks = this.FetchaAllToDoTasks().Where(tasks => !tasks.IsCompleted);
            var recentTasks = listOfAllTasks.OrderBy(tasks => tasks.TargetDate).Take(2).ToList();
            return recentTasks;
        }
    }
}
