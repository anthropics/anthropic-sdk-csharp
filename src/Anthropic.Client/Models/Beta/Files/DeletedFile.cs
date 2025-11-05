using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Files;

[JsonConverter(typeof(ModelConverter<DeletedFile>))]
public sealed record class DeletedFile : ModelBase, IFromRaw<DeletedFile>
{
    /// <summary>
    /// ID of the deleted file.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// For file deletion, this is always `"file_deleted"`.
    /// </summary>
    public ApiEnum<string, global::Anthropic.Client.Models.Beta.Files.Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Anthropic.Client.Models.Beta.Files.Type
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Type?.Validate();
    }

    public DeletedFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedFile(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DeletedFile FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public DeletedFile(string id)
        : this()
    {
        this.ID = id;
    }
}

/// <summary>
/// Deleted object type.
///
/// For file deletion, this is always `"file_deleted"`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FileDeleted,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Client.Models.Beta.Files.Type>
{
    public override global::Anthropic.Client.Models.Beta.Files.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_deleted" => global::Anthropic.Client.Models.Beta.Files.Type.FileDeleted,
            _ => (global::Anthropic.Client.Models.Beta.Files.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Client.Models.Beta.Files.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Client.Models.Beta.Files.Type.FileDeleted => "file_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
