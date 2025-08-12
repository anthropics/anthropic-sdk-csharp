using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using System = System;

namespace Anthropic.Models.Beta.Messages.BetaToolProperties;

[JsonConverter(typeof(Anthropic::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Anthropic::IEnum<Type, string>
{
    public static readonly Type Custom = new("custom");

    readonly string _value = value;

    public enum Value
    {
        Custom,
    }

    public Value Known() =>
        _value switch
        {
            "custom" => Value.Custom,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
