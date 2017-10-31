using System;

namespace Certification.Classes
{
    class ExampleImplementation
    {
        public string GetResult()
        {
            return "result";
        }
        public int Value { get; set; }
        public event EventHandler CalculationPerformed;
        public event EventHandler ResultRetrieved;
        public int this[string index]
        {
            get
            {
                return 42;
            }
            set { }
        }
        public Person GetPerson()
        {
            Person result = new Person();
            return result;
        }
    }
}
