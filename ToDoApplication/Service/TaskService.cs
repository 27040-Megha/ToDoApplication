using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApplication.Model;
using ToDoApplication.Model.Enums;
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
        public void SaveToDoTasks(Tasks toDoTasks)
        {
            this._taskRepo.AddToDoTasks(toDoTasks);
        }

        /// <summary>
        /// Fetch All To-Do tasks
        /// </summary>
        /// <returns></returns>
        public List<Tasks> FetchaAllToDoTasks()
        {
            return this._taskRepo.ReturnAllToDoTasks().Where(task => task.UserId == CurrentUserSession.CurrentUserId).ToList();
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

            var tasks = this.FetchaAllToDoTasks();
            this._taskRepo.RemoveDailyTask(tasks[index].TaskId);
            return true;
        }

        /// <summary>
        /// Update DailyTask
        /// </summary>
        /// <param name="index"></param>
        /// <param name="tasksToUpdate"></param>
        /// <returns></returns>
        public bool UpdateDailyTask(int index, Tasks tasksToUpdate)
        {
            if (index >= this.FetchaAllToDoTasks().Count)
            {
                return false;
            }

            var oldTask = this.FetchaAllToDoTasks()[index];
            this._taskRepo.ModifyDailyTask(oldTask.TaskId, tasksToUpdate);
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

            var allTasks = this.FetchaAllToDoTasks();
            this._taskRepo.MarkAsComplete(allTasks[index].TaskId);
            this.CheckAndAddRecurrentTask(allTasks[index]);
            return true;
        }

        private void CheckAndAddRecurrentTask(Tasks completedTask)
        {
            var task = this.FetchaAllToDoTasks().FirstOrDefault(t => t.TaskId == completedTask.TaskId);
            if (task.TaskRecurranceType == TaskRecurrance.None)
            {
                return;
            }

            switch (task.TaskRecurranceType)
            {
                case TaskRecurrance.Daily:
                    this.SaveToDoTasks(new Tasks(Guid.NewGuid(), completedTask.TaskHeading, completedTask.Description, completedTask.TargetDate.Date.AddDays(1), completedTask.IsCompleted, completedTask.TaskRecurranceType, CurrentUserSession.CurrentUserId));
                    break;
                case TaskRecurrance.Monthly:
                    this.SaveToDoTasks(new Tasks(Guid.NewGuid(), completedTask.TaskHeading, completedTask.Description, completedTask.TargetDate.Date.AddDays(30), completedTask.IsCompleted, completedTask.TaskRecurranceType, CurrentUserSession.CurrentUserId));
                    break;
                case TaskRecurrance.Weekly:
                    this.SaveToDoTasks(new Tasks(Guid.NewGuid(), completedTask.TaskHeading, completedTask.Description, completedTask.TargetDate.Date.AddDays(7), completedTask.IsCompleted, completedTask.TaskRecurranceType, CurrentUserSession.CurrentUserId));
                    break;
            }
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

        public List<Tasks> CalendarWiseSortedDailyTask()
        {
            var listOfAllTasks = this.FetchaAllToDoTasks().OrderBy(tasks => tasks.TargetDate).Where(tasks => !tasks.IsCompleted);
            return listOfAllTasks.ToList();
        }
    }
}
