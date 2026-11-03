using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The external key changed while the request was validating it. Send the request again.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExternalKeyChangedErrorDetails,
        ExternalKeyChangedErrorDetailsFromRaw
    >)
)]
public sealed record class ExternalKeyChangedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_key_changed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ExternalKeyChangedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyChangedErrorDetails(
        ExternalKeyChangedErrorDetails externalKeyChangedErrorDetails
    )
        : base(externalKeyChangedErrorDetails) { }
#pragma warning restore CS8618

    public ExternalKeyChangedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyChangedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyChangedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ExternalKeyChangedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyChangedErrorDetailsFromRaw : IFromRawJson<ExternalKeyChangedErrorDetails>
{
    /// <inheritdoc/>
    public ExternalKeyChangedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyChangedErrorDetails.FromRawUnchecked(rawData);
}
