using System;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages.BetaCacheControlEphemeralProperties;

/// <summary>
/// The time-to-live for the cache control breakpoint.
///
/// This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour
///
/// Defaults to `5m`.
/// </summary>
[JsonConverter(typeof(Anthropic::EnumConverter<TTL, string>))]
public sealed record class TTL(string value) : Anthropic::IEnum<TTL, string>
{
    public static readonly TTL TTL5m = new("5m");

    public static readonly TTL TTL1h = new("1h");

    readonly string _value = value;

    public enum Value
    {
        TTL5m,
        TTL1h,
    }

    public Value Known() =>
        _value switch
        {
            "5m" => Value.TTL5m,
            "1h" => Value.TTL1h,
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

    public static TTL FromRaw(string value)
    {
        return new(value);
    }
}
