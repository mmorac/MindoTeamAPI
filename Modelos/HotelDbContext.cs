using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MindoTeamAPI.Modelos;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MeDApiEstrella> MeDApiEstrellas { get; set; }

    public virtual DbSet<MeDApiHabitacion> MeDApiHabitacions { get; set; }

    public virtual DbSet<MeDApiHotel> MeDApiHotels { get; set; }

    public virtual DbSet<MeaDCentralAgency> MeaDCentralAgencies { get; set; }

    public virtual DbSet<MeaDChannel> MeaDChannels { get; set; }

    public virtual DbSet<MeaDCheckIn> MeaDCheckIns { get; set; }

    public virtual DbSet<MeaDCountry> MeaDCountries { get; set; }

    public virtual DbSet<MeaDEstrella> MeaDEstrellas { get; set; }

    public virtual DbSet<MeaDHotelInterno> MeaDHotelInternos { get; set; }

    public virtual DbSet<MeaDMarket> MeaDMarkets { get; set; }

    public virtual DbSet<MeaDRateCode> MeaDRateCodes { get; set; }

    public virtual DbSet<MeaDRoomType> MeaDRoomTypes { get; set; }

    public virtual DbSet<MeaDService> MeaDServices { get; set; }

    public virtual DbSet<MeaReserva> MeaReservas { get; set; }

    public virtual DbSet<PruebasApi> PruebasApis { get; set; }

    public virtual DbSet<StageAnonimizado> StageAnonimizados { get; set; }

    public virtual DbSet<StageApi> StageApis { get; set; }

    public virtual DbSet<StageApi1> StageApi1s { get; set; }

    public virtual DbSet<ThApi> ThApis { get; set; }

    public virtual DbSet<TransformedDataUsedForEdum> TransformedDataUsedForEda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mindoteam.database.windows.net;Initial Catalog=hotel_db;User id=mindoteam;Password=M1nd0T34m;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeDApiEstrella>(entity =>
        {
            entity.HasKey(e => e.Estrella).HasName("PK_ME_API_Estrella");

            entity.ToTable("ME_D_API_Estrella");

            entity.Property(e => e.Estrella).ValueGeneratedNever();
        });

        modelBuilder.Entity<MeDApiHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK_ME_API_Habitacion");

            entity.ToTable("ME_D_API_Habitacion");

            entity.Property(e => e.IdHabitacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Habitacion");
            entity.Property(e => e.TipoHabitación)
                .HasMaxLength(2000)
                .HasColumnName("Tipo_Habitación");
        });

        modelBuilder.Entity<MeDApiHotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PK_ME_API_Hotel");

            entity.ToTable("ME_D_API_Hotel");

            entity.Property(e => e.IdHotel)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("ID_Hotel");
            entity.Property(e => e.Hotel)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<MeaDCentralAgency>(entity =>
        {
            entity.HasKey(e => e.CentralAgency).HasName("PK__MEA_D_ce__D93D0CE42E5E3D16");

            entity.ToTable("MEA_D_central_agency");

            entity.Property(e => e.CentralAgency)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("central_agency");
        });

        modelBuilder.Entity<MeaDChannel>(entity =>
        {
            entity.HasKey(e => e.Channel).HasName("PK__MEA_D_ch__CCA16E30EFF2AD8B");

            entity.ToTable("MEA_D_channel");

            entity.Property(e => e.Channel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("channel");
        });

        modelBuilder.Entity<MeaDCheckIn>(entity =>
        {
            entity.HasKey(e => e.CheckIn).HasName("PK__MEA_D_ch__C0EB8716EF0E8AAF");

            entity.ToTable("MEA_D_check_in");

            entity.Property(e => e.CheckIn).HasColumnName("check_in");
        });

        modelBuilder.Entity<MeaDCountry>(entity =>
        {
            entity.HasKey(e => e.Country).HasName("PK__MEA_D_Co__067B3008DC28A1A9");

            entity.ToTable("MEA_D_Country");

            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeaDEstrella>(entity =>
        {
            entity.HasKey(e => e.Estrella);

            entity.ToTable("MEA_D_Estrellas");

            entity.Property(e => e.Estrella).ValueGeneratedNever();
        });

        modelBuilder.Entity<MeaDHotelInterno>(entity =>
        {
            entity.HasKey(e => e.Hotel).HasName("PK__MEA_D_Ho__AE924C1C826548C9");

            entity.ToTable("MEA_D_Hotel_interno");

            entity.Property(e => e.Hotel)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeaDMarket>(entity =>
        {
            entity.HasKey(e => e.Market).HasName("PK__MEA_D_Ma__4E33FCFBA6707D9B");

            entity.ToTable("MEA_D_Market");

            entity.Property(e => e.Market)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeaDRateCode>(entity =>
        {
            entity.HasKey(e => e.RateCode).HasName("PK__MEA_D_ra__BE2D49FE3E7EA8BE");

            entity.ToTable("MEA_D_rate_code");

            entity.Property(e => e.RateCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("rate_code");
        });

        modelBuilder.Entity<MeaDRoomType>(entity =>
        {
            entity.HasKey(e => e.RoomType).HasName("PK__MEA_D_ro__4468FEB99B00DE28");

            entity.ToTable("MEA_D_room_Type");

            entity.Property(e => e.RoomType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_Type");
        });

        modelBuilder.Entity<MeaDService>(entity =>
        {
            entity.HasKey(e => e.Service).HasName("PK__MEA_D_Se__DB37EE076582A682");

            entity.ToTable("MEA_D_Service");

            entity.Property(e => e.Service)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeaReserva>(entity =>
        {
            entity.HasKey(e => e.IdReservas).HasName("PK__MEA_Rese__D3AA260DF8A9E2D2");

            entity.ToTable("MEA_Reservas");

            entity.HasIndex(e => e.Country, "fk_Reservas_D_Country1_idx");

            entity.HasIndex(e => e.Hotel, "fk_Reservas_D_Hotel_interno1_idx");

            entity.HasIndex(e => e.Market, "fk_Reservas_D_Market1_idx");

            entity.HasIndex(e => e.Service, "fk_Reservas_D_Service1_idx");

            entity.HasIndex(e => e.CentralAgency, "fk_Reservas_D_central_agency_idx");

            entity.HasIndex(e => e.Channel, "fk_Reservas_D_channel1_idx");

            entity.HasIndex(e => e.CheckIn, "fk_Reservas_D_check_in1_idx");

            entity.HasIndex(e => e.RateCode, "fk_Reservas_D_rate_code1_idx");

            entity.HasIndex(e => e.RoomType, "fk_Reservas_D_room_Type1_idx");

            entity.Property(e => e.IdReservas)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idReservas");
            entity.Property(e => e.CentralAgency)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("central_agency");
            entity.Property(e => e.Channel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("channel");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DailyRate).HasColumnName("Daily_rate");
            entity.Property(e => e.Hotel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Market)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NroHuespedes).HasColumnName("Nro_Huespedes");
            entity.Property(e => e.NroNoches).HasColumnName("Nro_Noches");
            entity.Property(e => e.RateCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("rate_code");
            entity.Property(e => e.RoomType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_Type");
            entity.Property(e => e.Service)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CentralAgencyNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.CentralAgency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_central_agency");

            entity.HasOne(d => d.ChannelNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.Channel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_channel1");

            entity.HasOne(d => d.CheckInNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.CheckIn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_check_in1");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_Country1");

            entity.HasOne(d => d.EstrellasNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.Estrellas)
                .HasConstraintName("fk_Reservas_D_Estrellas");

            entity.HasOne(d => d.HotelNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.Hotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_Hotel_interno1");

            entity.HasOne(d => d.MarketNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.Market)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_Market1");

            entity.HasOne(d => d.RateCodeNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.RateCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_rate_code1");

            entity.HasOne(d => d.RoomTypeNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.RoomType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_room_Type1");

            entity.HasOne(d => d.ServiceNavigation).WithMany(p => p.MeaReservas)
                .HasForeignKey(d => d.Service)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservas_D_Service1");
        });

        modelBuilder.Entity<PruebasApi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pruebas_api");

            entity.Property(e => e.CheckIn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("check_out");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.NombreHotel)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_hotel");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<StageAnonimizado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage_Anonimizado");

            entity.Property(e => e.ArrivalFullDay)
                .HasMaxLength(50)
                .HasColumnName("Arrival_Full_Day");
            entity.Property(e => e.CentralAgencyA)
                .HasMaxLength(200)
                .HasColumnName("Central_Agency_A");
            entity.Property(e => e.CentralCompany)
                .HasMaxLength(200)
                .HasColumnName("Central_Company");
            entity.Property(e => e.CheckOutFullDay)
                .HasMaxLength(50)
                .HasColumnName("Check_Out_Full_Day");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.EqChannelType)
                .HasMaxLength(50)
                .HasColumnName("Eq_Channel_type");
            entity.Property(e => e.EqHotel)
                .HasMaxLength(10)
                .HasColumnName("Eq_hotel");
            entity.Property(e => e.EqRoomType)
                .HasMaxLength(200)
                .HasColumnName("Eq_Room_type");
            entity.Property(e => e.IdReservation)
                .HasMaxLength(50)
                .HasColumnName("ID_Reservation");
            entity.Property(e => e.Market).HasMaxLength(10);
            entity.Property(e => e.NuevoPrefijoAnio).HasColumnName("Nuevo_Prefijo_Anio");
            entity.Property(e => e.Rate).HasMaxLength(10);
            entity.Property(e => e.RoomnightsNet).HasColumnName("ROOMNIGHTS_NET");
            entity.Property(e => e.SeminetNet).HasColumnName("SEMINET_NET");
            entity.Property(e => e.Service).HasMaxLength(200);
            entity.Property(e => e.StatusFullDay)
                .HasMaxLength(50)
                .HasColumnName("Status_Full_Day");
            entity.Property(e => e.StaysNet).HasColumnName("STAYS_NET");
        });

        modelBuilder.Entity<StageApi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage_API");

            entity.Property(e => e.CheckIn).HasColumnName("Check_in");
            entity.Property(e => e.Habitacion).HasMaxLength(2000);
            entity.Property(e => e.IdHabitacion)
                .HasMaxLength(20)
                .HasColumnName("ID_Habitacion");
            entity.Property(e => e.IdHotel)
                .HasMaxLength(20)
                .HasColumnName("ID_Hotel");
            entity.Property(e => e.NombreHotel)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Hotel");
        });

        modelBuilder.Entity<StageApi1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage_API_1");

            entity.Property(e => e.CheckIn).HasColumnName("Check_In");
            entity.Property(e => e.CheckOut).HasColumnName("Check_Out");
            entity.Property(e => e.Descripción).HasMaxLength(200);
            entity.Property(e => e.FechaLímiteCancelación)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_límite_cancelación");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.Moneda).HasMaxLength(10);
            entity.Property(e => e.PrecioBase).HasColumnName("Precio_Base");
            entity.Property(e => e.RateCode)
                .HasMaxLength(10)
                .HasColumnName("Rate_Code");
            entity.Property(e => e.TipoDeCama)
                .HasMaxLength(50)
                .HasColumnName("Tipo_de_Cama");
            entity.Property(e => e.TipoDeCuarto)
                .HasMaxLength(50)
                .HasColumnName("Tipo_de_Cuarto");
        });

        modelBuilder.Entity<ThApi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TH_API");

            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("Check_in");
            entity.Property(e => e.Habitacion)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Hotel)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.IdHabitacion)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("ID_Habitacion");
            entity.Property(e => e.IdHotel).HasColumnName("ID_Hotel");
        });

        modelBuilder.Entity<TransformedDataUsedForEdum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Transformed Data Used for EDA");

            entity.Property(e => e.ArrivalDayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("Arrival_Day_of_Week");
            entity.Property(e => e.ArrivalFullDay).HasColumnName("Arrival_Full_Day");
            entity.Property(e => e.CentralAgencyA)
                .HasMaxLength(50)
                .HasColumnName("Central_Agency_A");
            entity.Property(e => e.CentralCompany)
                .HasMaxLength(50)
                .HasColumnName("Central_Company");
            entity.Property(e => e.CheckOutDayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("Check_Out_Day_of_Week");
            entity.Property(e => e.CheckOutFullDay).HasColumnName("Check_Out_Full_Day");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.DailyRate).HasColumnName("Daily_Rate");
            entity.Property(e => e.EqChannelType)
                .HasMaxLength(50)
                .HasColumnName("Eq_Channel_type");
            entity.Property(e => e.EqHotel)
                .HasMaxLength(50)
                .HasColumnName("Eq_hotel");
            entity.Property(e => e.EqRoomType)
                .HasMaxLength(50)
                .HasColumnName("Eq_Room_type");
            entity.Property(e => e.IdReservation)
                .HasMaxLength(50)
                .HasColumnName("ID_Reservation");
            entity.Property(e => e.NuevoPrefijoAnio).HasColumnName("Nuevo_Prefijo_Anio");
            entity.Property(e => e.Rate).HasMaxLength(50);
            entity.Property(e => e.RoomnightsDone).HasColumnName("ROOMNIGHTS_DONE");
            entity.Property(e => e.RoomnightsNet).HasColumnName("ROOMNIGHTS_NET");
            entity.Property(e => e.SeminetDone).HasColumnName("SEMINET_DONE");
            entity.Property(e => e.SeminetNet).HasColumnName("SEMINET_NET");
            entity.Property(e => e.Service).HasMaxLength(50);
            entity.Property(e => e.StatusDayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("Status_Day_of_Week");
            entity.Property(e => e.StatusFullDay).HasColumnName("Status_Full_Day");
            entity.Property(e => e.StaysDone).HasColumnName("STAYS_DONE");
            entity.Property(e => e.StaysNet).HasColumnName("STAYS_NET");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
