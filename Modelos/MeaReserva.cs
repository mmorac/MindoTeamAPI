using System;
using System.Collections.Generic;

namespace MindoTeamAPI.Modelos;

public partial class MeaReserva
{
    public string IdReservas { get; set; } = null!;

    public double DailyRate { get; set; }

    public int? NroHuespedes { get; set; }

    public int? NroNoches { get; set; }

    public double? Revenue { get; set; }

    public string CentralAgency { get; set; } = null!;

    public string RateCode { get; set; } = null!;

    public string Hotel { get; set; } = null!;

    public string Market { get; set; } = null!;

    public string Channel { get; set; } = null!;

    public DateOnly CheckIn { get; set; }

    public string Service { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int? Estrellas { get; set; }

    public virtual MeaDCentralAgency CentralAgencyNavigation { get; set; } = null!;

    public virtual MeaDChannel ChannelNavigation { get; set; } = null!;

    public virtual MeaDCheckIn CheckInNavigation { get; set; } = null!;

    public virtual MeaDCountry CountryNavigation { get; set; } = null!;

    public virtual MeaDEstrella? EstrellasNavigation { get; set; }

    public virtual MeaDHotelInterno HotelNavigation { get; set; } = null!;

    public virtual MeaDMarket MarketNavigation { get; set; } = null!;

    public virtual MeaDRateCode RateCodeNavigation { get; set; } = null!;

    public virtual MeaDRoomType RoomTypeNavigation { get; set; } = null!;

    public virtual MeaDService ServiceNavigation { get; set; } = null!;
}
