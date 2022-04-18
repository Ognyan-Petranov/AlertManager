using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Domain.Models;
using AlertManager.Domain.Models.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlertManager.Persistance.EF
{
    public class AlertManagerContext : DbContext
    {
        private readonly IMediator _mediator;

        public AlertManagerContext(DbContextOptions<AlertManagerContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Alert> Alerts { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEventEntities = ChangeTracker.Entries<IEntity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents != null && po.DomainEvents.Any())?
                .ToArray();

            if (domainEventEntities != null && domainEventEntities.Any())
            {
                foreach (var entity in domainEventEntities)
                {
                    var events = entity.DomainEvents.ToArray();
                    entity.DomainEvents.Clear();
                    foreach (var domainEvent in events)
                    {
                        await _mediator.Publish(domainEvent);
                    }

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
