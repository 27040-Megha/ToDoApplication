using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool ValidateEmployeeNumber(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 6)
            {
                return false;
            }

            if (!input.StartsWith("EMP",StringComparison.Ordinal))
            {
                return false;
            }

            return Regex.IsMatch(input.Substring(3), @"^\d{3}$");
        }

        public static bool ValidatePassword(string password)
        {
            if (password.Length != 8)
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
