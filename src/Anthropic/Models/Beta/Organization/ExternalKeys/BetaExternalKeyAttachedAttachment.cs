using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalKeyAttachedAttachment,
        BetaExternalKeyAttachedAttachmentFromRaw
    >)
)]
public sealed record class BetaExternalKeyAttachedAttachment : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("attached")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalKeyAttachedAttachment()
    {
        this.Type = JsonSerializer.SerializeToElement("attached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalKeyAttachedAttachment(
        BetaExternalKeyAttachedAttachment betaExternalKeyAttachedAttachment
    )
        : base(betaExternalKeyAttachedAttachment) { }
#pragma warning restore CS8618

    public BetaExternalKeyAttachedAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("attached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalKeyAttachedAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalKeyAttachedAttachmentFromRaw.FromRawUnchecked"/>
    public static BetaExternalKeyAttachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalKeyAttachedAttachmentFromRaw : IFromRawJson<BetaExternalKeyAttachedAttachment>
{
    /// <inheritdoc/>
    public BetaExternalKeyAttachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalKeyAttachedAttachment.FromRawUnchecked(rawData);
}
