using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The workspace's customer-managed encryption key could not be reached. Retry the
/// request; if this continues, check that the key is available in your key management
/// service, or contact Anthropic support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CmekKeyUnreachableErrorDetails,
        CmekKeyUnreachableErrorDetailsFromRaw
    >)
)]
public sealed record class CmekKeyUnreachableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cmek_key_unreachable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CmekKeyUnreachableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_key_unreachable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CmekKeyUnreachableErrorDetails(
        CmekKeyUnreachableErrorDetails cmekKeyUnreachableErrorDetails
    )
        : base(cmekKeyUnreachableErrorDetails) { }
#pragma warning restore CS8618

    public CmekKeyUnreachableErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_key_unreachable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CmekKeyUnreachableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CmekKeyUnreachableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CmekKeyUnreachableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CmekKeyUnreachableErrorDetailsFromRaw : IFromRawJson<CmekKeyUnreachableErrorDetails>
{
    /// <inheritdoc/>
    public CmekKeyUnreachableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CmekKeyUnreachableErrorDetails.FromRawUnchecked(rawData);
}
