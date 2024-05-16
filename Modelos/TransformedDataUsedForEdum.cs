using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class TransformedDataUsedForEdum
{
    public string? IdReservation { get; set; }

    public DateOnly? ArrivalFullDay { get; set; }

    public DateOnly? CheckOutFullDay { get; set; }

    public DateOnly? StatusFullDay { get; set; }

    public string? Rate { get; set; }

    public string? Service { get; set; }

    public string? Country { get; set; }

    public string? CentralAgencyA { get; set; }

    public string? CentralCompany { get; set; }

    public byte? RoomnightsDone { get; set; }

    public byte? StaysDone { get; set; }

    public double? SeminetDone { get; set; }

    public byte? RoomnightsNet { get; set; }

    public byte? StaysNet { get; set; }

    public double? SeminetNet { get; set; }

    public short? NuevoPrefijoAnio { get; set; }

    public string? EqHotel { get; set; }

    public string? EqChannelType { get; set; }

    public string? EqRoomType { get; set; }

    public byte? Market { get; set; }

    public string? ArrivalDayOfWeek { get; set; }

    public string? CheckOutDayOfWeek { get; set; }

    public string? StatusDayOfWeek { get; set; }

    public double? DailyRate { get; set; }

    public double? Revenue { get; set; }
}
