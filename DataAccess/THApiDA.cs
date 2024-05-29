using MindoTeamAPI.Modelos;

namespace MindoTeamAPI.DataAccess
{
    public class THApiDA
    {
        private readonly HotelDbContext _context = new();

        public IEnumerable<object> obtenerOfertasPorEstrellas(int estrellas)
        {
            List<ThApi> thApis = _context.ThApis.Where(th => th.Estrella == estrellas && _context.HotelesRequeridos
                                    .Where(h => h.Estrellas == estrellas)
                                    .Select(hotel => hotel.IdHotel)
                                    .Contains(th.IdHotel))
                                .ToList();

            List<string> idHoteles = thApis.Select(hotel => hotel.IdHotel).ToList();
            List<MeDApiHotel> hoteles = _context.MeDApiHotels.Where(h => idHoteles.Contains(h.IdHotel)).ToList();

            List<int?> idCheckIns = thApis.Select(hotel => hotel.IdCheckIn).ToList();
            List<MeDApiCheckIn> fechas = _context.MeDApiCheckIns.Where(h => idCheckIns.Contains(h.IdCheckIn)).ToList();

            var ofertas = from thApi in thApis
                          join medapiHotel in hoteles on thApi.IdHotel equals medapiHotel.IdHotel
                          join fecha in fechas on thApi.IdCheckIn equals fecha.IdCheckIn
                          orderby medapiHotel.Hotel, fecha.CheckIn
                          select new
                          {
                              Nombre_Hotel = medapiHotel.Hotel,
                              Fecha = fecha.CheckIn,
                              Precio = thApi.Precio
                          };


            IEnumerable<object> resultado = ofertas.ToList<object>();
            return resultado;
        }

    }
}
