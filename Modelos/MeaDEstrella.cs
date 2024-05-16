using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeaDEstrella
{
    public int Estrella { get; set; }

    public virtual ICollection<MeaReserva> MeaReservas { get; set; } = new List<MeaReserva>();
}
