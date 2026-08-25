using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model.Enums;

namespace ToDoApplication.Model
{
    /// <summary>
    /// Model for To-Do
    /// </summary>
    public class Tasks
    {
        public Tasks(string taskHeading, string description, DateTime targetDate, bool isCompleted, TaskRecurrance taskRecurranceType, Guid userId)
        {
            this.TaskHeading = taskHeading;
            this.Description = description;
            this.TargetDate = targetDate;
            this.IsCompleted = isCompleted;
            this.TaskRecurranceType = taskRecurranceType;
            this.UserId = userId;
        }

        public string TaskHeading { get; set; }

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }

        public bool IsCompleted { get; set; }

        public TaskRecurrance TaskRecurranceType{ get; set; }

        public Guid UserId { get; set; }
    }
}
