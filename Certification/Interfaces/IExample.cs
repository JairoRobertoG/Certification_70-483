using Certification.Classes;
using System;

namespace Certification.Interfaces
{
    interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get; set; }
        Person GetPerson();
    }
}
