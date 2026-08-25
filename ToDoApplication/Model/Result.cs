using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Model
{
    /// <summary>
    /// Result Object that has Success Message
    /// </summary>
    public class Result
    {
        public Result(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
