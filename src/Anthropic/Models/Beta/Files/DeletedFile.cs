using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Files;

[JsonConverter(typeof(JsonModelConverter<DeletedFile, DeletedFileFromRaw>))]
public sealed record class DeletedFile : JsonModel
{
    /// <summary>
    /// ID of the deleted file.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// <para>For file deletion, this is always `"file_deleted"`.</para>
    /// </summary>
    public ApiEnum<string, global::Anthropic.Models.Beta.Files.Type>? Type
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Files.Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type?.Validate();
    }

    public DeletedFile() { }

    public DeletedFile(DeletedFile deletedFile)
        : base(deletedFile) { }

    public DeletedFile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedFile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedFileFromRaw.FromRawUnchecked"/>
    public static DeletedFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeletedFile(string id)
        : this()
    {
        this.ID = id;
    }
}

class DeletedFileFromRaw : IFromRawJson<DeletedFile>
{
    /// <inheritdoc/>
    public DeletedFile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedFile.FromRawUnchecked(rawData);
}

/// <summary>
/// Deleted object type.
///
/// <para>For file deletion, this is always `"file_deleted"`.</para>
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FileDeleted,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Files.Type>
{
    public override global::Anthropic.Models.Beta.Files.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_deleted" => global::Anthropic.Models.Beta.Files.Type.FileDeleted,
            _ => (global::Anthropic.Models.Beta.Files.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Files.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Files.Type.FileDeleted => "file_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
