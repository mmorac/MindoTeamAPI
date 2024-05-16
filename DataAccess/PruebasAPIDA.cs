using MindoTeamAPI.Modelos;

namespace MindoTeamAPI.DataAccess
{
    public class PruebasAPIDA
    {
        private HotelDbContext context = new HotelDbContext();
        public List<PruebasApi> obtenerTodos()
        {
            List<PruebasApi> pruebasApi = new List<PruebasApi>();

            try
            {
                pruebasApi = context.PruebasApis.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return pruebasApi;
        }

        public PruebasApi obtenerPrueba(int id)
        {
            try
            {
                PruebasApi prueba = context.PruebasApis.FirstOrDefault(p => p.Id == id);
                return prueba;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PruebasApi> obtenerOfertasPorEstrellas(int estrellas)
        {
            try
            {
                List<PruebasApi> pruebas = context.PruebasApis.Where(p => p.Estrellas == estrellas).ToList();
                return pruebas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PruebasApi> obtenerOfertasPorHotel(string Hotel)
        {
            List<PruebasApi> pruebasApis = new List<PruebasApi>();
            try
            {
                pruebasApis = context.PruebasApis.Where(p => p.NombreHotel.Equals(Hotel)).ToList();
                return pruebasApis;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
