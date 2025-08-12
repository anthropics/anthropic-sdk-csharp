using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using System = System;

namespace Anthropic.Models.Messages.MessageParamProperties;

[JsonConverter(typeof(Anthropic::EnumConverter<Role, string>))]
public sealed record class Role(string value) : Anthropic::IEnum<Role, string>
{
    public static readonly Role User = new("user");

    public static readonly Role Assistant = new("assistant");

    readonly string _value = value;

    public enum Value
    {
        User,
        Assistant,
    }

    public Value Known() =>
        _value switch
        {
            "user" => Value.User,
            "assistant" => Value.Assistant,
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

    public static Role FromRaw(string value)
    {
        return new(value);
    }
}
