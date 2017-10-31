using System;

namespace Certification.Classes
{
    abstract class Base
    {
        private int _privateField = 42;
        protected int _protectedField = 42;
        private void MyPrivateMethod() { }
        protected void MyProtectedMethod() { }

        protected virtual void Execute(){}

        public void Execute2() { Console.WriteLine("Base.Execute"); }

        public virtual void MethodWithImplementation() {/*Method with implementation*/}
        public abstract void AbstractMethod();
    }
}
