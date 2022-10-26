using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAccess
{
    public class HouseholdManagerContext : DbContext
    {
        public HouseholdManagerContext() : base("name=HouseholdManagerContext")
        {
                
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Donate> Donates { get; set; }  

        public DbSet<DonateInfo> DonateInfos { get; set; }

        public DbSet<Fee> Fees { get; set; }

        public DbSet<FeeInfo> FeeInfos { get; set; }

        public DbSet<Household> Households { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccountConfig());
            modelBuilder.Configurations.Add(new DonateConfig());
            modelBuilder.Configurations.Add(new DonateInfoConfig());
            modelBuilder.Configurations.Add(new FeeConfig());
            modelBuilder.Configurations.Add(new FeeInfoConfig());
            modelBuilder.Configurations.Add(new HouseholdConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
        }
    }

    public class AccountConfig : EntityTypeConfiguration<Account>
    {
        public AccountConfig()
        {
            HasKey(a => a.Username);

            Property(a => a.Username).HasMaxLength(50);
            Property(a => a.DisplayName).IsRequired().HasMaxLength(50);
            Property(a => a.Password).IsRequired();
            Property(a => a.Type).IsRequired();
            Property(a => a.Note).IsRequired();
            Property(a => a.Setting).IsRequired();
        }
    }

    public class DonateConfig : EntityTypeConfiguration<Donate>
    {
        public DonateConfig()
        {
            Property(d => d.Name)
                .IsRequired()
                  .HasMaxLength(50);

            HasMany(d => d.DonateInfos)
                .WithRequired(di => di.Donate)
                .HasForeignKey(di => di.DonateID);
            
        }
    }

    public class DonateInfoConfig : EntityTypeConfiguration<DonateInfo>
    {
        public DonateInfoConfig()
        {
            HasRequired(di => di.Donate)
                .WithMany(d => d.DonateInfos)
                .HasForeignKey(di => di.DonateID);

            HasRequired(di => di.Household)
                .WithMany(h => h.DonateInfos)
                .HasForeignKey(di => di.HouseholdID);
        }
    }

    public class HouseholdConfig : EntityTypeConfiguration<Household>
    {
        public HouseholdConfig()
        {
            Property(h => h.Owner)
                .IsRequired()
                .HasMaxLength(50);

            Property(h => h.Address)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(h => h.People)
                .WithRequired(p => p.Household)
                .HasForeignKey(p => p.HouseholdID);

            HasMany(h => h.DonateInfos)
                .WithRequired(di => di.Household)
                .HasForeignKey(di => di.HouseholdID);

            HasMany(h => h.FeeInfos)
                .WithRequired(fi => fi.Household)
                .HasForeignKey(fi => fi.HouseholdID);

        }
    }

    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Cmnd)
                .IsRequired()
                .HasMaxLength(12);

            Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

    public class FeeConfig : EntityTypeConfiguration<Fee>
    {
        public FeeConfig()
        {
            Property(f => f.Name)
                .IsRequired()
                  .HasMaxLength(50);

            HasMany(f => f.FeeInfos)
                .WithRequired(fi => fi.Fee)
                .HasForeignKey(fi => fi.FeeID);

        }
    }

    public class FeeInfoConfig : EntityTypeConfiguration<FeeInfo>
    {
        public FeeInfoConfig()
        {
            HasRequired(fi => fi.Fee)
                .WithMany(d => d.FeeInfos)
                .HasForeignKey(fi => fi.FeeID);

            HasRequired(fi => fi.Household)
                .WithMany(h => h.FeeInfos)
                .HasForeignKey(fi => fi.HouseholdID);
        }
    }
}
