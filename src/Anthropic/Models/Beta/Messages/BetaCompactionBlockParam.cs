using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A compaction block containing summary of previous context.
///
/// <para>Users should round-trip these blocks from responses to subsequent requests
/// to maintain context across compaction boundaries.</para>
///
/// <para>When content is None, the block represents a failed compaction. The server
/// treats these as no-ops. Empty string content is not allowed.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaCompactionBlockParam, BetaCompactionBlockParamFromRaw>)
)]
public sealed record class BetaCompactionBlockParam : JsonModel
{
    /// <summary>
    /// Summary of previously compacted content, or null if compaction failed
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("compaction")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaCompactionBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionBlockParam(BetaCompactionBlockParam betaCompactionBlockParam)
        : base(betaCompactionBlockParam) { }
#pragma warning restore CS8618

    public BetaCompactionBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaCompactionBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCompactionBlockParam(string? content)
        : this()
    {
        this.Content = content;
    }
}

class BetaCompactionBlockParamFromRaw : IFromRawJson<BetaCompactionBlockParam>
{
    /// <inheritdoc/>
    public BetaCompactionBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCompactionBlockParam.FromRawUnchecked(rawData);
}
