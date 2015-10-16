using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAsyncSimples
{
    class Program
    {
        static void Main(string[] args)
        {
            //chama o método usando a mesma thread
            var task = SlowOperation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //Console.WriteLine("Slow operation result: {0}", result);
            //aguarda aqui o resultado da outra thread
            Console.WriteLine("Slow operation result: {0}", task.Result);
            Console.WriteLine("Main complete on {0}",
                Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }

        private static async Task<int> SlowOperation()
        {
            Console.WriteLine("Slow Operation started on {0}",
                Thread.CurrentThread.ManagedThreadId);

            //inicia uma nova thread aqui e continua
            await Task.Delay(3000);

            Console.WriteLine("Slow operation complete on {0}",
                Thread.CurrentThread.ManagedThreadId);

            return 10;
        }
    }
}
