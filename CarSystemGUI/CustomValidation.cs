using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace CarSystemGUI
{
    public class CustomRule : ValidationRule
    {
        public string PropertyName { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (value.Equals(string.Empty))
                {
                    return new ValidationResult(false, $"Empty Field");
                }
            }
            catch
            {
                return new ValidationResult(false, $"Empty Field");
            }

            if (PropertyName == "Name" || PropertyName == "Surename")
            {
                return NameValidate(value.ToString(), PropertyName);
            }
            if (PropertyName == "IDCardNumber" || PropertyName == "EGN")
            {
                return IDandEGNValidate(value.ToString(), PropertyName);
            }
            if (PropertyName == "PhoneNumber")
            {
                return PhoneNumberValidate(value.ToString());
            }
            if (PropertyName == "Email")
            {
                return EmailValidate(value.ToString());
            }
            if (PropertyName == "VinNumber")
            {
                return VINValidate(value.ToString());
            }
            if (PropertyName == "RegNumber")
            {
                return RegNumberValidate(value.ToString());
            }
            if (PropertyName == "Price")
            {
                return PriceValidate(value.ToString());
            }
            if (PropertyName == "Brand" || PropertyName == "Model")
            {
                return Brand_ModelValidate(value.ToString(), PropertyName);
            }
            return ValidationResult.ValidResult;
        }

        public static ValidationResult NameValidate(string input, string propName)
        {
            // @" ^[a-zA-Z]+$"
            if (Regex.Match(input, @"^[A-Z]{1}[a-z]*$").Success)
                return ValidationResult.ValidResult;
            else
            {
                return new ValidationResult(false, propName + " can contain only letters and must start with upper case!");
            }
        }

        public static ValidationResult Brand_ModelValidate(string input, string propName)
        {
            // @" ^[a-zA-Z]+$"
            if (Regex.IsMatch(input, @"^[A-Z]{1}[a-zA-Z]*$"))
                return ValidationResult.ValidResult;
            else
            {
                return new ValidationResult(false, propName + " can contain only letters and must start with upper case!");
            }
        }

        public static ValidationResult IDandEGNValidate(string input, string propName)
        {
            try
            {
                long testint;
                testint = long.Parse((String)input);
            }
            catch
            {
                return new ValidationResult(false, propName + " must be 10 digit number!");
            }
            if (input.ElementAt(0) == '0')
            {
                return new ValidationResult(false, propName + " cannot start with 0!");
            }
            if (Regex.Match(input, @"^(\d{10})$").Success)
                return ValidationResult.ValidResult;
            else
            {
                return new ValidationResult(false, propName + " must be 10 digit number!");
            }
        }

        public static ValidationResult PhoneNumberValidate(string input)
        {
            try
            {
                int testint;
                testint = Int32.Parse((String)input);
            }
            catch
            {
                return new ValidationResult(false, "Phone number must be 10 digit number!");
            }

            if (Regex.Match(input, @"^(\d{9})$").Success)
                return ValidationResult.ValidResult;
            else
            {
                return new ValidationResult(false, "Phone number must contain 9 digit!");
            }
        }

        public static ValidationResult EmailValidate(string input)
        {
            try
            {
                MailAddress m = new MailAddress(input);
                return ValidationResult.ValidResult;
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Wrong Email input!");
            }
        }

        public static ValidationResult VINValidate(string input)
        {
            if (Regex.Match(input, @"^[A-Z0-9]{17}\z").Success)
                return ValidationResult.ValidResult;
            else
            {
                return new ValidationResult(false, "VIN number must contain 17 digit!");
            }
        }

        public static ValidationResult RegNumberValidate(string input)
        {

            if (Regex.Match(input, @"^[ABEKMНOPCTYX]{2}[0-9]{4}[ABEKMНOPCTYX]{2}\z").Success)
                return ValidationResult.ValidResult;
            else
            {
                return new ValidationResult(false, "Registration number format is \"AB1234BA\" ");
            }
        }

        public static ValidationResult PriceValidate (string input)
        {
            try
            {
                double testint;
                testint = double.Parse((String)input);
            }
            catch
            {
                return new ValidationResult(false, "Wrong input!");
            }
            return ValidationResult.ValidResult;
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
