using Microsoft.AspNetCore.Mvc;
using MindoTeamAPI.DataAccess;
using MindoTeamAPI.Modelos;

namespace MindoTeamAPI.Controllers
{
    public class OfertasController : Controller
    {
        private readonly PruebasAPIDA pruebasAPIDA = new PruebasAPIDA();
        private readonly StageAPIDA stageAPIDA = new();

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
        public List<StageApi> obtenerPruebasPorEstrella([FromBody]int estrellas)
        {
            return stageAPIDA.obtenerOfertasPorEstrellas(estrellas);
        }


        [HttpPost]
        [Route("/ofertas/promedios")]
        public Dictionary<string, float> obtenerPreciosPromedio([FromBody]List<string> hoteles)
        {
            return stageAPIDA.obtenerPreciosPromedio(hoteles);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}