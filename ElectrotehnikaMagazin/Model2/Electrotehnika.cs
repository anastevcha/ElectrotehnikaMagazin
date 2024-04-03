using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ElectrotehnikaMagazin.Model2
{
    public partial class Electrotehnika : DbContext
    {
        static Electrotehnika electrotehnika;
        public Electrotehnika()
            : base("name=Electrotehnika")
        {
        }
        public static Electrotehnika GetContext()//получение контекста базы данных
        {
            if (electrotehnika == null)
            {
                electrotehnika = new Electrotehnika();
            }
            return electrotehnika;
        }

        public virtual DbSet<Doljnost_Sotrudnika> Doljnost_Sotrudnika { get; set; }
        public virtual DbSet<Dostavka_Zakaza> Dostavka_Zakaza { get; set; }
        public virtual DbSet<Kategorii_Tovarov> Kategorii_Tovarov { get; set; }
        public virtual DbSet<Klienty> Klienty { get; set; }
        public virtual DbSet<Magazin_Elektrotehniki> Magazin_Elektrotehniki { get; set; }
        public virtual DbSet<Operacii> Operacii { get; set; }
        public virtual DbSet<Oplata> Oplata { get; set; }
        public virtual DbSet<Otdely_Magazina> Otdely_Magazina { get; set; }
        public virtual DbSet<Otzyvy> Otzyvy { get; set; }
        public virtual DbSet<Pol> Pol { get; set; }
        public virtual DbSet<Polzovately> Polzovately { get; set; }
        public virtual DbSet<Postavshiki> Postavshiki { get; set; }
        public virtual DbSet<Razresheniya> Razresheniya { get; set; }
        public virtual DbSet<Roly> Roly { get; set; }
        public virtual DbSet<Skidki> Skidki { get; set; }
        public virtual DbSet<Sklad> Sklad { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<Status_Uslugi> Status_Uslugi { get; set; }
        public virtual DbSet<Status_Zakaza> Status_Zakaza { get; set; }
        public virtual DbSet<Tip_Oplaty> Tip_Oplaty { get; set; }
        public virtual DbSet<Tovary> Tovary { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Uslugi_Magazina> Uslugi_Magazina { get; set; }
        public virtual DbSet<Vid_Uslugi> Vid_Uslugi { get; set; }
        public virtual DbSet<Zakaz_Tovara_Na_Sklad> Zakaz_Tovara_Na_Sklad { get; set; }
        public virtual DbSet<Zakazy> Zakazy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doljnost_Sotrudnika>()
                .Property(e => e.Doljnost_Sotrudnika1)
                .IsFixedLength();

            modelBuilder.Entity<Doljnost_Sotrudnika>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.Doljnost_Sotrudnika)
                .HasForeignKey(e => e.Doljnost)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dostavka_Zakaza>()
                .Property(e => e.Adres_Dostavki)
                .IsFixedLength();

            modelBuilder.Entity<Kategorii_Tovarov>()
                .Property(e => e.Naimenovanie)
                .IsFixedLength();

            modelBuilder.Entity<Kategorii_Tovarov>()
                .HasMany(e => e.Tovary)
                .WithRequired(e => e.Kategorii_Tovarov)
                .HasForeignKey(e => e.Kategoriya_Tovara)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klienty>()
                .Property(e => e.Imya)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.Familiya)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.Otchestvo)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.Kontaktnye_dannye)
                .HasPrecision(16, 0);

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Otzyvy)
                .WithRequired(e => e.Klienty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Zakazy)
                .WithRequired(e => e.Klienty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Magazin_Elektrotehniki>()
                .Property(e => e.Nazvanie)
                .IsFixedLength();

            modelBuilder.Entity<Magazin_Elektrotehniki>()
                .Property(e => e.Adres)
                .IsFixedLength();

            modelBuilder.Entity<Magazin_Elektrotehniki>()
                .Property(e => e.Kontaktnye_Dannye)
                .HasPrecision(16, 0);

            modelBuilder.Entity<Operacii>()
                .Property(e => e.Opisanie_Operacii)
                .IsFixedLength();

            modelBuilder.Entity<Operacii>()
                .HasMany(e => e.Razresheniya)
                .WithRequired(e => e.Operacii)
                .HasForeignKey(e => e.Operaciya)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Otdely_Magazina>()
                .Property(e => e.Naimenovanie_Otdela)
                .IsFixedLength();

            modelBuilder.Entity<Otzyvy>()
                .Property(e => e.Tekst_Otzyva)
                .IsFixedLength();

            modelBuilder.Entity<Pol>()
                .Property(e => e.Pol1)
                .IsFixedLength();

            modelBuilder.Entity<Pol>()
                .HasMany(e => e.Klienty)
                .WithRequired(e => e.Pol1)
                .HasForeignKey(e => e.Pol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pol>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.Pol1)
                .HasForeignKey(e => e.Pol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Polzovately>()
                .Property(e => e.Imya_Polzovatelya)
                .IsFixedLength();

            modelBuilder.Entity<Polzovately>()
                .Property(e => e.Parol)
                .IsFixedLength();

            modelBuilder.Entity<Postavshiki>()
                .Property(e => e.Naimenovanie)
                .IsFixedLength();

            modelBuilder.Entity<Postavshiki>()
                .Property(e => e.Contaktnye_Dannye)
                .IsFixedLength();

            modelBuilder.Entity<Postavshiki>()
                .HasMany(e => e.Zakaz_Tovara_Na_Sklad)
                .WithRequired(e => e.Postavshiki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roly>()
                .Property(e => e.Rol)
                .IsFixedLength();

            modelBuilder.Entity<Roly>()
                .HasMany(e => e.Polzovately)
                .WithRequired(e => e.Roly)
                .HasForeignKey(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roly>()
                .HasMany(e => e.Razresheniya)
                .WithRequired(e => e.Roly)
                .HasForeignKey(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roly>()
                .HasMany(e => e.Sotrudniki)
                .WithOptional(e => e.Roly)
                .HasForeignKey(e => e.Rol);

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Imya)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Familiya)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Otchestvo)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Dostavka_Zakaza)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Magazin_Elektrotehniki)
                .WithRequired(e => e.Sotrudniki)
                .HasForeignKey(e => e.ID_Directora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Otdely_Magazina)
                .WithRequired(e => e.Sotrudniki)
                .HasForeignKey(e => e.ID_Menedjera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Uslugi_Magazina)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status_Uslugi>()
                .Property(e => e.Status_Uslugi1)
                .IsFixedLength();

            modelBuilder.Entity<Status_Uslugi>()
                .HasMany(e => e.Uslugi_Magazina)
                .WithRequired(e => e.Status_Uslugi1)
                .HasForeignKey(e => e.Status_Uslugi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status_Zakaza>()
                .Property(e => e.Status_Zakaza1)
                .IsFixedLength();

            modelBuilder.Entity<Status_Zakaza>()
                .HasMany(e => e.Zakazy)
                .WithRequired(e => e.Status_Zakaza1)
                .HasForeignKey(e => e.Status_Zakaza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tip_Oplaty>()
                .Property(e => e.Tip_Oplaty1)
                .IsFixedLength();

            modelBuilder.Entity<Tip_Oplaty>()
                .HasMany(e => e.Oplata)
                .WithRequired(e => e.Tip_Oplaty1)
                .HasForeignKey(e => e.Tip_Oplaty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovary>()
                .Property(e => e.Naimenovanie_Tovara)
                .IsFixedLength();

            modelBuilder.Entity<Tovary>()
                .Property(e => e.Opisanie_Tovara)
                .IsFixedLength();

            modelBuilder.Entity<Tovary>()
                .HasMany(e => e.Skidki)
                .WithRequired(e => e.Tovary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovary>()
                .HasMany(e => e.Sklad)
                .WithRequired(e => e.Tovary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovary>()
                .HasMany(e => e.Zakaz_Tovara_Na_Sklad)
                .WithRequired(e => e.Tovary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.login)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.parol)
                .IsFixedLength();

            modelBuilder.Entity<Vid_Uslugi>()
                .Property(e => e.Vid_Uslugi1)
                .IsFixedLength();

            modelBuilder.Entity<Vid_Uslugi>()
                .HasMany(e => e.Uslugi_Magazina)
                .WithRequired(e => e.Vid_Uslugi1)
                .HasForeignKey(e => e.Vid_Uslugi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakazy>()
                .HasMany(e => e.Dostavka_Zakaza)
                .WithRequired(e => e.Zakazy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakazy>()
                .HasMany(e => e.Oplata)
                .WithRequired(e => e.Zakazy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakazy>()
                .HasMany(e => e.Uslugi_Magazina)
                .WithRequired(e => e.Zakazy)
                .WillCascadeOnDelete(false);
        }
    }
}
