using System;
using System.Text.Json.Serialization;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Pets.PetUpdateParamsProperties;

/// <summary>
/// pet status in the store
/// </summary>
[JsonConverter(typeof(PublishingTest::EnumConverter<Status, string>))]
public sealed record class Status(string value) : PublishingTest::IEnum<Status, string>
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
