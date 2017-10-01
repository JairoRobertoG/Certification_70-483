using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
        public void UsingTaskReturnValue()
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
        public void SchedulingDufferentContinuationTask()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
                Console.ReadLine();
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Fauled");
                Console.ReadLine();
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
                Console.ReadLine();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

        }

        //LISTING 1-12 Attaching child tasks to a parent task
        public void AttachingChildTasksToParentTask()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                        Console.WriteLine(i);
                });

            Console.ReadLine();
            finalTask.Wait();
        }

        //LISTING 1-13 Using a TaskFactory
        public void UsingTaskFactory()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);
                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);
                return results;
            });
            var finalTask = parent.ContinueWith(
            parentTask => {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });

            Console.ReadLine();
            finalTask.Wait();
        }

        //LISTING 1-14 Using Task.WaitAll
        public void UsingTaskWaitAll()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Console.ReadLine();
            Task.WaitAll(tasks);
        }

        //LISTING 1-15 Using Task.WaitAny
        public void UsingTaskWaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];

                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);

                tasks = temp.ToArray();
            }

            Console.ReadLine();
        }

        //LISTING 1-16 Using Parallel.For and Parallel.Foreach
        public void UsingParallelForParallelForeach()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });
        }

        //LISTING 1-17 Using Parallel.Break
        public void UsingParallelBreak()
        {
            ParallelLoopResult result = Parallel.
            For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }

                Console.ReadLine();
                return;
            });
        }

        //LISTING 1-18 async and await
        public void AsyncAndAwait()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://learn-english-application.tk/");
                return result;
            }
        }

        //LISTING 1-19 Scalability versus responsiveness
        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }

        //LISTING 1-20 Using ConfigureAwait
        //Graphic Interface

        //LISTING 1-22 Using AsParallel
        public void UsingAsParallel()
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();
        }

        //LISTING 1-23 Unordered parallel query
        public void UnorderedPArallelQuery()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);

            Console.ReadLine();
        }

        //LISTING 1-24 Ordered parallel query
        public void OrderedParallelQuery()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0)
            .ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);

            Console.ReadLine();
        }

        //LISTING 1-25 Making a parallel query sequential
        public void MakingParallelQuerySecuential()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0).AsSequential();
            foreach (int i in parallelResult.Take(5))
                Console.WriteLine(i);

            Console.ReadLine();
        }

        //LISTING 1-26 Using ForAll
        public void UsingForAll()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0);
            parallelResult.ForAll(e => Console.WriteLine(e));

            Console.ReadLine();
        }

        //LISTING 1-27 Catching AggregateException
        private bool IsEven(int i)
        {
            if(i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }

        public void CatchingAggregateException()
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel()
                .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions",
                e.InnerExceptions.Count);
            }

        }

        //Using concurrent collections
        //LISTING 1-28 Using BlockingCollection<T>

    }
}
