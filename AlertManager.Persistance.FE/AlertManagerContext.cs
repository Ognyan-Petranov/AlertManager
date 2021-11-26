using AlertManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertManager.Persistance.EF
{
    public class AlertManagerContext : DbContext
    {
        public AlertManagerContext(DbContextOptions<AlertManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Alert> Alerts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TG07H0V;Database=AlertManager;Integrated Security=true;");
            }
        }
    }
}
