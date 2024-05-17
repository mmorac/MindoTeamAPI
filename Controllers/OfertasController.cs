
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
        public List<PruebasApi> obtenerTodos()
        {
            return pruebasAPIDA.obtenerTodos();
        }

        [HttpGet]
        [Route("/ofertas/{id}")]
        public PruebasApi obtenerPrueba(int id)
        {
            return pruebasAPIDA.obtenerPrueba(id);
        }

        [HttpPost]
        [Route("/ofertas/estrellas")]
        public List<PruebasApi> obtenerPruebasPorEstrella(int estrellas)
        {
            return pruebasAPIDA.obtenerOfertasPorEstrellas(estrellas);
        }

        [HttpPost]
        [Route("/ofertas/hotel")]
        public List<PruebasApi> obtenerPruebasPorHotel(string Hotel)
        {
            return pruebasAPIDA.obtenerOfertasPorHotel(Hotel);
        }

        [HttpPost]
        [Route("/ofertas/promedio")]
        public Dictionary<string, float> obtenerPreciosPromedio(List<string> hoteles)
        {
            return stageAPIDA.obtenerPreciosPromedio(hoteles);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
