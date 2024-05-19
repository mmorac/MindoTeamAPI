using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class ThApi
{
    public double? Precio { get; set; }

    public int? Estrella { get; set; }

    public int? IdCheckIn { get; set; }

    public string? IdHotel { get; set; }

    public int? IdHabitacion { get; set; }

    public virtual MeDApiEstrella? EstrellaNavigation { get; set; }

    public virtual MeDApiCheckIn? IdCheckInNavigation { get; set; }

    public virtual MeDApiHabitacion? IdHabitacionNavigation { get; set; }

    public virtual MeDApiHotel? IdHotelNavigation { get; set; }
}
