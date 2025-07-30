using System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.ToolProperties;

[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
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
