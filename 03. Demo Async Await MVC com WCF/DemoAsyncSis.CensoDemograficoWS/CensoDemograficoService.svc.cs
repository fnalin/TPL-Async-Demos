using System.Threading;

namespace DemoAsyncSis.CensoDemograficoWS
{
    public class CensoDemograficoService : ICensoDemograficoService
    {
        public Populacao ObterTotalPopulacaoPorUF(UF uf)
        {
            Thread.Sleep(3000);

            var populacao = new Populacao { UF = uf };

            switch (uf)
            {
                case UF.SP:
                    populacao.Qtde = 41252160;
                    break;
                case UF.RJ:
                    populacao.Qtde = 15993583;
                    break;
                case UF.MG:
                    populacao.Qtde = 19595309;
                    break;
                case UF.AM:
                    populacao.Qtde = 3480937;
                    break;
            }

            return populacao;
        }
    }
}
