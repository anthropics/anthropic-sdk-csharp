using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaAdvisorResultBlock, BetaAdvisorResultBlockFromRaw>))]
public sealed record class BetaAdvisorResultBlock : JsonModel
{
    /// <summary>
    /// The advisor sub-inference's stop reason (same values as the top-level message
    /// `stop_reason`). `max_tokens` indicates the advisor's output was truncated
    /// at the tool's `max_tokens` value or the advisor model's policy cap.
    /// </summary>
    public required string? StopReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stop_reason");
        }
        init { this._rawData.Set("stop_reason", value); }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        _ = this.StopReason;
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("advisor_result")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorResultBlock(BetaAdvisorResultBlock betaAdvisorResultBlock)
        : base(betaAdvisorResultBlock) { }
#pragma warning restore CS8618

    public BetaAdvisorResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAdvisorResultBlockFromRaw : IFromRawJson<BetaAdvisorResultBlock>
{
    /// <inheritdoc/>
    public BetaAdvisorResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorResultBlock.FromRawUnchecked(rawData);
}
