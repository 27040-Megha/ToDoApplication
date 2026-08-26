using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
        public void AddToDoTasks(List<Tasks> toDoTasks)
        {
            foreach (var tasks in toDoTasks)
            {
                var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
                listOfTasks.Add(tasks);
                FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
            }
        }
        
        /// <summary>
        /// Fetch and returns all tasks from Repo
        /// </summary>
        /// <returns></returns>
        public List<Tasks> ReturnAllToDoTasks()
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            return listOfTasks.Where(task => task.UserId == CurrentUserSession.CurrentUserId).ToList();
        }

        /// <summary>
        /// Removes a daily task from Repo
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDailyTask(int index)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            var listOfCurrentUserTasks = listOfTasks.Where(t => t.UserId == CurrentUserSession.CurrentUserId).ToList();
            var task = listOfCurrentUserTasks[index];
            listOfTasks.Remove(task);
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }

        /// <summary>
        /// Modify Daily Task in Repo
        /// </summary>
        /// <param name="index"></param>
        /// <param name="tasksToUpdate"></param>
        public void ModifyDailyTask(int index, List<Tasks> tasksToUpdate)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            var listOfCurrentUserTasks = listOfTasks.Where(t => t.UserId == CurrentUserSession.CurrentUserId).ToList();
            var oldTask = listOfCurrentUserTasks[index];
            var newTask = tasksToUpdate[0];
            oldTask.TaskHeading = newTask.TaskHeading;
            oldTask.Description = newTask.Description;
            oldTask.TargetDate = newTask.TargetDate;
            oldTask.TaskRecurranceType = newTask.TaskRecurranceType;
            for (int i = 1; i < tasksToUpdate.Count; i++)
            {
                listOfTasks.Add(tasksToUpdate[i]);
            }
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }

        /// <summary>
        /// Mark the task as complete in repo
        /// </summary>
        /// <param name="index"></param>
        public void MarkAsComplete(int index)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            var listOfCurrentUserTasks = listOfTasks.Where(t => t.UserId == CurrentUserSession.CurrentUserId).ToList();
            var task = listOfCurrentUserTasks[index];
            task.IsCompleted = true;
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }
    }
}
