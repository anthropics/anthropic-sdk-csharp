using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaAdvisorRedactedResultBlock,
        BetaAdvisorRedactedResultBlockFromRaw
    >)
)]
public sealed record class BetaAdvisorRedactedResultBlock : JsonModel
{
    /// <summary>
    /// Opaque blob containing the advisor's output. Round-trip verbatim; do not
    /// inspect or modify.
    /// </summary>
    public required string EncryptedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("encrypted_content");
        }
        init { this._rawData.Set("encrypted_content", value); }
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
        _ = this.EncryptedContent;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("advisor_redacted_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorRedactedResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_redacted_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorRedactedResultBlock(
        BetaAdvisorRedactedResultBlock betaAdvisorRedactedResultBlock
    )
        : base(betaAdvisorRedactedResultBlock) { }
#pragma warning restore CS8618

    public BetaAdvisorRedactedResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_redacted_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorRedactedResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorRedactedResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorRedactedResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAdvisorRedactedResultBlock(string encryptedContent)
        : this()
    {
        this.EncryptedContent = encryptedContent;
    }
}

class BetaAdvisorRedactedResultBlockFromRaw : IFromRawJson<BetaAdvisorRedactedResultBlock>
{
    /// <inheritdoc/>
    public BetaAdvisorRedactedResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorRedactedResultBlock.FromRawUnchecked(rawData);
}
