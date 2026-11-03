using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// `settings.environment_id` names no Environment within the organization's reach.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaEnvironmentNotFoundErrorDetails,
        BetaEnvironmentNotFoundErrorDetailsFromRaw
    >)
)]
public sealed record class BetaEnvironmentNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("environment_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaEnvironmentNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("environment_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironmentNotFoundErrorDetails(
        BetaEnvironmentNotFoundErrorDetails betaEnvironmentNotFoundErrorDetails
    )
        : base(betaEnvironmentNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public BetaEnvironmentNotFoundErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("environment_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironmentNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaEnvironmentNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentNotFoundErrorDetailsFromRaw : IFromRawJson<BetaEnvironmentNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public BetaEnvironmentNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEnvironmentNotFoundErrorDetails.FromRawUnchecked(rawData);
}
