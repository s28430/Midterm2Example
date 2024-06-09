using GagoExampleTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GagoExampleTest.Context;

public class BoatsDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    
    protected BoatsDbContext()
    {
    }

    public BoatsDbContext(DbContextOptions options) : base(options)
    {
    }
}