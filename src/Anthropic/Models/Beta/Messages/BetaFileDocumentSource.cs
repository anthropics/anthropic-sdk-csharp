using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaFileDocumentSource, BetaFileDocumentSourceFromRaw>))]
public sealed record class BetaFileDocumentSource : JsonModel
{
    public required string FileID
    {
        get { return this._rawData.GetNotNullClass<string>("file_id"); }
        init { this._rawData.Set("file_id", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"file\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaFileDocumentSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

    public BetaFileDocumentSource(BetaFileDocumentSource betaFileDocumentSource)
        : base(betaFileDocumentSource) { }

    public BetaFileDocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFileDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFileDocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaFileDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFileDocumentSource(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaFileDocumentSourceFromRaw : IFromRawJson<BetaFileDocumentSource>
{
    /// <inheritdoc/>
    public BetaFileDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFileDocumentSource.FromRawUnchecked(rawData);
}
