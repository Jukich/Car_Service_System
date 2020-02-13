using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;

namespace CarSystemGUI
{
    class Validation : IDataErrorInfo
    {

        public string Error { get { return null; } }
        public string GetError()
        {
            return this.Error;
            
        }

        protected string name;
        protected bool nameChanged = false;
        protected string surename;
        protected bool surenameChanged = false;
        protected long? idCardNumber;
        protected bool idCardNumberChanged = false;
        protected long? egn;
        protected bool egnChanged = false;
        protected string country;
        protected bool countryChanged = false;
        protected string city;
        protected bool cityChanged = false;
        protected string street;
        protected bool streetChanged = false;
        protected string gender;
        protected bool genderChanged = false;
        protected string phone;
        protected bool phoneChanged = false;
        protected string email;
        protected bool emailChanged = false;



        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "_Name")
                {
                    if (nameChanged)
                    {
                        if (string.IsNullOrEmpty(_Name))
                            result = "Field is empty";
                        else if (!CarSystemGUI.Validate.NameValidate(_Name))
                            result = "Name can contain only letters";
                    }
                }
                if (name == "Surename")
                {
                    if (surenameChanged)
                    {
                        if (string.IsNullOrEmpty(Surename))
                            result = "Field is empty";
                        else if (!CarSystemGUI.Validate.NameValidate(Surename))
                            result = "Name can contain only letters";
                    }
                }

                if (name == "IDCardNumber")
                {
                    if (idCardNumberChanged)
                    {

                        if (string.IsNullOrWhiteSpace(IDCardNumber.ToString()))
                            result = "Field is empty";
                        else if (!CarSystemGUI.Validate.EGNValidate(IDCardNumber.ToString()))
                            result = "ID Card number must be 10 digit number";

                        //else if(this["IDCardNumber"]==)
                    }
                }
                if (name == "EGN")
                {
                    if (egnChanged)
                    {
                        if (string.IsNullOrWhiteSpace(EGN.ToString()))
                            result = "Field is empty";
                        else if (!CarSystemGUI.Validate.EGNValidate(EGN.ToString()))
                            result = "EGN number must be 10 digit number";

                    }
                }
                if (name == "Country")
                {
                    if (countryChanged)
                    {

                        if (string.IsNullOrWhiteSpace(Country))
                            result = "Field is empty";
                    }
                }
                if (name == "City")
                {
                    if (cityChanged)
                    {

                        if (string.IsNullOrWhiteSpace(City))
                            result = "Field is empty";
                    }
                }
                if (name == "Street")
                {
                    if (streetChanged)
                    {
                        if (string.IsNullOrWhiteSpace(Street))
                            result = "Field is empty";

                    }
                }      

                if (name == "Phone")
                {
                    if (phoneChanged)
                    {
                        if (string.IsNullOrWhiteSpace(Phone))
                            result = "Field is empty";
                        else if (!CarSystemGUI.Validate.PhoneNumberValidate(Phone))
                            result = "Wrong input";
                    }
                }
                if (name == "Email")
                {
                    if (emailChanged)
                    {
                        if (string.IsNullOrWhiteSpace(Email))
                            result = "Field is empty";
                        else if (!CarSystemGUI.Validate.EmailValidate(Email))
                            result = "Wrong input";
                    }
                }

                    return result;
            }
        }

        #region Properties
        public virtual string _Name { get; set; }

        public virtual string Surename { get; set; }
        
        public virtual long? IDCardNumber { get; set; }

        public virtual long? EGN { get; set; }

        public virtual string Country { get; set; }

        public virtual string City { get; set; }

        public virtual string Street { get; set; }

        public virtual string Gender { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        #endregion
    }

}
