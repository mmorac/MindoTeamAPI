using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeDApiCheckIn
{
    public int IdCheckIn { get; set; }

    public DateOnly? CheckIn { get; set; }
}
