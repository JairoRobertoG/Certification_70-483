
using System;

namespace Certification.Classes
{
    class Derived : Base
    {
        public void MyDerivedMethod()
        {
            // _privateField = 41; // Not OK, this will generate a compile error
            _protectedField = 43; // OK, protected fields can be accessed
                                  //MyPrivateMethod(); // Not OK, this will generate a compile error
            MyProtectedMethod(); // OK, protected methods can be accessed
        }

        protected override void Execute()
        {
            Log("Before executing");
            base.Execute();
            Log("After executing");
        }

        public new void Execute2() { Console.WriteLine("Derived.Execute"); }

        private void Log(string message) { /* some logging code */ }

        public override void AbstractMethod() { }
    }
}
