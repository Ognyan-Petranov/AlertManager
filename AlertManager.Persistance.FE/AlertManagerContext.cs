using AlertManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertManager.Persistance.FE
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
