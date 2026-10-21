using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Placeholder for content withheld by Anthropic model policy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRedactedBlock,
        BetaManagedAgentsRedactedBlockFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRedactedBlock : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("redacted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsRedactedBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("redacted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRedactedBlock(
        BetaManagedAgentsRedactedBlock betaManagedAgentsRedactedBlock
    )
        : base(betaManagedAgentsRedactedBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRedactedBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("redacted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRedactedBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRedactedBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRedactedBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsRedactedBlockFromRaw : IFromRawJson<BetaManagedAgentsRedactedBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRedactedBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRedactedBlock.FromRawUnchecked(rawData);
}
