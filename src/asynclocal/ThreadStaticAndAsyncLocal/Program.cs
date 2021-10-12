using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStaticAndAsyncLocal
{
    class Program
    {
        //[ThreadStatic]
        //static string _threadStaticValue = "_threadStaticValue";

        //static AsyncLocal<string> _asyncLocalValue = new AsyncLocal<string>();
        //static void Main(string[] args)
        //{
        //    for (int i = 1; i < 2; i++)
        //    {
        //        int loopValue = i;
        //        Task.Run(async () =>
        //        {
        //            _threadStaticValue = $"zack{loopValue}";

        //            _asyncLocalValue.Value = $"zack{loopValue}";

        //            Console.WriteLine($"LoopValue:{loopValue},ThreadId:{Thread.CurrentThread.ManagedThreadId},ThreadStaticValue:{_threadStaticValue}");

        //            Console.WriteLine($"LoopValue:{loopValue},ThreadId:{Thread.CurrentThread.ManagedThreadId},AsyncLocalValue:{_asyncLocalValue.Value}");

        //            await Task.Yield();

        //            await Task.Run(() =>
        //            {
        //                Console.WriteLine($"LoopValue:{loopValue},Other Task ThreadId:{Thread.CurrentThread.ManagedThreadId},ThreadStaticValue:{_threadStaticValue}");

        //                Console.WriteLine($"LoopValue:{loopValue},Other Task ThreadId:{Thread.CurrentThread.ManagedThreadId},AsyncLocalValue:{_asyncLocalValue.Value}");
        //            });
        //        });
        //    }

        //    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        //}

        [ThreadStatic]
        static string _threadStaticValue = "_threadStaticValue";
        static AsyncLocal<string> _asyncLocalValue = new AsyncLocal<string>();
        static void Main(string[] args)
        {
            //Task.Run(async () =>
            //{
            //    _threadStaticValue = $"zack2021";

            //    Console.WriteLine($"ThreadId:{Thread.CurrentThread.ManagedThreadId},ThreadStaticValue:{_threadStaticValue}");

            //    await Task.Run(async() =>
            //    {
            //        await Task.Yield();
            //        Console.WriteLine($"Other ThreadId:{Thread.CurrentThread.ManagedThreadId},ThreadStaticValue:{_threadStaticValue}");
            //    });
            //});

            Task.Run(async () =>
            {
                _asyncLocalValue.Value = $"zack2021";

                Console.WriteLine($"ThreadId:{Thread.CurrentThread.ManagedThreadId},AsyncLocalValue:{_asyncLocalValue.Value}");

                await Task.Run(async () =>
                {
                    await Task.Yield();
                    Console.WriteLine($"Other ThreadId:{Thread.CurrentThread.ManagedThreadId},AsyncLocalValue:{_asyncLocalValue.Value}");
                });
            });

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        }
    }
}
