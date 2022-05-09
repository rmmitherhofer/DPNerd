using DPNerd.Core.Data;
using DPNerd.Core.DomainObjects;
using DPNerd.Core.Mediator;
using DPNerd.Core.Messages;
using DPNerd.Employees.Application.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DPNerd.Employees.Infra.Data;

public class EmployeeContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public EmployeeContext(DbContextOptions<EmployeeContext> options, IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<GeneralRecord> GeneralRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<ValidationResult>();
        builder.Ignore<Event>();

        foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(e =>
                e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
        {
            property.SetColumnType("varchar(100)");
        }

        foreach (var relationship in builder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }

        builder.ApplyConfigurationsFromAssembly(typeof(EmployeeContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        var sucesso = await base.SaveChangesAsync() > 0;

        if (sucesso)
            await _mediatorHandler.PublishEvents(this);

        return sucesso;
    }       
}
public static class MediatorExtension
{
    public static async Task PublishEvents<TDbContext>(this IMediatorHandler mediator, TDbContext context) where TDbContext : DbContext
    {
        var domainEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.Events?.Any() == true);

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Events)
            .ToList();

        domainEntities
            .ToList()
            .ForEach(entity => entity.Entity.ClearEvents());

        var tasks = domainEvents
            .Select(async (domainEvents) => await mediator.PublishEvent(domainEvents));

        await Task.WhenAll(tasks);
    }
}