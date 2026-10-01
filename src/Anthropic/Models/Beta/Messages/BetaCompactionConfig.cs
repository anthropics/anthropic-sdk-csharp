using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Compact the whole conversation and return a signed `compaction` block, alone,
/// that a later request sends back first in `messages`, in place of the messages
/// it summarizes. There is no trigger and no pause flag: sending the parameter compacts,
/// and nothing is sampled after the block.
///
/// <para>The summarization prompt is the server's own unless `instructions` are
/// given, which then replace it for this request; a value that is empty or only whitespace
/// counts as absent.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCompactionConfig, BetaCompactionConfigFromRaw>))]
public sealed record class BetaCompactionConfig : JsonModel
{
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
    /// Replaces the server's default summarization prompt for this request. An empty
    /// or whitespace-only value counts as absent.
    /// </summary>
    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("summarize")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Instructions;
    }

    public BetaCompactionConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("summarize");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionConfig(BetaCompactionConfig betaCompactionConfig)
        : base(betaCompactionConfig) { }
#pragma warning restore CS8618

    public BetaCompactionConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("summarize");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionConfigFromRaw.FromRawUnchecked"/>
    public static BetaCompactionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCompactionConfigFromRaw : IFromRawJson<BetaCompactionConfig>
{
    /// <inheritdoc/>
    public BetaCompactionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCompactionConfig.FromRawUnchecked(rawData);
}
