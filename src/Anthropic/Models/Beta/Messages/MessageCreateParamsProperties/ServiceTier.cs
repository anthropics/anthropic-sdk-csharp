using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages.MessageCreateParamsProperties;

/// <summary>
/// Determines whether to use priority capacity (if available) or standard capacity
/// for this request.
///
/// Anthropic offers different levels of service for your API requests. See [service-tiers](https://docs.anthropic.com/en/api/service-tiers)
/// for details.
/// </summary>
[JsonConverter(typeof(Anthropic::EnumConverter<ServiceTier, string>))]
public sealed record class ServiceTier(string value) : Anthropic::IEnum<ServiceTier, string>
{
    public static readonly ServiceTier Auto = new("auto");

    public static readonly ServiceTier StandardOnly = new("standard_only");

    readonly string _value = value;

    public enum Value
    {
        Auto,
        StandardOnly,
    }

    public Value Known() =>
        _value switch
        {
            "auto" => Value.Auto,
            "standard_only" => Value.StandardOnly,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(_value)),
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
