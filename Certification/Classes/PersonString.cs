using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    class PersonString
    {
        public PersonString(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string ToString(string format)
        {
            if(string.IsNullOrWhiteSpace(format) || format == "G")
                format = "FL";

            format = format.Trim().ToUpperInvariant();

            switch (format)
            {
                case "FL":
                    return FirstName + " " + LastName;
                case "LF":
                    return LastName + " " + FirstName;
                case "FSL":
                    return FirstName + ", " + LastName;
                case "LSF":
                    return LastName + ", " + FirstName;
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + LastName;
        }
    }
}
