using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeaDCentralAgency
{
    public string CentralAgency { get; set; } = null!;

    public virtual ICollection<MeaReserva> MeaReservas { get; set; } = new List<MeaReserva>();
}
