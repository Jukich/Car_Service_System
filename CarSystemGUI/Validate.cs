using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CarSystemGUI
{

    
    public class Validate
    {
        public static bool NameValidate(string input)
        {
            return Regex.Match(input, @"^[a-zA-Z]+$").Success;
        }

        public static bool EGNValidate(string input)
        {
            return Regex.Match(input, @"^(\d{10})$").Success;
        }

        public static bool PhoneNumberValidate(string input)
        {
            return Regex.Match(input, @"^(\d{9})$").Success;
        }

        public static bool EmailValidate(string input)
        {
            try
            {
                MailAddress m = new MailAddress(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }

    }
}
