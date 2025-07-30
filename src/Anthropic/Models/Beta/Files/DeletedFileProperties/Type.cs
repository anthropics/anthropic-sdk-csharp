using System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Files.DeletedFileProperties;

/// <summary>
/// Deleted object type.
///
/// For file deletion, this is always `"file_deleted"`.
/// </summary>
[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
{
    public static readonly Type FileDeleted = new("file_deleted");

    readonly string _value = value;

    public enum Value
    {
        FileDeleted,
    }

    public Value Known() =>
        _value switch
        {
            "file_deleted" => Value.FileDeleted,
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
