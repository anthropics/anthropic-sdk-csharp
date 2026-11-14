using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The Bundle has an attachment this API does not support editing, so its instructions
/// can be changed only in claude.ai.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaBundleAttachmentNotSupportedErrorDetails,
        BetaBundleAttachmentNotSupportedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaBundleAttachmentNotSupportedErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("bundle_attachment_not_supported")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBundleAttachmentNotSupportedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("bundle_attachment_not_supported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBundleAttachmentNotSupportedErrorDetails(
        BetaBundleAttachmentNotSupportedErrorDetails betaBundleAttachmentNotSupportedErrorDetails
    )
        : base(betaBundleAttachmentNotSupportedErrorDetails) { }
#pragma warning restore CS8618

    public BetaBundleAttachmentNotSupportedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("bundle_attachment_not_supported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBundleAttachmentNotSupportedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBundleAttachmentNotSupportedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaBundleAttachmentNotSupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBundleAttachmentNotSupportedErrorDetailsFromRaw
    : IFromRawJson<BetaBundleAttachmentNotSupportedErrorDetails>
{
    /// <inheritdoc/>
    public BetaBundleAttachmentNotSupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBundleAttachmentNotSupportedErrorDetails.FromRawUnchecked(rawData);
}
