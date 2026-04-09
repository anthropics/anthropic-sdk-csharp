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
        BetaAdvisorRedactedResultBlockParam,
        BetaAdvisorRedactedResultBlockParamFromRaw
    >)
)]
public sealed record class BetaAdvisorRedactedResultBlockParam : JsonModel
{
    /// <summary>
    /// Opaque blob produced by a prior response; must be round-tripped verbatim.
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

    public BetaAdvisorRedactedResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_redacted_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorRedactedResultBlockParam(
        BetaAdvisorRedactedResultBlockParam betaAdvisorRedactedResultBlockParam
    )
        : base(betaAdvisorRedactedResultBlockParam) { }
#pragma warning restore CS8618

    public BetaAdvisorRedactedResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_redacted_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorRedactedResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorRedactedResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorRedactedResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAdvisorRedactedResultBlockParam(string encryptedContent)
        : this()
    {
        this.EncryptedContent = encryptedContent;
    }
}

class BetaAdvisorRedactedResultBlockParamFromRaw : IFromRawJson<BetaAdvisorRedactedResultBlockParam>
{
    /// <inheritdoc/>
    public BetaAdvisorRedactedResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorRedactedResultBlockParam.FromRawUnchecked(rawData);
}
