using Certification.Chapters.manage_program_flow;
using Certification.StudyGuide_MCSD_;
using System;
using System.Threading;

namespace Certification
{
    public static class Program
    {
        public static void Main()
        {
            MultithreadingAsynchronousProcessing multithreading_asynchronous_processing = new MultithreadingAsynchronousProcessing();
            StudyGuide study_guide = new StudyGuide();

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
            multithreading_asynchronous_processing.UsingDelegate();

        }
    }
}
