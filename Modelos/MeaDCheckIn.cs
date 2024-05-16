using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeaDCheckIn
{
    public DateOnly CheckIn { get; set; }

    public virtual ICollection<MeaReserva> MeaReservas { get; set; } = new List<MeaReserva>();
}
