using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A compaction block returned when autocompact is triggered.
///
/// <para>When content is None, it indicates the compaction failed to produce a valid
/// summary (e.g., malformed output from the model). Clients may round-trip compaction
/// blocks with null content; the server treats them as no-ops.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCompactionBlock, BetaCompactionBlockFromRaw>))]
public sealed record class BetaCompactionBlock : JsonModel
{
    /// <summary>
    /// Summary of compacted content, or null if compaction failed
    /// </summary>
    public required string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
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
        _ = this.Content;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("compaction")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCompactionBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionBlock(BetaCompactionBlock betaCompactionBlock)
        : base(betaCompactionBlock) { }
#pragma warning restore CS8618

    public BetaCompactionBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionBlockFromRaw.FromRawUnchecked"/>
    public static BetaCompactionBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCompactionBlock(string? content)
        : this()
    {
        this.Content = content;
    }
}

class BetaCompactionBlockFromRaw : IFromRawJson<BetaCompactionBlock>
{
    /// <inheritdoc/>
    public BetaCompactionBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCompactionBlock.FromRawUnchecked(rawData);
}
