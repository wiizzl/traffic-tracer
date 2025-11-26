using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TrafficTracer.Models;

namespace TrafficTracer.Database;

public partial class DatabaseContext : DbContext
{
    public virtual DbSet<Immatriculation> Immatriculations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new SqlConnectionStringBuilder()
        {
            DataSource = "localhost",
            InitialCatalog = "TrafficTracer",
            PersistSecurityInfo = true,
            UserID = "sa",
            Password = "Passw0rd!",
            TrustServerCertificate = true
        };
        
        optionsBuilder.UseSqlServer(builder.ConnectionString).UseSeeding((context, _) =>
        {
            if (context.Set<Immatriculation>().Any()) return;
            
            context.Set<Immatriculation>().AddRange(
                new Immatriculation { Plate = "123AB456", Type = PlateType.FNI, ReadDate = DateTime.Now.AddDays(-10) },
                new Immatriculation { Plate = "AB123CD75", Type = PlateType.SIV, ReadDate = DateTime.Now.AddDays(-5) },
                new Immatriculation { Plate = "EF789GH13", Type = PlateType.SIV, ReadDate = DateTime.Now.AddDays(-2) }
            );
            
            context.SaveChanges();
        });
    }
}