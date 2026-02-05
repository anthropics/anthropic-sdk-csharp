using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Automatically compact older context when reaching the configured trigger threshold.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCompact20260112Edit, BetaCompact20260112EditFromRaw>))]
public sealed record class BetaCompact20260112Edit : JsonModel
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
    /// Additional instructions for summarization.
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

    /// <summary>
    /// Whether to pause after compaction and return the compaction block to the user.
    /// </summary>
    public bool? PauseAfterCompaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("pause_after_compaction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pause_after_compaction", value);
        }
    }

    /// <summary>
    /// When to trigger compaction. Defaults to 150000 input tokens.
    /// </summary>
    public BetaInputTokensTrigger? Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaInputTokensTrigger>("trigger");
        }
        init { this._rawData.Set("trigger", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compact_20260112")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Instructions;
        _ = this.PauseAfterCompaction;
        this.Trigger?.Validate();
    }

    public BetaCompact20260112Edit()
    {
        this.Type = JsonSerializer.SerializeToElement("compact_20260112");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompact20260112Edit(BetaCompact20260112Edit betaCompact20260112Edit)
        : base(betaCompact20260112Edit) { }
#pragma warning restore CS8618

    public BetaCompact20260112Edit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compact_20260112");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompact20260112Edit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompact20260112EditFromRaw.FromRawUnchecked"/>
    public static BetaCompact20260112Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCompact20260112EditFromRaw : IFromRawJson<BetaCompact20260112Edit>
{
    /// <inheritdoc/>
    public BetaCompact20260112Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCompact20260112Edit.FromRawUnchecked(rawData);
}
