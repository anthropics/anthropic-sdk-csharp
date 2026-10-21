using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

[JsonConverter(
    typeof(JsonModelConverter<ExternalKeyAttachedAttachment, ExternalKeyAttachedAttachmentFromRaw>)
)]
public sealed record class ExternalKeyAttachedAttachment : JsonModel
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

    public ExternalKeyAttachedAttachment()
    {
        this.Type = JsonSerializer.SerializeToElement("attached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyAttachedAttachment(
        ExternalKeyAttachedAttachment externalKeyAttachedAttachment
    )
        : base(externalKeyAttachedAttachment) { }
#pragma warning restore CS8618

    public ExternalKeyAttachedAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("attached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyAttachedAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyAttachedAttachmentFromRaw.FromRawUnchecked"/>
    public static ExternalKeyAttachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyAttachedAttachmentFromRaw : IFromRawJson<ExternalKeyAttachedAttachment>
{
    /// <inheritdoc/>
    public ExternalKeyAttachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyAttachedAttachment.FromRawUnchecked(rawData);
}
