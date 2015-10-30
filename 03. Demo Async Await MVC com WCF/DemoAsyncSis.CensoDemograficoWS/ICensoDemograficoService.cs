using System.ServiceModel;

namespace DemoAsyncSis.CensoDemograficoWS
{
    [ServiceContract]
    public interface ICensoDemograficoService
    {
        [OperationContract]
        Populacao ObterTotalPopulacaoPorUF(UF uf);
    }
}
