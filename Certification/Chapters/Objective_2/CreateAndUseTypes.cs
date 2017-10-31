using Certification.Classes;
using Certification.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;

namespace Certification.Chapters.Objective_2
{
    public class CreateAndUseTypes
    {
        public CreateAndUseTypes()
        {
        }

        [Flags]
        enum Days
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }
        //Creating enums
        //LISTING 2-1 Using the FlagAttribute for an enum
        public void UsingFlagAttributeForAnEnum()
        {
            Days readingDays = Days.Monday | Days.Saturday;
        }

        //LISTING 2-2 Creating a custom struct
        public struct Point
        {
            public int x, y;
            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }

        public void CreatingCustomStruc()
        {
            Point x = new Point(2, 100);
            int y = x.y;
        }

        //LISTING 2-3 Calling a method
        public void CallingMethod()
        {
            Console.WriteLine("I’m calling a method!");
        }

        //LISTING 2-4 Creating a method
        public void CreatingMethod()
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(1, 2).ToString());
        }

        //LISTING 2-5 Passing a complete customer to a method
        //public Distance CalculateDistanceTo(Customer customer)
        //{
        //    Distance result = //… Some difficult calculation that uses customer.Address
        //    return result;
        //}

        //LISTING 2-6 Passing only an address to a method
        //public Distance CalculateDistanceTo(Address address)
        //{
        //    Distance result = … // Some difficult calculation that uses address
        //    return result;
        //}

        //LISTING 2-7 Using named and optional arguments
        void MyMethod(int firstArgument, string secondArgument = "default value",
        bool thirdArgument = false)
        { }
        
        public void UsingNamedAndOptionalArguments()
        {
            MyMethod(1, thirdArgument: true);
        }

        //LISTING 2-8 Returning data from a method
        public void MethodWithoutAnyReturnValue()
        { /* Don’t return any value to the caller */ }

        public int MethodWithReturnValue()
        {
            return 42;
        }

        //LISTING 2-9 Declaring and using a field
        public void DeclaringAndUsingField()
        {
            MyClass instance = new MyClass();
            instance.MyInstanceField = "Some New Value";
        }

        //LISTING 2-10 Creating a collection such as a Deck class
        public void CreatingCollectionSuchAsDeckClass()
        {

        }

        //LISTING 2-11 Adding a constructor to your type
        public void AddingConstructorToYourType()
        {
            Deck deck = new Deck(5);
        }

        //LISTING 2-12 Chaining constructors
        public void ChainingConstructors()
        {
            ConstructorChaining chaining = new ConstructorChaining(5);
        }

        //LISTING 2-13 Generic Nullable<T> implementation
        struct Nullable<T> where T : struct
        {
            private bool hasValue;
            private T value;
            public Nullable(T value)
            {
                this.hasValue = true;
                this.value = value;
            }
            public bool HasValue { get { return this.hasValue; } }
            public T Value
            {
                get
                {
                    if (!this.HasValue) throw new ArgumentException();
                    return this.value;
                }
            }
            public T GetValueOrDefault()
            {
                return this.value;
            }
        }

        //LISTING 2-14 Using a where clause on a class definition

        //LISTING 2-15 Using default(T) with a generic type parameter
        void MyGenericMethod<T>(T value)
        {
            T defaultValue = default(T);
            var x = defaultValue;
            var y = value;
        }

        public void UsingDefaultTWithGenericTypeParameter()
        {
            MyGenericMethod<int>(3);
        }

        //LISTING 2-16 Creating an extension method
        //LISTING 2-17 Overriding a virtual method
        public void OverridingVirtualMethod()
        {
            Derived DerivedClass = new Derived();
        }

        //LISTING 2-18 Using the sealed keyword on a method
        public void UsingSealedKeywordOnMethod()
        {
            Derived2 DerivedClass2 = new Derived2();
        }

        //LISTING 2-19 Boxing an integer value
        public void BoxingAnIntegerValue()
        {
            int i = 42;
            object o = i;
            int x = (int)o;
        }

        //LISTING 2-21 Implicitly converting an object to a base type
        public void ImplicitlyConvertingAnObjectToBaseType()
        {
            //HttpClient client = new HttpClient();
            //object o = client;
            //IDisposable d = client;
        }

        //LISTING 2-22 Casting a double to an int
        public void CastingDoubleToInt()
        {
            double x = 1234.7;
            int a;
            // Cast double to int
            a = (int)x; // a = 1234
        }

        //LISTING 2-23 Explicitly casting a base type to a derived type
        public void ExplicitlyCastingBaseTypeToDerivedType()
        {
            Object stream = new MemoryStream();
            MemoryStream memoryStream = (MemoryStream)stream;
        }

        //LISTING 2-24 Implementing an implicit and explicit conversion operator

        //LISTING 2-25 Using an implicit and explicit cast operator on a custom type
        public void UsingAnImplicitAndExplicitCastOperatorOnACustomType()
        {
            Money m = new Money(42.42M);
            decimal amount = m;
            int truncatedAmount = (int)m;
        }

        //LISTING 2-26 Using the built-in Convert and Parse methods
        public void UsingBuiltInConvertParseMethods()
        {
            int value = Convert.ToInt32("42");
            value = int.Parse("42");
            bool success = int.TryParse("42", out value);
        }

        //LISTING 2-27 Using the is and as operators
        public void OpenConnection(DbConnection connection)
        {
            if (connection is SqlConnection)
            {
                // run some special code
            }
        }

        public void LogStream(Stream stream)
        {
            MemoryStream memoryStream = stream as MemoryStream;
            if (memoryStream != null)
            {
                // ....
            }
        }

        //LISTING 2-28 Exporting some data to Excel
        public void ExportingSomeDataToExcel(IEnumerable<dynamic> entities)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            dynamic workSheet = excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "Header A";
            workSheet.Cells[1, "B"] = "Header B";
            var row = 1;
            foreach (var entity in entities)
            {
                row++;
                workSheet.Cells[row, "A"] = entity.ColumnA;
                workSheet.Cells[row, "B"] = entity.ColumnB;
            }
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
        }

        //LISTING 2-29 Creating a custom DynamicObject
        public void CreatingCustomDynamicObject()
        {
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeVariable); // Displays ‘SomeProperty’
            Console.ReadLine();
        }

        //LISTING 2-30 The dynamic keyword in ASP.NET MVC
        //public ActionResult Index()
        //{
        //    ViewBag.MyDynamicValue = “This property is not statically typed”;
        //    return View();
        //}

        //LISTING 2-31 Using access modifiers

        //LISTING 2-32 Using the private access modifier

        //LISTING 2-33 Changing a private field without outside users noticing

        //LISTING 2-34 Using the protected access modifier with inheritance

        //LISTING 2-35 Using the internal access modifier
        public void UsindTheInternalAccessModifier()
        {
            MyInternalClass MyInternalClass = new MyInternalClass();
            MyInternalClass.MyMethod();
        }

        //LISTING 2-36 Encapsulating a field with custom methods
        private int _field;
        public void SetValue(int value) { _field = value; }
        public int GetValue() { return _field; }

        //LISTING 2-37 Creating a property
        public void CreatingProperty()
        {
            Person PersonTest = new Person();
            PersonTest.FirstName = null;
        }

        //LISTING 2-38 The IObjectContextAdapter interface
        public interface IObjectContextAdapter
        {
            //ObjectContext ObjectContext { get; }
        }

        //LISTING 2-39 Implementing an interface explicitly

        //LISTING 2-40 Implementing an interface explicitly

        //Objective 2.4: Create and implement a class hierarchy
        //LISTING 2-41 Creating and implementing an interface

        //LISTING 2-42 Adding a set accessor to an implemented interface property
        struct ReadAndWriteImplementation : IReadOnlyInterface
        {
            public int Value { get; set; }
        }

        //LISTING 2-43 Creating an interface with a generic type parameter
        public void CreatingAnInterfaceWithGenericTypeParameter()
        {
            IAnimal animal = new Dog();
        }

        //LISTING 2-45 Creating a base class

        //LISTING 2-46 Inheriting from a base class

        //LISTING 2-47 Overriding a virtual method

        //LISTING 2-48 Hiding a method with the new keyword
        public void HidingMethodWithNewKeyword()
        {
            //Base b = new Base();
            //b.Execute2();
            Base b = new Derived();
            b.Execute2();
        }

        //LISTING 2-50 A Rectangle class with an Area calculation
        //LISTING 2-51 A Square class that inherits from Rectangle
        public void SquareClassThatInheritsFromRectangule()
        {
            Rectangle rectangle = new Square(10, 5);
            rectangle.Width = 10;
            rectangle.Height = 5;
            Console.WriteLine(rectangle.Area);
            Console.ReadLine();
        }

        //LISTING 2-54 Implementing the IComparable interface
        public void ImplementingIComparableInterface()
        {
            List<OrderSort> orders = new List<OrderSort>
            {
                new OrderSort { Created = new DateTime(2012, 12, 1 )},
                new OrderSort { Created = new DateTime(2012, 1, 6 )},
                new OrderSort { Created = new DateTime(2012, 7, 8 )},
                new OrderSort { Created = new DateTime(2012, 2, 20 )},
            };

            orders.Sort(); 
        }

        //LISTING 2-55 Syntactic sugar of the foreach statement
        public void SyntaticSugarOfForeachStatment()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }
        }

        //LISTING 2-56 Implementing IEnumerable<T> on a custom type
        public void ImplementingIEnumerableOnCustomType()
        {
            Human[] humans = new Human[] {
                new Human("jairo", "Gomez"),
                new Human("ale", "romero"),
                new Human("victor", "gomez") };

            People people = new People(humans);
            var test = people.GetEnumerator();
        }

        //Objective 2.5: Find, execute, and create types at runtime by using reflection

    }
}
