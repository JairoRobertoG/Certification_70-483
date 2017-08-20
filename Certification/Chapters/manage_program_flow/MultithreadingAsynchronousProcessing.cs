﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification.Chapters.manage_program_flow
{
    public class MultithreadingAsynchronousProcessing
    {
        public MultithreadingAsynchronousProcessing()
        {
        }

        //LISTING 1-1 Creating a thread with the Thread class
        private void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public void TopicThreadClass()
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe");
            Process.Start(start);

            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t.Join();
        }

        //LISTING 1-2 Using a background thread
        public void TopicBackgroundThread()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start();
        }

        //LISTING 1-3 Using the ParameterizedThreadStart
        private void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);

                Thread.Sleep(0);
            }
        }

        public void TopicParameterizedThreadStart(int number_proccess)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(number_proccess);
            t.Join();
        }

        //LISTING 1-4 Stopping a thread
        public void TopicStoppingThread(bool stopped)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            t.Join();
        }

        //LISTING 1-5 Using the ThreadStaticAttribute
        [ThreadStatic]
        public static int _filed_thread_static_attribut;

        public void TopicThreadStaticAttribute()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _filed_thread_static_attribut++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() => 
            {
                for (int x = 0; x < 10; x++)
                {
                    _filed_thread_static_attribut++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }


        //LISTING 1 - 6 Using ThreadLocal<T>
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        public void TopicThreadLocal()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();

            Console.ReadKey();
        }

        //Thread pools
        //LISTING 1-7 Queuing some work to the thread pool
        public void TopicQueuingSomeWorkTreadPool()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }

        //Using Tasks
        //LISTING 1-8 Starting a new Task
        public void StartingNewTask()
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write("*");
                }
            });

            t.Wait();
        }

        //Listing 1-9 Using a Task that returns a value
        public void  UsingTaskReturnValue()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            Console.Write(t.Result.ToString());
        }

        //LISTING 1-10 Adding a continuation
        public void AddingContinuation()
        {
            Task<int> t = Task.Run(() =>
            {

                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            
            Console.WriteLine(t.Result); //Display 84
            Console.ReadLine();
        }

        //LISTING 1-11 Scheduling different continuation tasks

    }
}
