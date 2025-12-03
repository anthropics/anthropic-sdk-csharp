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
[JsonConverter(typeof(ModelConverter<BetaToolChoiceNone, BetaToolChoiceNoneFromRaw>))]
public sealed record class BetaToolChoiceNone : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"none\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolChoiceNone()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"none\"");
    }

    public BetaToolChoiceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"none\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaToolChoiceNoneFromRaw : IFromRaw<BetaToolChoiceNone>
{
    /// <inheritdoc/>
    public BetaToolChoiceNone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolChoiceNone.FromRawUnchecked(rawData);
}
