using System.ServiceModel;

namespace DemoAsyncSis.TemperaturaWS
{
    [ServiceContract]
    public interface ITempService
    {
        [OperationContract]
        Temperatura ObterTemperatura(UF uf);
    }
}
