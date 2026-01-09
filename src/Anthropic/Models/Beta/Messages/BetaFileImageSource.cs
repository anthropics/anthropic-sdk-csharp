using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaFileImageSource, BetaFileImageSourceFromRaw>))]
public sealed record class BetaFileImageSource : JsonModel
{
    public required string FileID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "file_id"); }
        init { JsonModel.Set(this._rawData, "file_id", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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

    public BetaFileImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

    public BetaFileImageSource(BetaFileImageSource betaFileImageSource)
        : base(betaFileImageSource) { }

    public BetaFileImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFileImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFileImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaFileImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFileImageSource(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaFileImageSourceFromRaw : IFromRawJson<BetaFileImageSource>
{
    /// <inheritdoc/>
    public BetaFileImageSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFileImageSource.FromRawUnchecked(rawData);
}
