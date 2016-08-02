using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPLBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskSimples();
            //TaskRetornandoValores();
            //TaskExecutadaAposAOutra();
            //TaskExecutadaAposAOutraComParams();
            //TaskComTarefaFilha();
            //TaskWaitAll();
            WaitAny();

        }

        private static void WaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 1;

            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 3;
            }
            );

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }

            Console.WriteLine("Fim");
            Console.ReadKey();
        }

        private static void TaskWaitAll()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine('1');

                return 1;

            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine('2');
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine('3');
                return 3;
            }
            );

            Task.WaitAll(tasks);

            Console.WriteLine("Fim");
            Console.ReadKey();

        }

        private static void TaskComTarefaFilha()
        {
            Task<Int32[]> Pai = Task.Run(() =>
            {
                var results = new Int32[3];

                new Task(() => { results[0] = 10; }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 20, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 30, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            var finalTask = Pai.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });


            finalTask.Wait();

            Console.ReadKey();
        }

        private static void TaskExecutadaAposAOutraComParams()
        {
            Task<int> t = Task.Run(() =>
            {
                return 10;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Cancelado");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Erro");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Finalizado");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

            Console.ReadKey();
        }

        private static void TaskExecutadaAposAOutra()
        {
            Task<int> T = Task.Run(() => {
                Thread.Sleep(2000);
                return 10;
            });

            Task<int> T2 = T.ContinueWith((i) => {
                //Tarefa2(T.Result)
                return T.Result * 2;
                });

            Console.WriteLine(T.Result);
            Console.WriteLine(T2.Result);

            Console.ReadKey();
        }

        private static void TaskRetornandoValores()
        {
            Task<string> T = Task.Run(() => {
                Thread.Sleep(1000);
                return "Retorno da tarefa";
            });
            T.Wait();
            Console.WriteLine("Antes");
            Console.WriteLine(T.Result);
            Console.WriteLine("Depois");
            Console.ReadKey();
        }

        private static void TaskSimples()
        {
            Task T = Task.Run(() => Tarefa());
            //T.Wait(); //Alterne com e sem para ver a diferença
            Console.WriteLine("Fim!");
            Console.ReadKey();
        }

        private static void Tarefa()
        {
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine($"Tarefa : {x}");
            }
        }
    }
}
