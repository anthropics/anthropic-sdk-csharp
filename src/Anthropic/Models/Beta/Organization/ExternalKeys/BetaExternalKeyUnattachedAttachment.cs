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
        BetaExternalKeyUnattachedAttachment,
        BetaExternalKeyUnattachedAttachmentFromRaw
    >)
)]
public sealed record class BetaExternalKeyUnattachedAttachment : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unattached")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalKeyUnattachedAttachment()
    {
        this.Type = JsonSerializer.SerializeToElement("unattached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalKeyUnattachedAttachment(
        BetaExternalKeyUnattachedAttachment betaExternalKeyUnattachedAttachment
    )
        : base(betaExternalKeyUnattachedAttachment) { }
#pragma warning restore CS8618

    public BetaExternalKeyUnattachedAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unattached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalKeyUnattachedAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalKeyUnattachedAttachmentFromRaw.FromRawUnchecked"/>
    public static BetaExternalKeyUnattachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalKeyUnattachedAttachmentFromRaw : IFromRawJson<BetaExternalKeyUnattachedAttachment>
{
    /// <inheritdoc/>
    public BetaExternalKeyUnattachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalKeyUnattachedAttachment.FromRawUnchecked(rawData);
}
