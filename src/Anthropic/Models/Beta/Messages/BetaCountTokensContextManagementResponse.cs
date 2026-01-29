using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaCountTokensContextManagementResponse,
        BetaCountTokensContextManagementResponseFromRaw
    >)
)]
public sealed record class BetaCountTokensContextManagementResponse : JsonModel
{
    /// <summary>
    /// The original token count before context management was applied
    /// </summary>
    public required long OriginalInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("original_input_tokens");
        }
        init { this._rawData.Set("original_input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OriginalInputTokens;
    }

    public BetaCountTokensContextManagementResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCountTokensContextManagementResponse(
        BetaCountTokensContextManagementResponse betaCountTokensContextManagementResponse
    )
        : base(betaCountTokensContextManagementResponse) { }
#pragma warning restore CS8618

    public BetaCountTokensContextManagementResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCountTokensContextManagementResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCountTokensContextManagementResponseFromRaw.FromRawUnchecked"/>
    public static BetaCountTokensContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCountTokensContextManagementResponse(long originalInputTokens)
        : this()
    {
        this.OriginalInputTokens = originalInputTokens;
    }
}

class BetaCountTokensContextManagementResponseFromRaw
    : IFromRawJson<BetaCountTokensContextManagementResponse>
{
    /// <inheritdoc/>
    public BetaCountTokensContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCountTokensContextManagementResponse.FromRawUnchecked(rawData);
}
