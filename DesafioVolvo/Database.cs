using Microsoft.EntityFrameworkCore;

namespace DesafioVolvo
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }

        public DbSet<TruckModel> TruckModels { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }

    public class TruckModel
    {
        public int TruckModelId { get; set; }
        public string ModelName { get; set; }
    }

    public class Truck
    {
        public int TruckId { get; set; }
        public string TruckName { get; set; }
        public int TruckModelId { get; set; }
        public int ManufactureYear { get; set; }
        public int ModelYear { get; set; }
    }
}