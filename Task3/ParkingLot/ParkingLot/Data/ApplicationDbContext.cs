using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingLot.Models;

namespace ParkingLot.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<VehicleType>VehicleTypes  { get; set; }
        public DbSet<Spot>Spots  { get; set; }
    }
}