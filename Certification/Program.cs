using Certification.Chapters.Objective_1;
using Certification.Chapters.Objective_2;
using Certification.StudyGuide_MCSD_;
using System.Collections.Generic;

namespace Certification
{
    public static class Program
    {
        public static void Main()
        {
            ManageProgramFlow ManageProgramFlow = new ManageProgramFlow();
            StudyGuide StudyGuide = new StudyGuide();
            CreateAndUseTypes CreateAndUseTypes = new CreateAndUseTypes();

            #region Methods Objective 1 Manage Program Flow
            //LISTING 1-1 Creating a thread with the Thread class
            //multithreading_asynchronous_processing.TopicThreadClass();

            //LISTING 1-2 Using a background thread
            //multithreading_asynchronous_processing.TopicBackgroundThread();

            //LISTING 1-3 Using the ParameterizedThreadStart
            //multithreading_asynchronous_processing.TopicParameterizedThreadStart(5);

            //LISTING 1-4 Stopping a thread
            //multithreading_asynchronous_processing.TopicStoppingThread(false);

            //LISTING 1-5 Using the ThreadStaticAttribute
            //multithreading_asynchronous_processing.TopicThreadStaticAttribute();

            //LISTING 1 - 6 Using ThreadLocal<T>
            //multithreading_asynchronous_processing.TopicThreadLocal();

            //LISTING 1-7 Queuing some work to the thread pool
            //multithreading_asynchronous_processing.TopicQueuingSomeWorkTreadPool();

            //LISTING 1-8 Starting a new Task
            //multithreading_asynchronous_processing.StartingNewTask();

            //Listing 1-9 Using a Task that returns a value
            //multithreading_asynchronous_processing.UsingTaskReturnValue();

            //LISTING 1-10 Adding a continuation
            //multithreading_asynchronous_processing.AddingContinuation();

            //LISTING 1-11 Scheduling different continuation tasks
            //multithreading_asynchronous_processing.SchedulingDufferentContinuationTask();

            //LISTING 1-12 Attaching child tasks to a parent task
            //multithreading_asynchronous_processing.AttachingChildTasksToParentTask();

            //LISTING 1-13 Using a TaskFactory
            //multithreading_asynchronous_processing.UsingTaskFactory();

            //LISTING 1-14 Using Task.WaitAll
            //multithreading_asynchronous_processing.UsingTaskWaitAll();

            //LISTING 1-15 Using Task.WaitAny
            //multithreading_asynchronous_processing.UsingTaskWaitAny();

            //LISTING 1-16 Using Parallel.For and Parallel.Foreach
            //multithreading_asynchronous_processing.UsingParallelForParallelForeach();

            //LISTING 1-17 Using Parallel.Break
            //multithreading_asynchronous_processing.UsingParallelBreak();

            //LISTING 1-18 async and await
            //multithreading_asynchronous_processing.AsyncAndAwait();

            //LISTING 1-19 Scalability versus responsiveness
            //multithreading_asynchronous_processing.SleepAsyncB(5000);

            //LISTING 1-22 Using AsParallel
            //multithreading_asynchronous_processing.UsingAsParallel();

            //LISTING 1-23 Unordered parallel query
            //multithreading_asynchronous_processing.UnorderedPArallelQuery();

            //LISTING 1-24 Ordered parallel query
            //multithreading_asynchronous_processing.OrderedParallelQuery();

            //LISTING 1-25 Making a parallel query sequential
            //multithreading_asynchronous_processing.MakingParallelQuerySecuential();

            //LISTING 1-26 Using ForAll
            //multithreading_asynchronous_processing.UsingForAll();

            //LISTING 1-27 Catching AggregateException
            //multithreading_asynchronous_processing.CatchingAggregateException();

            //LISTING 1-28 Using BlockingCollection<T>
            //multithreading_asynchronous_processing.UsingBlockingCollection();

            //LISTING 1-29 Using GetConsumingEnumerable on a BlockingCollection
            //multithreading_asynchronous_processing.UsingGetConsumingEnumerableOnBlockingCollection();

            //LISTING 1-30 Using a ConcurrentBag
            //multithreading_asynchronous_processing.UsingConcurrentBag();

            ////LISTING 1-31 Enumerating a ConcurrentBag
            //multithreading_asynchronous_processing.EnumeratingConcurrentBag();

            //LISTING 1-32 Using a ConcurrentStack
            //multithreading_asynchronous_processing.UsingConcurrentStack();

            //LISTING 1-33 Using a ConcurrentQueue.
            //multithreading_asynchronous_processing.UsingConcurrentQueue();

            //LISTING 1-34 Using a ConcurrentDictionary
            //multithreading_asynchronous_processing.UsingConcurrentDictionary();

            //LISTING 1-35 Accessing shared data in a multithreaded application
            //multithreading_asynchronous_processing.AccessingSharedDataInMultithreadedApplication();

            ////LISTING 1-36 Using the lock keyword
            //multithreading_asynchronous_processing.UsingLockKeyword();

            //LISTING 1-38 Generated code from a lock statement
            //multithreading_asynchronous_processing.GeneretedCodeFromLockStatment();

            ////LISTING 1-39 A potential problem with multithreaded code
            //multithreading_asynchronous_processing.PotencialProblemWithMultithreadedCode();

            //LISTING 1-40 Using the Interlocked class
            //multithreading_asynchronous_processing.UsingInterlockedClass();

            //LISTING 1-41 Compare and exchange as a nonatomic operation
            //multithreading_asynchronous_processing.CompareExchangeAsNonatomicOperation();

            //LISTING 1-42 Using a CancellationToken
            //multithreading_asynchronous_processing.UsingCacellationToken();

            //LISTING 1-43 Throwing OperationCanceledException
            //multithreading_asynchronous_processing.ThrowingOperationCanceledException();

            //LISTING 1-46 A better readable nested if statement
            //multithreading_asynchronous_processing.BetterReadableNestedIfStatement();

            //LISTING 1-47 Boolean OR operator
            //multithreading_asynchronous_processing.BooleanOrOperator();

            //LISTING 1-48 Short-circuiting the OR operator
            //multithreading_asynchronous_processing.OrShortCircuit();

            //LISTING 1-51 Using the XOR operator
            //multithreading_asynchronous_processing.UsingXOROperator();

            ////LISTING 1-55 Using an else statement
            //multithreading_asynchronous_processing.UsingAnElseStatement();

            ////LISTING 1-64 A basic for loop
            //multithreading_asynchronous_processing.ABasicForLoop();

            //LISTING 1-66 A for loop with a custom increment
            //multithreading_asynchronous_processing.AForLoopWithACustomIncrement();

            ////LISTING 1-67 A for loop with a break statement
            //multithreading_asynchronous_processing.AForLoopWithABreakStatement();

            //LISTING 1-68 A for loop with a continue statement
            //multithreading_asynchronous_processing.AForLoopWithAContinueStatement();

            //LISTING 1-70 do-while loop
            //multithreading_asynchronous_processing.DoWhileLoop();

            //LISTING 1-71 foreach loop
            //multithreading_asynchronous_processing.ForeachLoop();

            ////LISTING 1-72 Changing items in a foreach
            //multithreading_asynchronous_processing.ChangingItemsInForeach();

            //LISTING 1-73 The compiler-generated code for a foreach loop
            //multithreading_asynchronous_processing.CompilerGeneratedCodeForForeachLoop();

            //LISTING 1-75 Using a delegate
            //multithreading_asynchronous_processing.UsingDelegate();

            ////LISTING 1-76 A multicast delegate
            //multithreading_asynchronous_processing.Multicastelegate();

            ////LISTING 1-77 Covariance with delegates
            //multithreading_asynchronous_processing.CovarianceWithDelegates();

            //LISTING 1-79 Lambda expression to create a delegate
            //multithreading_asynchronous_processing.LambdaExpressions();

            //LISTING 1-81 Using the Action delegate
            //multithreading_asynchronous_processing.UsingActionDelegate();

            ////LISTING 1-82 Using an Action to expose an event
            //multithreading_asynchronous_processing.UsingActionExposeAnEvent();

            ////LISTING 1-83 Using the event keyword
            //multithreading_asynchronous_processing.UsingEventKeyword();

            ///LISTING 1-84 Custom event arguments
            //multithreading_asynchronous_processing.CustomEventArguments();

            ////LISTING 1-85 Custom event accessor
            //multithreading_asynchronous_processing.CustomEventAccessor();

            ////LISTING 1-86 Exception when raising an event
            //multithreading_asynchronous_processing.ExceptionWhenRaisingAnEvent();

            //LISTING 1-87 Manually raising events with exception handling
            //multithreading_asynchronous_processing.ManuallyRaisingEventsWithExceptionHandling();

            //LISTING 1-88 Parsing an invalid number
            //multithreading_asynchronous_processing.ParsingAnInvalidNumber();

            ////LISTING 1-89 Catching a FormatException
            //multithreading_asynchronous_processing.CatchingFormatException();

            //LISTING 1-90 Catching different exception types
            //multithreading_asynchronous_processing.CatchingDifferentExceptionTypes();

            ////LISTING 1-91 Using a finally block
            //multithreading_asynchronous_processing.UsingFinallyBlock();

            //LISTING 1-92 Using Environment.FailFast
            //multithreading_asynchronous_processing.UsingEnviromentFailFast();

            //LISTING 1-93 Inspecting an exception
            //multithreading_asynchronous_processing.InspectingAnexception();

            //LISTING 1-94 Throwing an ArgumentNullException
            //multithreading_asynchronous_processing.ThrowingAnArgumentNullException();

            //LISTING 1-97 Using ExceptionDispatchInfo.Throw
            //multithreading_asynchronous_processing.UsingExceptionDispatchInfoThrow();
            #endregion

            //LISTING 2-2 Creating a custom struct
            //CreateAndUseTypes.CreatingCustomStruc();

            //LISTING 2-15 Using default(T) with a generic type parameter
            //CreateAndUseTypes.UsingDefaultTWithGenericTypeParameter();

            //LISTING 2-17 Overriding a virtual method
            //CreateAndUseTypes.OverridingVirtualMethod();

            //LISTING 2-18 Using the sealed keyword on a method
            //CreateAndUseTypes.UsingSealedKeywordOnMethod();

            //LISTING 2-28 Exporting some data to Excel
            //var entities = new List<dynamic> {
            //    new
            //        {
            //        ColumnA = 1,
            //        ColumnB = "Foo"
            //        },
            //    new
            //        {
            //        ColumnA= 2,
            //        ColumnB= "Bar"
            //        }
            //};
            //CreateAndUseTypes.ExportingSomeDataToExcel(entities);

            //LISTING 2-29 Creating a custom DynamicObject
            //CreateAndUseTypes.CreatingCustomDynamicObject();

            //LISTING 2-30 The dynamic keyword in ASP.NET MVC
            //public ActionResult Index()
            //{
            //    ViewBag.MyDynamicValue = "This property is not statically typed";
            //    return View();
            //}

            ////LISTING 2-35 Using the internal access modifier
            //CreateAndUseTypes.UsindTheInternalAccessModifier();

            ////LISTING 2-37 Creating a property
            //CreateAndUseTypes.CreatingProperty();

            //LISTING 2-48 Hiding a method with the new keyword
            //CreateAndUseTypes.HidingMethodWithNewKeyword();

            //LISTING 2-51 A Square class that inherits from Rectangle
            //CreateAndUseTypes.SquareClassThatInheritsFromRectangule();

            //LISTING 2-54 Implementing the IComparable interface
            //CreateAndUseTypes.ImplementingIComparableInterface();

            //LISTING 2-55 Syntactic sugar of the foreach statement
            //CreateAndUseTypes.SyntaticSugarOfForeachStatment();

            //LISTING 2-56 Implementing IEnumerable<T> on a custom type
            //CreateAndUseTypes.ImplementingIEnumerableOnCustomType();

            //LISTING 2-71 Inspecting an assembly for types that implement a custom interface
            //CreateAndUseTypes.InspectingAssamblyForTypesThatImplementCustomInterface();

            ////LISTING 2-72 Getting the value of a field through reflection
            //CreateAndUseTypes.GettingValueOfFieldThroughReflection(new { id = 50 });

            ////LISTING 2-73 Executing a method through reflection
            //CreateAndUseTypes.ExcecutingMethodThroughReflection();

            //LISTING 2-74 Generating “Hello World!” with the CodeDOM
            //CreateAndUseTypes.GeneratingCodeWithTheCodeDOM();

            ////LISTING 2-75 Generating a source file from a CodeCompileUnit
            //CreateAndUseTypes.GeneratingSourceFileFromCodeCompleUmnit();

            ////LISTING 2-77 Creating a Func type with a lambda
            //CreateAndUseTypes.CreatingFuncTypeWithLambda();

            //LISTING 2-78 Creating “Hello World!” with an expression tree
            //CreateAndUseTypes.CreatingCodeWithAnExpressionTree();

            ////LISTING 2-80 Not closing a file will throw an error
            //CreateAndUseTypes.NOtClosingFileWillThrowAnError();

            //LISTING 2-81 Forcing a garbage collection
            //CreateAndUseTypes.ForcingGarbageCollection();

            ////LISTING 2-83 Calling Dispose to free unmanaged resources
            //CreateAndUseTypes.CallingDisposeToFreeUnmanagedResources();

            ////LISTING 2-84 Implementing IDisposable and a finalizer
            //CreateAndUseTypes.ImplementingIDisposableFinalizer();

            //LISTING 2-85 Using WeakReference
            //CreateAndUseTypes.UsingWeakReference();

            //LISTING 2-86 Creating a large number of strings
            //CreateAndUseTypes.CreatingLargeNumberString();

            //LISTING 2-87 Changing a character with a StringBuilder
            //CreateAndUseTypes.ChangingCharacterWithStringBuilder();

            ////LISTING 2-89 Using a StringWriter as the output for an XmlWriter
            //CreateAndUseTypes.UsingStringWriterAsTheOutputForAnXmlWriter();

            ////LISTING 2-90 Using a StringReader as the input for an XmlReader
            //CreateAndUseTypes.UsingStringReaderAsTheInputForAnXmlReader();

            //LISTING 2-92 Using StartsWith and EndsWith
            //CreateAndUseTypes.UsingStartsWithAndEndsWith();

            ////LISTING 2-94 Changing a string with a regular expression
            //CreateAndUseTypes.ChangingStringWithRegularExpression();

            ////LISTING 2-95 Iterating over a string
            //CreateAndUseTypes.IteratingOverString();

            //LISTING 2-96 Overriding ToString
            //CreateAndUseTypes.OverridingToString();

            //LISTING 2-98 Displaying a DateTime with different format strings
            //CreateAndUseTypes.DisplayingDateTimeWithDifferentFormatString();

            ////LISTING 2-99 Implementing custom formatting on a type
            CreateAndUseTypes.ImplementingCustomFormattingOnType();
        }
    }
}
