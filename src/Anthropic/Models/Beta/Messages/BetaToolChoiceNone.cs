using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaToolChoiceNone, BetaToolChoiceNoneFromRaw>))]
public sealed record class BetaToolChoiceNone : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("none")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolChoiceNone()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

    public BetaToolChoiceNone(BetaToolChoiceNone betaToolChoiceNone)
        : base(betaToolChoiceNone) { }

    public BetaToolChoiceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChoiceNoneFromRaw.FromRawUnchecked"/>
    public static BetaToolChoiceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolChoiceNoneFromRaw : IFromRawJson<BetaToolChoiceNone>
{
    /// <inheritdoc/>
    public BetaToolChoiceNone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolChoiceNone.FromRawUnchecked(rawData);
}
