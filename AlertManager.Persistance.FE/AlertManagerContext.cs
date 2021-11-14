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
    }
}
