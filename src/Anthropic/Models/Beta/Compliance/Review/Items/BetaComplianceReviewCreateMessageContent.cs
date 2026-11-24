using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// A request to create a message, and its response.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewCreateMessageContent,
        BetaComplianceReviewCreateMessageContentFromRaw
    >)
)]
public sealed record class BetaComplianceReviewCreateMessageContent : JsonModel
{
    /// <summary>
    /// The `POST /v1/messages` request body, without thinking blocks or unpublished
    /// fields. For a user's message from an Anthropic app, such as Claude Code, `system`
    /// is a placeholder.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("request");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "request",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The model's `Message`, without thinking blocks or unpublished fields. Null
    /// when no response was stored, for example because the client disconnected.
    /// </summary>
    public required BetaMessage? Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaMessage>("response");
        }
        init { this._rawData.Set("response", value); }
    }

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
        _ = this.Request;
        this.Response?.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("create_message")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewCreateMessageContent()
    {
        this.Type = JsonSerializer.SerializeToElement("create_message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewCreateMessageContent(
        BetaComplianceReviewCreateMessageContent betaComplianceReviewCreateMessageContent
    )
        : base(betaComplianceReviewCreateMessageContent) { }
#pragma warning restore CS8618

    public BetaComplianceReviewCreateMessageContent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("create_message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewCreateMessageContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewCreateMessageContentFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewCreateMessageContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewCreateMessageContentFromRaw
    : IFromRawJson<BetaComplianceReviewCreateMessageContent>
{
    /// <inheritdoc/>
    public BetaComplianceReviewCreateMessageContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewCreateMessageContent.FromRawUnchecked(rawData);
}
