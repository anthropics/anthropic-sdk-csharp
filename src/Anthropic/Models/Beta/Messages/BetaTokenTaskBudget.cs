using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// User-configurable total token budget across contexts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaTokenTaskBudget, BetaTokenTaskBudgetFromRaw>))]
public sealed record class BetaTokenTaskBudget : JsonModel
{
    /// <summary>
    /// Total token budget across all contexts in the session.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// The budget type. Currently only 'tokens' is supported.
    /// </summary>
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
    /// Remaining tokens in the budget. Use this to track usage across contexts when
    /// implementing compaction client-side. Defaults to total if not provided.
    /// </summary>
    public long? Remaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("remaining");
        }
        init { this._rawData.Set("remaining", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Total;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tokens")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Remaining;
    }

    public BetaTokenTaskBudget()
    {
        this.Type = JsonSerializer.SerializeToElement("tokens");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTokenTaskBudget(BetaTokenTaskBudget betaTokenTaskBudget)
        : base(betaTokenTaskBudget) { }
#pragma warning restore CS8618

    public BetaTokenTaskBudget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tokens");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTokenTaskBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTokenTaskBudgetFromRaw.FromRawUnchecked"/>
    public static BetaTokenTaskBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTokenTaskBudget(long total)
        : this()
    {
        this.Total = total;
    }
}

class BetaTokenTaskBudgetFromRaw : IFromRawJson<BetaTokenTaskBudget>
{
    /// <inheritdoc/>
    public BetaTokenTaskBudget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTokenTaskBudget.FromRawUnchecked(rawData);
}
