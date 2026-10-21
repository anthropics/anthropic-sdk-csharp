using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

[JsonConverter(
    typeof(JsonModelConverter<
        ExternalKeyUnattachedAttachment,
        ExternalKeyUnattachedAttachmentFromRaw
    >)
)]
public sealed record class ExternalKeyUnattachedAttachment : JsonModel
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

    public ExternalKeyUnattachedAttachment()
    {
        this.Type = JsonSerializer.SerializeToElement("unattached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyUnattachedAttachment(
        ExternalKeyUnattachedAttachment externalKeyUnattachedAttachment
    )
        : base(externalKeyUnattachedAttachment) { }
#pragma warning restore CS8618

    public ExternalKeyUnattachedAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unattached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyUnattachedAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyUnattachedAttachmentFromRaw.FromRawUnchecked"/>
    public static ExternalKeyUnattachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyUnattachedAttachmentFromRaw : IFromRawJson<ExternalKeyUnattachedAttachment>
{
    /// <inheritdoc/>
    public ExternalKeyUnattachedAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyUnattachedAttachment.FromRawUnchecked(rawData);
}
