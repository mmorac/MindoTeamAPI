using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeaDHotelInterno
{
    public string IdHotel { get; set; } = null!;

    public virtual ICollection<MeaReserva> MeaReservas { get; set; } = new List<MeaReserva>();
}
