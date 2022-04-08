using System.Linq;
using AlertManager.Domain.Models;
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

        public override int SaveChanges()
        {
            var domainEventEntities = ChangeTracker.Entries<Entity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                var events = entity.DomainEvents.ToArray();
                entity.DomainEvents.Clear();
                foreach (var domainEvent in events)
                {
                    _mediator.Publish(domainEvent);
                }
            }

            return base.SaveChanges();
        }
    }
}
