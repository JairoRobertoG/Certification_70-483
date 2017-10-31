
namespace Certification.Classes
{
    class MyClass<T>
    where T : class, new()
    {
        public MyClass()
        {
            MyProperty = new T();
        }
        T MyProperty { get; set; }
    }

    class MyClass
    {
        public string MyInstanceField;
        public static int MyStaticField = 42;
        public string Concatenate(string valueToAppend)
        {
            return MyInstanceField + valueToAppend;
        }
    }
}
