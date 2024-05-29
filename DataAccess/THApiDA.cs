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

            /*
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
            */

            var ofertas = from thApi in thApis
                          join medapiHotel in hoteles on thApi.IdHotel equals medapiHotel.IdHotel
                          join fecha in fechas on thApi.IdCheckIn equals fecha.IdCheckIn
                          group new { thApi, medapiHotel, fecha } by new { thApi.IdHotel, medapiHotel.Hotel, fecha.CheckIn } into g
                          let minPrice = g.Min(x => x.thApi.Precio)
                          from minOffer in g
                          where minOffer.thApi.Precio == minPrice
                          orderby minOffer.medapiHotel.Hotel, minOffer.fecha.CheckIn
                          select new
                          {
                              Nombre_Hotel = minOffer.medapiHotel.Hotel,
                              Fecha = minOffer.fecha.CheckIn,
                              Precio = minOffer.thApi.Precio
                          };
            
            IEnumerable<object> resultado = ofertas.ToList<object>();
            return resultado;
        }

        public Dictionary<string, float> obtenerPreciosPromedio(int estrellas)
        {
            List<HotelesRequerido> hotelesRequeridos = _context.HotelesRequeridos.Where(h => h.Estrellas == estrellas).ToList();
            Dictionary<string, float> promedios = new();
            List<ThApi> ofertas = new();
            foreach (HotelesRequerido h in hotelesRequeridos)
            {
                ofertas.AddRange(_context.ThApis.Where(o => o.IdHotel == h.IdHotel && o.Precio > 0).ToList());
            }

            List<MeDApiCheckIn> meDApiCheckIns = _context.MeDApiCheckIns.ToList();

            var preciosPromedio = ofertas.Join(meDApiCheckIns,
                                     oferta => oferta.IdCheckIn,
                                     meDApiCheckIn => meDApiCheckIn.IdCheckIn,
                                     (oferta, meDApiCheckIn) => new { oferta, meDApiCheckIn.CheckIn })
                               .GroupBy(x => x.CheckIn)
                               .Select(g => new
                               {
                                   Fecha = g.Key,
                                   PrecioPromedio = g.Average(x => x.oferta.Precio)
                               }).ToList();

            foreach (var obj in preciosPromedio)
            {
                DateOnly fecha = (DateOnly)obj.Fecha;
                promedios.Add(fecha.ToString("yyyy-MM-dd"), (float)Math.Round((decimal)obj.PrecioPromedio, 2));
            }

            promedios = promedios.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
            return promedios;

        }

    }
}
