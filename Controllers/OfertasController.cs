using Microsoft.AspNetCore.Mvc;
using MindoTeamAPI.DataAccess;
using MindoTeamAPI.Modelos;

namespace MindoTeamAPI.Controllers
{
    public class OfertasController : Controller
    {
        private readonly PruebasAPIDA pruebasAPIDA = new PruebasAPIDA();
        private readonly StageAPIDA stageAPIDA = new();
        private readonly THApiDA tHApiDA = new();

        [HttpGet]
        [Route("/ofertas")]
        public List<StageApi> obtenerTodas()
        {
            return stageAPIDA.obtenerTodas();
        }

        [HttpPost]
        [Route("/ofertas/fecha")]
        public List<StageApi> obtenerOfertasPorFecha([FromBody] string fecha)
        {
            return stageAPIDA.obtenerOfertasPorFecha(fecha);
        }

        [HttpPost]
        [Route("/ofertas/estrellas")]
        public IEnumerable<object> obtenerPruebasPorEstrella([FromBody]int estrellas)
        {
            return tHApiDA.obtenerOfertasPorEstrellas(estrellas);
        }


        [HttpPost]
        [Route("/ofertas/promedios")]
        public Dictionary<string, float> obtenerPreciosPromedio([FromBody]int estrellas)
        {
            return stageAPIDA.obtenerPreciosPromedio(estrellas);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}