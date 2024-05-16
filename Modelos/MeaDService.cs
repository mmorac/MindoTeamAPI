using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeaDService
{
    public string Service { get; set; } = null!;

    public virtual ICollection<MeaReserva> MeaReservas { get; set; } = new List<MeaReserva>();
}
