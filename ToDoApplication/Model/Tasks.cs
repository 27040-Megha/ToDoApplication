using System;
using ToDoApplication.Model.Enums;

namespace ToDoApplication.Model
{
    /// <summary>
    /// Model for To-Do
    /// </summary>
    public class Tasks
    {
        public Tasks(Guid taskId, string taskHeading, string description, DateTime targetDate, bool isCompleted, TaskRecurrance taskRecurranceType, Guid userId)
        {
            this.TaskId = taskId;
            this.TaskHeading = taskHeading;
            this.Description = description;
            this.TargetDate = targetDate;
            this.IsCompleted = isCompleted;
            this.TaskRecurranceType = taskRecurranceType;
            this.UserId = userId;
        }

        public Guid TaskId { get; set; }

        public string TaskHeading { get; set; }

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }

        public bool IsCompleted { get; set; }

        public TaskRecurrance TaskRecurranceType { get; set; }

        public Guid UserId { get; set; }
    }
}
