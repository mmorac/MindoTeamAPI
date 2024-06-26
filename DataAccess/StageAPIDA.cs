﻿using MindoTeamAPI.Modelos;

namespace MindoTeamAPI.DataAccess
{
    public class StageAPIDA
    {
        private readonly HotelDbContext _context = new HotelDbContext();
        public List<StageApi> obtenerTodas()
        {
            List<StageApi> stageApis = _context.StageApis.ToList();
            return stageApis;
        }

        public List<StageApi> obtenerOfertasPorFecha(string fecha)
        {
            List<StageApi> stageApis = _context.StageApis.Where(s => s.CheckIn == DateOnly.ParseExact(fecha, "yyyy-MM-dd")).ToList();
            return stageApis;
        }

        public List<StageApi> obtenerOfertasPorEstrellas(int estrellas)
        {
            List<StageApi> stageApis = _context.StageApis.Where(s => s.Estrellas == estrellas).ToList();
            List<HotelesRequerido> hotelesRequeridos = _context.HotelesRequeridos.Where(h => h.Estrellas == estrellas).ToList();
            List<string> idHotelesRequeridos = hotelesRequeridos.Select(hotel => hotel.IdHotel).ToList();
            stageApis = stageApis.Where(hotel => idHotelesRequeridos.Contains(hotel.IdHotel)).ToList();
            stageApis = stageApis.Where(hotel => hotel.Precio > 0).ToList();
            stageApis = stageApis.OrderBy(h => h.CheckIn).ThenBy(h => h.NombreHotel).ThenBy(h => h.Precio).ToList();
            return stageApis;
        }

        public Dictionary<string, float> obtenerPreciosPromedio(int estrellas)
        {
            List<HotelesRequerido> hotelesRequeridos = _context.HotelesRequeridos.Where(h => h.Estrellas == estrellas).ToList();
            Dictionary<string, float> promedios = new();
            List<StageApi> ofertas = new();
            foreach(HotelesRequerido h in hotelesRequeridos)
            {
                ofertas.AddRange(_context.StageApis.Where(o => o.IdHotel == h.IdHotel && o.Precio > 0).ToList());
            }

            var promediosPorFecha = ofertas
            .GroupBy(obj => obj.CheckIn)
            .Select(grupo => new
            {
                Fecha = grupo.Key,
                PrecioPromedio = grupo.Average(obj => obj.Precio)
            })
            .OrderBy(obj => obj.Fecha)
            .ToList();

            foreach(var obj in promediosPorFecha)
            {
                DateOnly fecha = (DateOnly)obj.Fecha;
                promedios.Add(fecha.ToString("yyyy-MM-dd"), (float)Math.Round(obj.PrecioPromedio, 2));
            }
            return promedios;
        }
    }
}