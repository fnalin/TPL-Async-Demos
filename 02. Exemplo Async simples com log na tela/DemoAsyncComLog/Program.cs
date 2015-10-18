using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAsyncComLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o código...");
            //var tarefa = Task.Factory.StartNew<int>(OperacaoDemorada);
            //var tarefa = Task.Factory.StartNew(() => OperacaoDemorada(5));

            var tarefa = Task.Factory.StartNew((object x) =>
            {
                Thread.Sleep(2000);
                return (int)x * 2;
            }, 5);


            Task.Factory.StartNew((object myState) =>
            {
                var i = (int)myState;

                //Do calculations...
                var x = i + 10;
            }, 10);


            Console.WriteLine("Iniciando restando do código");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Resposta do método {0}", tarefa.Result);

            Console.WriteLine("Fim");
            Console.ReadLine();


        }

        private static int OperacaoDemorada(int x)
        {
            Thread.Sleep(3000);
            return x * 2;
        }
    }
}
