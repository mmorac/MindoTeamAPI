using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class StageAnonimizado
{
    public string? IdReservation { get; set; }

    public string? ArrivalFullDay { get; set; }

    public string? CheckOutFullDay { get; set; }

    public string? StatusFullDay { get; set; }

    public string? Rate { get; set; }

    public string? Service { get; set; }

    public string? Country { get; set; }

    public string? CentralAgencyA { get; set; }

    public string? CentralCompany { get; set; }

    public int? RoomnightsNet { get; set; }

    public int? StaysNet { get; set; }

    public double? SeminetNet { get; set; }

    public int? NuevoPrefijoAnio { get; set; }

    public string? EqHotel { get; set; }

    public string? EqChannelType { get; set; }

    public string? EqRoomType { get; set; }

    public string? Market { get; set; }

    public int? Estrellas { get; set; }
}
