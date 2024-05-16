using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class StageApi1
{
    public string? Id { get; set; }

    public DateOnly? CheckIn { get; set; }

    public DateOnly? CheckOut { get; set; }

    public string? RateCode { get; set; }

    public string? TipoDeCuarto { get; set; }

    public int? Camas { get; set; }

    public string? TipoDeCama { get; set; }

    public string? Descripción { get; set; }

    public int? Adultos { get; set; }

    public string? Moneda { get; set; }

    public double? PrecioBase { get; set; }

    public double? Total { get; set; }

    public DateTime? FechaLímiteCancelación { get; set; }
}
