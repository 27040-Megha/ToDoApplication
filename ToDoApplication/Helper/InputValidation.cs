using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Helper
{
    public static class InputValidation
    {
        public static bool ValidateString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (!input.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateDate(DateTime targetDate)
        {
            if (targetDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
