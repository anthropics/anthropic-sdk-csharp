using System;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaUsageProperties;

/// <summary>
/// If the request used the priority, standard, or batch tier.
/// </summary>
[JsonConverter(typeof(EnumConverter<ServiceTier, string>))]
public sealed record class ServiceTier(string value) : IEnum<ServiceTier, string>
{
    public static readonly ServiceTier Standard = new("standard");

    public static readonly ServiceTier Priority = new("priority");

    public static readonly ServiceTier Batch = new("batch");

    readonly string _value = value;

    public enum Value
    {
        Standard,
        Priority,
        Batch,
    }

    public Value Known() =>
        _value switch
        {
            "standard" => Value.Standard,
            "priority" => Value.Priority,
            "batch" => Value.Batch,
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

    public static ServiceTier FromRaw(string value)
    {
        return new(value);
    }
}
