using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The turn ended because the model's response was refused, for example by a safety classifier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRefusal,
        BetaManagedAgentsSessionRefusalFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRefusal : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("refusal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionRefusal()
    {
        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRefusal(
        BetaManagedAgentsSessionRefusal betaManagedAgentsSessionRefusal
    )
        : base(betaManagedAgentsSessionRefusal) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRefusal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRefusal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRefusalFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRefusal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionRefusalFromRaw : IFromRawJson<BetaManagedAgentsSessionRefusal>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRefusal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRefusal.FromRawUnchecked(rawData);
}
