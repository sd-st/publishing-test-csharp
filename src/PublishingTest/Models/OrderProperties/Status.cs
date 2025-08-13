using System;
using System.Text.Json.Serialization;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.OrderProperties;

/// <summary>
/// Order Status
/// </summary>
[JsonConverter(typeof(PublishingTest::EnumConverter<Status, string>))]
public sealed record class Status(string value) : PublishingTest::IEnum<Status, string>
{
    public static readonly Status Placed = new("placed");

    public static readonly Status Approved = new("approved");

    public static readonly Status Delivered = new("delivered");

    readonly string _value = value;

    public enum Value
    {
        Placed,
        Approved,
        Delivered,
    }

    public Value Known() =>
        _value switch
        {
            "placed" => Value.Placed,
            "approved" => Value.Approved,
            "delivered" => Value.Delivered,
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
