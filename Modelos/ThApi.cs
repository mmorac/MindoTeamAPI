using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class ThApi
{
    public double? Precio { get; set; }

    public DateTime? CheckIn { get; set; }

    public string? Hotel { get; set; }

    public int? Estrella { get; set; }

    public string? Habitacion { get; set; }

    public int? IdHotel { get; set; }

    public string? IdHabitacion { get; set; }
}
