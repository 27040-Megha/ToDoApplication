using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApplication.Model;
using ToDoApplication.Service;

namespace ToDoApplication.Repository
{
    /// <summary>
    /// Storage and CRUD Operations for task repo
    /// </summary>
    public class TaskRepo
    {
        /// <summary>
        /// Add tasks to repo
        /// </summary>
        /// <param name="toDoTasks"></param>
        public void AddToDoTasks(Tasks toDoTasks)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            listOfTasks.Add(toDoTasks);
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }

        /// <summary>
        /// Fetch and returns all tasks from Repo
        /// </summary>
        /// <returns></returns>
        public List<Tasks> ReturnAllToDoTasks()
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            return listOfTasks;
        }

        /// <summary>
        /// Removes a daily task from Repo
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDailyTask(Guid taskId)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            var task = listOfTasks.FirstOrDefault(t => t.TaskId == taskId);
            listOfTasks.Remove(task);
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }

        /// <summary>
        /// Modify Daily Task in Repo
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="tasksToUpdate"></param>
        public void ModifyDailyTask(Guid taskId, Tasks newTask)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            var oldTask = listOfTasks.FirstOrDefault(task => task.TaskId == taskId);
            oldTask.TaskHeading = newTask.TaskHeading;
            oldTask.Description = newTask.Description;
            oldTask.TargetDate = newTask.TargetDate;
            oldTask.TaskRecurranceType = newTask.TaskRecurranceType;
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }

        /// <summary>
        /// Mark the task as complete in repo
        /// </summary>
        /// <param name="taskId"></param>
        public void MarkAsComplete(Guid taskId)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            var task = listOfTasks.FirstOrDefault(t => t.TaskId == taskId);
            task.IsCompleted = true;
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }
    }
}
