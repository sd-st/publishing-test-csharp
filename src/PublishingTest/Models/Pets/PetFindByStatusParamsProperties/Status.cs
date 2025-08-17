using System;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.Pets.PetFindByStatusParamsProperties;

/// <summary>
/// Status values that need to be considered for filter
/// </summary>
[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Available = new("available");

    public static readonly Status Pending = new("pending");

    public static readonly Status Sold = new("sold");

    readonly string _value = value;

    public enum Value
    {
        Available,
        Pending,
        Sold,
    }

    public Value Known() =>
        _value switch
        {
            "available" => Value.Available,
            "pending" => Value.Pending,
            "sold" => Value.Sold,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
