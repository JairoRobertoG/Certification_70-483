using Certification.Classes;
using Certification.Interfaces;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

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
        //LISTING 2-58 Applying an attribute
        //LISTING 2-59 Using multiple attributes
        //LISTING 2-60 Specifying the target of an attribute explicitly
        //LISTING 2-61 Seeing whether an attribute is defined
        //LISTING 2-62 Getting a specific attribute instance
        //LISTING 2-63 Using a category attribute in xUnit
        //LISTING 2-64 Creating a custom attribute
        //LISTING 2-66 Defining the targets for a custom attribute
        //LISTING 2-67 Setting the AllowMultiple parameter for a custom attribute
        //LISTING 2-68 Adding properties to a custom attribute

        //Using reflection
        //LISTING 2-69 Creating an interface that can be found through reflection
        //LISTING 2-70 Creating a custom plug-in class
        //LISTING 2-71 Inspecting an assembly for types that implement a custom interface
        public void InspectingAssamblyForTypesThatImplementCustomInterface()
        {
            Assembly pluginAssembly = Assembly.Load("assemblyname");

            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }
        }

        //LISTING 2-72 Getting the value of a field through reflection
        public void GettingValueOfFieldThroughReflection(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                {
                    Console.WriteLine(field.GetValue(obj));
                }
            }
            Console.ReadLine();
        }

        //LISTING 2-73 Executing a method through reflection
        public void ExcecutingMethodThroughReflection()
        {
            int i = 42;
            MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo",
            new Type[] { typeof(int) });
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
        }

        //Using CodeDom and lambda expressions to generate code
        //LISTING 2-74 Generating “Hello World!” with the CodeDOM
        public void GeneratingCodeWithTheCodeDOM()
        {}

        //LISTING 2-75 Generating a source file from a CodeCompileUnit
        public void GeneratingSourceFileFromCodeCompleUmnit()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNamespace = new CodeNamespace("MyNamespace");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            new CodeTypeReferenceExpression("Console"),
            "WriteLine", new CodePrimitiveExpression("Hello World!"));
            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(cs1);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, " ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                new CodeGeneratorOptions());
                tw.Close();
            }
        }

        //Lambda expressions
        //LISTING 2-77 Creating a Func type with a lambda
        public void CreatingFuncTypeWithLambda()
        {
            Func<int, int, int> addFunc = (x, y) => x + y;
            Console.WriteLine(addFunc(2, 3));
            Console.ReadLine();
        }

        //LISTING 2-78 Creating “Hello World!” with an expression tree
        public void CreatingCodeWithAnExpressionTree()
        {
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello")
                    ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                    )
                );

            Expression.Lambda<Action>(blockExpr).Compile()();
        }

        //LISTING 2-80 Not closing a file will throw an error
        public void NOtClosingFileWillThrowAnError()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            File.Delete("temp.dat"); // Throws an IOException because the file is already open.
        }

        //LISTING 2-81 Forcing a garbage collection
        public void ForcingGarbageCollection()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete("temp.dat");
        }

        //LISTING 2-82 The IDisposable interface

        //LISTING 2-83 Calling Dispose to free unmanaged resources
        public void CallingDisposeToFreeUnmanagedResources()
        {
            using (StreamWriter sw = File.CreateText("temp.dat"))
            {
                sw.Write("some data");
                sw.Dispose();
                File.Delete("temp.dat");
            }
        }
        //3970640
        //Implementing IDisposable and a finalizer
        //LISTING 2-84 Implementing IDisposable and a finalizer
        public void ImplementingIDisposableFinalizer()
        {
            UnmangedWrapper unmangedWrapper = new UnmangedWrapper();
            unmangedWrapper.Dispose();
            File.Delete("temp.dat");
        }

        //LISTING 2-85 Using WeakReference
        static WeakReference data;
        public void UsingWeakReference()
        {
            object result = GetData();
            GC.Collect();// Uncommenting this line will make data.Target null
            result = GetData();
        }

        private object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(new { id = 5 });
            }
            if (data.Target == null)
            {
                data.Target = new { id = 5 };
            }

            return data.Target;
        }

        //LISTING 2-86 Creating a large number of strings
        public void CreatingLargeNumberString()
        {
            string s = string.Empty;
            for (int i = 0; i < 10000; i++)
            {
                s += "x";
            }
        }

        //LISTING 2-87 Changing a character with a StringBuilder
        public void ChangingCharacterWithStringBuilder()
        {
            StringBuilder sb = new System.Text.StringBuilder("A initial value");
            sb[0] = 'B';
            Console.WriteLine(sb);
            Console.ReadLine();
        }

        //LISTING 2-88 Using a StringBuilder in a loop
        public void UsingStringBuilderInLoop()
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("x");
            }
        }

        //LISTING 2-89 Using a StringWriter as the output for an XmlWriter
        public void UsingStringWriterAsTheOutputForAnXmlWriter()
        {
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();
            Console.ReadLine();
        }

        //LISTING 2-90 Using a StringReader as the input for an XmlReader
        public void UsingStringReaderAsTheInputForAnXmlReader()
        {
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();

            var stringReader = new StringReader(xml);
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml()); // Make sure that you read the decimal part correctly
            }
        }

        //LISTING 2-91 Using IndexOf and LastIndexOf
        public void UsingIndexOfAndLAstIndex()
        {
            string value = "My Sample Value";
            int indexOfp = value.IndexOf('p'); // returns 6
            int lastIndexOfm = value.LastIndexOf('m'); // returns 5
        }

        //LISTING 2-92 Using StartsWith and EndsWith
        public void UsingStartsWithAndEndsWith()
        {
            string value = "< mycustominput >";
            if (value.StartsWith("<"))
                Console.WriteLine("<");
            if (value.EndsWith(">"))
                Console.WriteLine(">");

            Console.ReadLine();
        }

        //LISTING 2-93 Reading a substring
        public void ReadingSubstring()
        {
            string value = "My Sample Value";
            string subString = value.Substring(3, 6); // Returns ‘Sample’
        }

        //LISTING 2-94 Changing a string with a regular expression
        public void ChangingStringWithRegularExpression()
        {
            string pattern = "(Mr\\.? | Mrs\\.? | Miss | Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
                                "Abraham Adams”, “Ms. Nicole Norris" };

            foreach (string name in names)
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));

            Console.ReadLine();
        }

        //LISTING 2-95 Iterating over a string
        public void IteratingOverString()
        {
            string value = "My Custom Value";
            foreach (char c in value)
                Console.WriteLine(c);

            Console.ReadLine();
        }
    }
}
