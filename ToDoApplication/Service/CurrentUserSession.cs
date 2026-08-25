using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Service
{
    /// <summary>
    /// Maintains Current User ID globally
    /// </summary>
    public static class CurrentUserSession
    {
        /// <summary>
        /// Current User ID
        /// </summary>
        public static Guid CurrentUserId {get; set;}
    }
}
