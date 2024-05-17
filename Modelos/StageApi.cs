using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class StageApi
{
    public string? IdHotel { get; set; }

    public string? NombreHotel { get; set; }

    public int? Estrellas { get; set; }

    public string? IdHabitacion { get; set; }

    public string? Habitacion { get; set; }

    public double Precio { get; set; }

    public DateOnly? CheckIn { get; set; }
}
