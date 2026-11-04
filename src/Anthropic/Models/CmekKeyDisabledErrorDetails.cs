using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The workspace's customer-managed encryption key is disabled or revoked. Re-enable
/// the key, then retry.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CmekKeyDisabledErrorDetails, CmekKeyDisabledErrorDetailsFromRaw>)
)]
public sealed record class CmekKeyDisabledErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cmek_key_disabled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CmekKeyDisabledErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_key_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CmekKeyDisabledErrorDetails(CmekKeyDisabledErrorDetails cmekKeyDisabledErrorDetails)
        : base(cmekKeyDisabledErrorDetails) { }
#pragma warning restore CS8618

    public CmekKeyDisabledErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_key_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CmekKeyDisabledErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CmekKeyDisabledErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CmekKeyDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CmekKeyDisabledErrorDetailsFromRaw : IFromRawJson<CmekKeyDisabledErrorDetails>
{
    /// <inheritdoc/>
    public CmekKeyDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CmekKeyDisabledErrorDetails.FromRawUnchecked(rawData);
}
