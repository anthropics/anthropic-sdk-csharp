using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// The environment is archived, so it cannot be updated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaEnvironmentArchivedErrorDetails,
        BetaEnvironmentArchivedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaEnvironmentArchivedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("environment_archived")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaEnvironmentArchivedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("environment_archived");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironmentArchivedErrorDetails(
        BetaEnvironmentArchivedErrorDetails betaEnvironmentArchivedErrorDetails
    )
        : base(betaEnvironmentArchivedErrorDetails) { }
#pragma warning restore CS8618

    public BetaEnvironmentArchivedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("environment_archived");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironmentArchivedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentArchivedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaEnvironmentArchivedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentArchivedErrorDetailsFromRaw : IFromRawJson<BetaEnvironmentArchivedErrorDetails>
{
    /// <inheritdoc/>
    public BetaEnvironmentArchivedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEnvironmentArchivedErrorDetails.FromRawUnchecked(rawData);
}
