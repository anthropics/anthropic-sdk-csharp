using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request's workspace encryption context could not be resolved, so the request
/// was refused. Retry in a few minutes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CmekContextUnavailableErrorDetails,
        CmekContextUnavailableErrorDetailsFromRaw
    >)
)]
public sealed record class CmekContextUnavailableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cmek_context_unavailable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CmekContextUnavailableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_context_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CmekContextUnavailableErrorDetails(
        CmekContextUnavailableErrorDetails cmekContextUnavailableErrorDetails
    )
        : base(cmekContextUnavailableErrorDetails) { }
#pragma warning restore CS8618

    public CmekContextUnavailableErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_context_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CmekContextUnavailableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CmekContextUnavailableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CmekContextUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CmekContextUnavailableErrorDetailsFromRaw : IFromRawJson<CmekContextUnavailableErrorDetails>
{
    /// <inheritdoc/>
    public CmekContextUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CmekContextUnavailableErrorDetails.FromRawUnchecked(rawData);
}
