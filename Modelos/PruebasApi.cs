using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class PruebasApi
{
    public int Id { get; set; }

    public string? NombreHotel { get; set; }

    public string? CheckIn { get; set; }

    public string? CheckOut { get; set; }

    public double? Precio { get; set; }

    public int Estrellas { get; set; }
}
