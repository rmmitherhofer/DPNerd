using DPNerd.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPNerd.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    private List<Event> _events;
    public IReadOnlyCollection<Event>? Events
        => _events?.AsReadOnly();
    public void AddEvent(Event @event)
    {
        _events ??= new List<Event>();
        _events.Add(@event);
    }
    public void RemoveEvent(Event @event)
        => _events?.Remove(@event);
    public void ClearEvents()
        => _events?.Clear();


    #region Comparações
    public override bool Equals(object obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo))
            return true;

        if (ReferenceEquals(null, compareTo))
            return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
    #endregion
}
