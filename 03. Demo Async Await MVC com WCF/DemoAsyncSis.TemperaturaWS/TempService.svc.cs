using System;
using System.Threading;

namespace DemoAsyncSis.TemperaturaWS
{
    public class TempService : ITempService
    {

        public Temperatura ObterTemperatura(UF uf)
        {
            Thread.Sleep(3000);

            var temp = new Temperatura { UF = uf };
            switch (uf)
            {
                case UF.SP:
                    temp.Temp = ObterRandom(30, 35);
                    break;
                case UF.RJ:
                    temp.Temp = ObterRandom(38, 42);
                    break;
                case UF.MG:
                    temp.Temp = ObterRandom(35, 40);
                    break;
                case UF.AM:
                    temp.Temp = ObterRandom(30, 40);
                    break;
            }

            return temp;
        }

        private double ObterRandom(int min, int max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
