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
            multithreading_asynchronous_processing.TopicThreadClass();

            //LISTING 1-2 Using a background thread
            //multithreading_asynchronous_processing.TopicBackgroundThread();

            //LISTING 1-3 Using the ParameterizedThreadStart
            //multithreading_asynchronous_processing.TopicParameterizedThreadStart(5);

            //LISTING 1-4 Stopping a thread
            //multithreading_asynchronous_processing.TopicStoppingThread(false);
        }
    }
}
