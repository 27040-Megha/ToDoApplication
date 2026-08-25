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
        public void AddToDoTasks(List<Tasks> toDoTasks)
        {
            foreach (var tasks in toDoTasks)
            {
                var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
                listOfTasks.Add(tasks);
                FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
            }
        }
        
        public List<Tasks> ReturnAllToDoTasks()
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile);
            return listOfTasks.Where(task => task.UserId == CurrentUserSession.CurrentUserId).ToList();
        }

        public void RemoveDailyTask(int index)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile).Where(task => task.UserId == CurrentUserSession.CurrentUserId).ToList();
            listOfTasks.RemoveAt(index);
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }

        public void ModifyDailyTask(int index, List<Tasks> tasksToUpdate)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile).Where(task => task.UserId == CurrentUserSession.CurrentUserId).ToList();
            var oldTask = listOfTasks[index];
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

        public void MarkAsComplete(int index)
        {
            var listOfTasks = FileRepoService.ReadFile<Tasks>(FilePath.TaskFile).Where(task => task.UserId == CurrentUserSession.CurrentUserId).ToList();
            listOfTasks[index].IsCompleted = true;
            FileRepoService.WriteFile(listOfTasks, FilePath.TaskFile);
        }
    }
}
