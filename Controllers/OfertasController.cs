using Microsoft.AspNetCore.Mvc;
using MindoTeamAPI.DataAccess;
using MindoTeamAPI.Modelos;

namespace MindoTeamAPI.Controllers
{
    public class OfertasController : Controller
    {
        private readonly PruebasAPIDA pruebasAPIDA = new PruebasAPIDA();

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
