using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Model.Enums
{
    /// <summary>
    /// Enum for MenuOptions
    /// </summary>
    public enum MenuOptions
    {
        AddTask = 1,

        DeleteTask,

        EditTask,

        MarkTaskAsComplete,

        ViewToDo,

        ViewCalendar,

        Logout,

        Invalid = 0,
    }
}
