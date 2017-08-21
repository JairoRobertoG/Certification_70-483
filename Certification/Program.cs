using Certification.Chapters.manage_program_flow;
using System;
using System.Threading;


namespace Certification
{
    public static class Program
    {
        public static void Main()
        {
            MultithreadingAsynchronousProcessing multithreading_asynchronous_processing;
            multithreading_asynchronous_processing = new MultithreadingAsynchronousProcessing();

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
            multithreading_asynchronous_processing.UsingTaskFactory();

        }
    }
}
