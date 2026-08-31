using System;

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
        public static Guid CurrentUserId { get; set; }
    }
}
