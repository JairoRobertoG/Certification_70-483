using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Certification.Classes;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;

namespace Certification.Chapters.Objective_1
{
    public class ManageProgramFlow
    {
        public ManageProgramFlow()
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
            parentTask =>
            {
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

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
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
            if (i % 10 == 0) throw new ArgumentException("i");
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
        public void UsingBlockingCollection()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();

        }

        //LISTING 1-29 Using GetConsumingEnumerable on a BlockingCollection
        public void UsingGetConsumingEnumerableOnBlockingCollection()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (string v in col.GetConsumingEnumerable())
                    Console.WriteLine(v);
            });

        }

        //LISTING 1-30 Using a ConcurrentBag
        public void UsingConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);

            Console.ReadLine();
        }

        //LISTING 1-31 Enumerating a ConcurrentBag
        public void EnumeratingConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();
        }

        //LISTING 1-32 Using a ConcurrentStack
        public void UsingConcurrentStack()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);
            int result;

            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);

            stack.PushRange(new int[] { 1, 2, 3 });
            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (int i in values)
                Console.WriteLine(i);

            Console.ReadLine();
        }

        //LISTING 1-33 Using a ConcurrentQueue.
        public void UsingConcurrentQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);
            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine("Dequeued: {0}", result);

            Console.ReadLine();
        }

        //LISTING 1-34 Using a ConcurrentDictionary
        public void UsingConcurrentDictionary()
        {
            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }
            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }
            dict["k1"] = 42; // Overwrite unconditionally
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3);

            Console.ReadLine();
        }

        //Objective 1.2: Manage multithreading
        //LISTING 1-35 Accessing shared data in a multithreaded application
        public void AccessingSharedDataInMultithreadedApplication()
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    n++;
            });

            for (int i = 0; i < 1000000; i++)
                n--;

            up.Wait();
            Console.WriteLine(n);
            Console.ReadLine();
        }

        //LISTING 1-36 Using the lock keyword
        public void UsingLockKeyword()
        {
            int n = 0;
            object _lock = new object();
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    lock (_lock)
                        n++;
            });

            for (int i = 0; i < 1000000; i++)
                lock (_lock)
                    n--;
            up.Wait();
            Console.WriteLine(n);

            Console.ReadLine();
        }

        //LISTING 1-37 Creating a deadlock
        public void CreatingDeadlock()
        {
            object lockA = new object();
            object lockB = new object();
            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });
            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked A and B");
                }
            }
            up.Wait();
        }

        //LISTING 1-38 Generated code from a lock statement
        public void GeneretedCodeFromLockStatment()
        {
            object gate = new object();
            bool __lockTaken = false;
            try
            {
                Monitor.Enter(gate, ref __lockTaken);
            }
            finally
            {
                if (__lockTaken)
                    Monitor.Exit(gate);
            }
        }

        //Volatile class
        //LISTING 1-39 A potential problem with multithreaded code
        private int _flag = 0;
        private volatile int _value = 0;

        public void Thread1()
        {
            _value = 5;
            _flag = 1;
        }
        public void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);
        }

        public void PotencialProblemWithMultithreadedCode()
        {
            Thread1();
            Thread2();
        }

        //The Interlocked class
        //LISTING 1-40 Using the Interlocked class
        public void UsingInterlockedClass()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });
            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);
            up.Wait();
            Console.WriteLine(n);

            Console.ReadLine();
        }

        //LISTING 1-41 Compare and exchange as a nonatomic operation
        public void CompareExchangeAsNonatomicOperation()
        {
            int value = 1;
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output
                    Thread.Sleep(1000);
                    value = 2;

                }
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
            Console.ReadLine();
        }

        //LISTING 1-42 Using a CancellationToken
        public void UsingCacellationToken()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }

        //LISTING 1-43 Throwing OperationCanceledException
        public void ThrowingOperationCanceledException()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token);
            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();
                cancellationTokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }
            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }

        //LISTING 1-44 Adding a continuation for canceled tasks
        public void AddingContinuationCanceledTask()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token).ContinueWith((t) =>
            {
                t.Exception.Handle((e) => true);
                Console.WriteLine("You have canceled the task");
            }, TaskContinuationOptions.OnlyOnCanceled);
        }

        //LISTING 1-45 Setting a timeout on a task
        public void SettingTimeoutTask()
        {
            Task longRunning = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            int index = Task.WaitAny(new[] { longRunning }, 1000);
            if (index == -1)
                Console.WriteLine("Task timed out");
        }

        //Objective 1.3: Implement program flow
        //Working with Boolean expressions
        //LISTING 1-46 A better readable nested if statement
        public void BetterReadableNestedIfStatement()
        {
            int x = 42;
            int y = 1;
            int z = 42;
            Console.WriteLine(x == y); // Displays false
            Console.WriteLine(x == z); // Displays true
        }

        //LISTING 1-47 Boolean OR operator
        public void BooleanOrOperator()
        {
            bool x = true;
            bool y = false;
            bool result = x || y;
            Console.WriteLine(result); // Displays True
        }

        //LISTING 1-48 Short-circuiting the OR operator
        private bool GetY()
        {
            Console.WriteLine("This method doesn’t get called");
            return true;
        }

        public void OrShortCircuit()
        {
            bool x = true;
            bool result = x || GetY();
        }

        //LISTING 1-49 Using the AND operator
        public void UsingAndOperator()
        {
            int value = 42;
            bool result = (0 < value) && (value < 100);
        }

        //LISTING 1-50 Using the AND operator
        public void UsingAndOperator(string input)
        {
            bool result = (input != null) && (input.StartsWith("v"));
            // Do something with the result
        }

        //LISTING 1-51 Using the XOR operator
        public void UsingXOROperator()
        {
            bool a = true;
            bool b = false;
            Console.WriteLine(a ^ a); // False
            Console.WriteLine(a ^ b); // True
            Console.WriteLine(b ^ b); // False
        }

        //LISTING 1-52 Basic if statement
        public void BasicIfStatement()
        {
            bool b = true;
            if (b)
                Console.WriteLine("True");
        }

        //LISTING 1-53 An if statement with code block
        public void IfStatementWithCodeBlock()
        {
            bool b = true;
            if (b)
            {
                Console.WriteLine("Both these lines");
                Console.WriteLine("Will be executed");
            }
        }

        //LISTING 1-54 Code blocks and scoping
        public void CodeBlocksAndScoping()
        {
            bool b = true;
            if (b)
            {
                int r = 42;
                b = false;
            }
            // r is not accessible
            // b is now false
        }

        //LISTING 1-55 Using an else statement
        public void UsingAnElseStatement()
        {
            bool b = false;
            if (b)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        //LISTING 1-56 Using multiple if/else statements
        public void UsingMultipleIfElseStatements()
        {
            bool b = false;
            bool c = true;
            if (b)
            {
                Console.WriteLine("b is true");
            }
            else if (c)
            {
                Console.WriteLine("c is true");
            }
            else
            {
                Console.WriteLine("b and c are false");
            }
        }

        //LISTING 1-57 A more readable nested if statement
        public void AMoreReadableNestedIfStatement()
        {
            //if (x)
            //{
            //    if (y)
            //    {
            //        F();
            //    }
            //    else
            //    {
            //        G();
            //    }
            //}
        }

        //LISTING 1-58 The null-coalescing operator
        public void TheNullCoalescingOperator()
        {
            int? x = null;
            int y = x ?? -1;
        }

        //LISTING 1-59 Nesting the null-coalescing operator
        public void NestingTheNullCoalescingOperator()
        {
            int? x = null;
            int? z = null;
            int y = x ??
            z ??
            -1;
        }

        //The conditional operator
        //LISTING 1-60 The conditional operator
        public int TheConditionalOperator(bool p)
        {
            if (p)
                return 1;
            else
                return 0;

            return p ? 1 : 0;
        }

        //LISTING 1-61 A complex if statement
        public void AComplexIfStatement(char input)
        {
            if (input == 'a'
                || input == 'e'
                || input == 'i'
                || input == 'o'
                || input == 'u')
            {
                Console.WriteLine("Input is a vowel");
            }
            else
            {
                Console.WriteLine("Input is a consonant");
            }
        }

        //LISTING 1-62 A switch statement
        public void ASwichStatement(char input)
        {
            switch (input)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    {
                        Console.WriteLine("Input is a vowel");
                        break;
                    }
                case 'y':
                    {
                        Console.WriteLine("Input is sometimes a vowel.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Input is a consonant");
                        break;
                    }
            }
        }

        //LISTING 1-63 goto in a switch statement
        public void GotoInSwitchStatement()
        {
            int i = 1;
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine("Case 1");
                        goto case 2;
                    }
                case 2:
                    {
                        Console.WriteLine("Case 2");
                        break;
                    }
            }
        }

        //The for loop
        //LISTING 1-64 A basic for loop
        public void ABasicForLoop()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index++)
            {
                Console.Write(values[index]);
            }
        }

        //LISTING 1-65 A for loop with multiple loop variables
        public void AForLoopWithMultipleLoopVariables()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };

            for (int x = 0, y = values.Length - 1;
            ((x < values.Length) && (y >= 0));
            x++, y--)
            {
                Console.Write(values[x]);
                Console.Write(values[y]);
            }
        }

        //LISTING 1-66 A for loop with a custom increment
        public void AForLoopWithACustomIncrement()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index += 2)
            {
                Console.Write(values[index]);
            }

            Console.ReadLine();
        }

        //LISTING 1-67 A for loop with a break statement
        public void AForLoopWithABreakStatement()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] == 4) break;

                Console.Write(values[index]);
            }

            Console.ReadLine();
        }

        //LISTING 1-68 A for loop with a continue statement
        public void AForLoopWithAContinueStatement()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] == 4) continue;
                Console.Write(values[index]);
            }

            Console.ReadLine();
        }

        //LISTING 1-69 A for loop with a continue statement
        public void AForLoopWithAContinueStatementWhile()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            {
                int index = 0;
                while (index < values.Length)
                {
                    Console.Write(values[index]);
                    index++;
                }
            }
        }

        //LISTING 1-70 do-while loop
        public void DoWhileLoop()
        {
            do
            {
                Console.WriteLine("Executed once!");
            }

            while (false);

            Console.ReadLine();
        }

        //LISTING 1-71 foreach loop
        public void ForeachLoop()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };

            foreach (int i in values)
            {
                Console.Write(i);
            }
            Console.ReadLine();
        }

        //LISTING 1-72 Changing items in a foreach
        void CannotChangeForeachIterationVariable()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName = "Doe"},
                new Person() { FirstName = "Jane", LastName = "Doe"},
            };
            foreach (Person p in people)
            {
                p.LastName = "Changed"; // This is allowed
                                        // p = new Person(); // This gives a compile error
            }
        }

        public void ChangingItemsInForeach()
        {
            CannotChangeForeachIterationVariable();
        }

        //LISTING 1-73 The compiler-generated code for a foreach loop
        public void CompilerGeneratedCodeForForeachLoop()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName = "Doe"},
                new Person() { FirstName = "Jane", LastName = "Doe"},
            };

            List<Person>.Enumerator e = people.GetEnumerator();
            try
            {
                Person v;
                while (e.MoveNext())
                {
                    v = e.Current;
                }
            }
            finally
            {
                IDisposable d = e as System.IDisposable;
                if (d != null) d.Dispose();
            }
        }

        //LISTING 1-74 goto statement with a label
        public void GotoStatementWithLabel()
        {
            int x = 3;
            if (x == 3) goto customLabel;

            x++;
            customLabel:
            Console.WriteLine(x);

        }

        //LISTING 1-75 Using a delegate
        public delegate int Calculate(int x, int y);
        public int Add(int x, int y) { return x + y; }
        public int Multiply(int x, int y) { return x * y; }

        void UseDelegate()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4)); // Displays 7
            calc = Multiply;
            Console.WriteLine(calc(3, 4)); // Displays 12

            Console.ReadLine();
        }

        public void UsingDelegate()
        {
            UseDelegate();
        }

        //LISTING 1-76 A multicast delegate
        void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }
        void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }

        delegate void Dele();

        void Multicast()
        {
            Dele d = MethodOne;
            d += MethodTwo;
            d();
            Console.ReadLine();
        }

        public void Multicastelegate()
        {
            Multicast();
        }

        //LISTING 1-77 Covariance with delegates
        delegate TextWriter CovarianceDel();
        StreamWriter MethodStream() { return null; }
        StringWriter MethodString() { return null; }

        public void CovarianceWithDelegates()
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }

        //LISTING 1-78 Contravariance with delegates
        void DoSomething(TextWriter tw) { }

        delegate void ContravarianceDel(StreamWriter tw);

        public void ContravarianceWithDelegates()
        {
            ContravarianceDel del = DoSomething;
        }

        //Using lambda expressions
        //LISTING 1-79 Lambda expression to create a delegate
        public void LambdaExpressions()
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4)); // Displays 7
            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4)); // Displays 12
            Console.ReadLine();
        }

        //LISTING 1-80 Creating a lambda expression with multiple statements
        public void CreatingLambdaExpressionWithMultipleStatements()
        {
            Calculate calc =
                (x, y) =>
                {
                    Console.WriteLine("Adding numbers");
                    return x + y;
                };
            int result = calc(3, 4);
        }

        //LISTING 1-81 Using the Action delegate
        public void UsingActionDelegate()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };
            calc(3, 4); // Displays 7
        }

        //Using events
        //LISTING 1-82 Using an Action to expose an event
        public void UsingActionExposeAnEvent()
        {
            //Pub p = new Pub();
            //p.OnChange += () => Console.WriteLine("Event raised to method 1");
            //p.OnChange += () => Console.WriteLine("Event raised to method 2");
            //p.OnChange += () => Console.ReadLine();
            //p.Raise();
        }

        //LISTING 1-83 Using the event keyword
        public void UsingEventKeyword()
        {
            //Pub p = new Pub();
            //p.OnChange += () => Console.WriteLine("Event raised to method 1");
            //p.OnChange += () => Console.WriteLine("Event raised to method 2");
            //p.OnChange += () => Console.ReadLine();
            //p.Raise();
        }

        //LISTING 1-84 Custom event arguments
        public void CustomEventArguments()
        {
            //Pub p = new Pub();
            //p.OnChange += (sender, e)
            //=> Console.WriteLine("Event raised: {0}", e.Value);
            //p.OnChange += (sender, e)
            //=> Console.ReadLine();
            //p.Raise();
        }

        //LISTING 1-85 Custom event accessor
        public void CustomEventAccessor()
        {
            Pub b = new Pub();
            b.Raise();
        }

        //LISTING 1-86 Exception when raising an event
        public void ExceptionWhenRaisingAnEvent()
        {
            Pub p = new Pub();
            p.OnChange += (sender, e)
            => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e)
            =>
            { throw new Exception(); };
            p.OnChange += (sender, e)
            => Console.WriteLine("Subscriber 3 called");
            p.Raise();
        }

        //LISTING 1-87 Manually raising events with exception handling
        public void ManuallyRaisingEventsWithExceptionHandling()
        {
            Pub p = new Pub();
            p.OnChange += (sender, e)
            => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e)
            =>
            { throw new Exception(); };
            p.OnChange += (sender, e)
            => Console.WriteLine("Subscriber 3 called");
            p.OnChange += (sender, e)
            => Console.ReadLine();
            try
            {
                p.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }

        //LISTING 1-88 Parsing an invalid number
        public void ParsingAnInvalidNumber()
        {
            string s = "NaN";
            int i = int.Parse(s);
        }

        //LISTING 1-89 Catching a FormatException
        public void CatchingFormatException()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) break;
                try
                {
                    int i = int.Parse(s);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not a valid number.Please try again", s);
                }
            }
        }

        //LISTING 1-90 Catching different exception types
        public void CatchingDifferentExceptionTypes()
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You need to enter a value");
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not a valid number.Please try again", s);
            }
            Console.ReadLine();
        }

        //LISTING 1-91 Using a finally block
        public void UsingFinallyBlock()
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You need to enter a value");
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not a valid number.Please try again", s);
            }
            finally
            {
                Console.WriteLine("Program complete.");
                Console.ReadLine();
            }
        }

        //LISTING 1-92 Using Environment.FailFast
        public void UsingEnviromentFailFast()
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
                if (i == 42) Environment.FailFast("Special number entered");
            }
            finally
            {
                Console.WriteLine("Program complete.");
                Console.ReadLine();
            }
        }

        //LISTING 1-93 Inspecting an exception
        static int ReadAndParse()
        {
            string s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }

        public void InspectingAnexception()
        {
            try
            {
                int i = ReadAndParse();
                Console.WriteLine("Parsed: {0}", i);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("StackTrace: {0}", e.StackTrace);
                Console.WriteLine("HelpLink: {0}", e.HelpLink);
                Console.WriteLine("InnerException: {0}", e.InnerException);
                Console.WriteLine("TargetSite: {0}", e.TargetSite);
                Console.WriteLine("Source: {0}", e.Source);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        //Throwing exceptions
        //LISTING 1-94 Throwing an ArgumentNullException
        string OpenAndParse(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("fileName", "Filename is required");
            return File.ReadAllText(fileName);
        }

        public void ThrowingAnArgumentNullException()
        {
            Console.WriteLine(OpenAndParse("example.txt"));
        }

        //LISTING 1-95 Rethrowing an exception
        public void RethrowingAnException()
        {
            //try
            //{
            //    ReadAndParse();
            //}
            //catch (Exception logEx)
            //{
            //    //Log(logEx);
            //    throw; // rethrow the original exception
            //}
        }

        //LISTING 1-96 Throwing a new exception that points to the original one
        public void ThrowingNewExceptionThatPointsToTheOriginalOne()
        {
            //try
            //{
            //    ProcessOrder();
            //}
            //catch (MessageQueueException ex)
            //{
            //    throw new OrderProcessingException("Error while processing order", ex);
            //}
        }

        //LISTING 1-97 Using ExceptionDispatchInfo.Throw
        public void UsingExceptionDispatchInfoThrow()
        {
            ExceptionDispatchInfo possibleException = null;
            try
            {
                Console.Write("Enter weekly cost: ");
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }
            if (possibleException != null)
            {
                possibleException.Throw();
            }
            Console.ReadLine();
        }

        //LISTING 1-98 Creating a custom exception
        public void CreatingCustomException()
        {
            OrderProcessingException orderrocessingException = new OrderProcessingException(1);
        }
    }
}
