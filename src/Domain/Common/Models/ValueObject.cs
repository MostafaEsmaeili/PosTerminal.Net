﻿namespace PosTerminal.Net.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return Equals(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;
        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => (x?.GetHashCode()) ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject? other)
    {
        return Equals(other);
    }
}
