using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<FileDocumentSource, FileDocumentSourceFromRaw>))]
public sealed record class FileDocumentSource : JsonModel
{
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public FileDocumentSource()
    {
        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileDocumentSource(FileDocumentSource fileDocumentSource)
        : base(fileDocumentSource) { }
#pragma warning restore CS8618

    public FileDocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileDocumentSourceFromRaw.FromRawUnchecked"/>
    public static FileDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileDocumentSource(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class FileDocumentSourceFromRaw : IFromRawJson<FileDocumentSource>
{
    /// <inheritdoc/>
    public FileDocumentSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileDocumentSource.FromRawUnchecked(rawData);
}
