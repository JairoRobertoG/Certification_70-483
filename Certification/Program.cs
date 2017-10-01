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
        }
    }
}
