using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaInputTokensTrigger, BetaInputTokensTriggerFromRaw>))]
public sealed record class BetaInputTokensTrigger : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required long Value
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"input_tokens\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public BetaInputTokensTrigger()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_tokens\"");
    }

    public BetaInputTokensTrigger(BetaInputTokensTrigger betaInputTokensTrigger)
        : base(betaInputTokensTrigger) { }

    public BetaInputTokensTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_tokens\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInputTokensTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInputTokensTriggerFromRaw.FromRawUnchecked"/>
    public static BetaInputTokensTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaInputTokensTrigger(long value)
        : this()
    {
        this.Value = value;
    }
}

class BetaInputTokensTriggerFromRaw : IFromRaw<BetaInputTokensTrigger>
{
    /// <inheritdoc/>
    public BetaInputTokensTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInputTokensTrigger.FromRawUnchecked(rawData);
}
