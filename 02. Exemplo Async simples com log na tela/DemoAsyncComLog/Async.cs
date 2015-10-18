using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAsyncComLog
{
    class Async
    {


        static void Main()
        {

            Console.WriteLine("--> início do método Main -  ID da Thread atual: {0}", Thread.CurrentThread.ManagedThreadId);

            var task = OperacaoAsync();

            Console.WriteLine("\n--> estou no método Main antes do for -  ID da Thread atual: {0}\n", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("... " + i);
            }


            Console.WriteLine("\n\n--> estou no método Main após o for - ID da Thread atual: {0}",  Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("\nResposta da operação: " + task.Result);
            Console.WriteLine("\n--> estou no método Main após o resultado da task - ID da Thread atual: {0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("\nFim, pressione Enter");
            Console.ReadLine();
        }

        private static async Task<int> OperacaoAsync()
        {
            Console.WriteLine("\n--> início da operacaoasync - ID da Thread atual: {0}", Thread.CurrentThread.ManagedThreadId);
            //await Task.Delay(2000);

            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("\n--> dentro da operacaoasync em task.run - ID da Thread atual: {0}", Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("\n--> fim da operacaoasync antes do return - ID da Thread atual: {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
    }
}
