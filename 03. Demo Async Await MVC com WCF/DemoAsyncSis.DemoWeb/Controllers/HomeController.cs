using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoAsyncSis.DemoWeb.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [UseStopwatch]
        public ActionResult ObterDados() {

            var tempWS = new TempWS.TempServiceClient();
            var censWS = new CensoWS.CensoDemograficoServiceClient();

            ViewBag.uf = "SP";
            ViewBag.temp = tempWS.ObterTemperatura(TempWS.UF.SP).Temp.ToString("N2");
            ViewBag.pop = censWS.ObterTotalPopulacaoPorUF(CensoWS.UF.SP).Qtde.ToString();

            tempWS.Close();
            censWS.Close();

            return View();
        }


        [UseStopwatch]
        public async Task<ActionResult> ObterDadosAsync()
        {

            var tempWS = new TempWS.TempServiceClient();
            var censWS = new CensoWS.CensoDemograficoServiceClient();

            ViewBag.uf = "SP";
            //var temp = await tempWS.ObterTemperaturaAsync(TempWS.UF.SP);
            var temp = tempWS.ObterTemperaturaAsync(TempWS.UF.SP);
            var pop = censWS.ObterTotalPopulacaoPorUFAsync(CensoWS.UF.SP);

            await Task.WhenAll(temp,pop);

            ViewBag.temp = temp.Result.Temp.ToString("N2");
            ViewBag.pop = pop.Result.Qtde.ToString();

            tempWS.Close();
            censWS.Close();

            return View();
        }
    }
}