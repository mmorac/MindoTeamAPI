using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class HotelesRequerido
{
    public string? NombreHotel { get; set; }

    public int? Estrellas { get; set; }

    public string IdHotel { get; set; } = null!;
}
