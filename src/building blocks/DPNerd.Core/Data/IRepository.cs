using DPNerd.Core.DomainObjects;

namespace DPNerd.Core.Data;

public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
