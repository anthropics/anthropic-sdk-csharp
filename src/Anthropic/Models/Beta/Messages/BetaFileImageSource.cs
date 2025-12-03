using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaFileImageSource, BetaFileImageSourceFromRaw>))]
public sealed record class BetaFileImageSource : ModelBase
{
    public required string FileID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

class BetaFileImageSourceFromRaw : IFromRaw<BetaFileImageSource>
{
    /// <inheritdoc/>
    public BetaFileImageSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFileImageSource.FromRawUnchecked(rawData);
}
