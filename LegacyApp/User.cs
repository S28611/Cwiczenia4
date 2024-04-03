using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get;  set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public bool EmailValidation()
        {
            if (!EmailAddress.Contains("@") && !EmailAddress.Contains("."))
            {
                return false;
            }

            return true;
        }

        public bool NameIsNull()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                return false;
            }
            return true;
        }

        public bool OlderThan21(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }
    }
}