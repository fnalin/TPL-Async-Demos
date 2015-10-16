using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoTPLSimples
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = SlowOperation();
            //inicia em uma nova thread o método e continua na atual
            var task = Task.Factory.StartNew<int>(SlowOperation);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //Console.WriteLine("Slow operation result: {0}", result);
            //devido ao task.result, ele aguarda aqui p resultado da thread
            Console.WriteLine("Slow operation result: {0}", task.Result);
            Console.WriteLine("Main complete on {0}", 
                Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();

        }

        private static int SlowOperation()
        {
            Console.WriteLine("Slow Operation started on {0}",
                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(3000);

            Console.WriteLine("Slow operation complete on {0}",
                Thread.CurrentThread.ManagedThreadId);

            return 10;
        }
    }
}
