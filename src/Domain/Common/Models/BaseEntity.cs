using System.ComponentModel.DataAnnotations.Schema;

namespace PosTerminal.Net.Domain.Common.Models;
public interface ITimeModification
{
    DateTime Created { get; set; }

    string? CreatedBy { get; set; }

    DateTime? LastModified { get; set; }

    string? LastModifiedBy { get; set; }
}
public abstract class BaseEntity<TId> : IEquatable<BaseEntity<TId>>, ITimeModification
    where TId : notnull
{
    public  virtual TId Id { get; set; }


    public override bool Equals(object? obj)
    {
        return obj is BaseEntity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        return Equals(left, right);
    }
    public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        return !Equals(left, right);
    }

    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public bool Equals(BaseEntity<TId>? other)
    {
        return Equals(other);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
