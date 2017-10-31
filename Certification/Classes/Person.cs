using System;

namespace Certification.Classes
{
    class Person
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                _firstName = value;
            }
        }
        public string LastName { get; set; }
    }
}
