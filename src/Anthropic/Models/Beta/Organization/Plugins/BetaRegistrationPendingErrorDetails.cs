using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// The Plugin version was stored but is not yet usable in claude.ai. `plugin_id`
/// and `plugin_version_id` identify what was stored.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaRegistrationPendingErrorDetails,
        BetaRegistrationPendingErrorDetailsFromRaw
    >)
)]
public sealed record class BetaRegistrationPendingErrorDetails : JsonModel
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

    public required string PluginID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_id");
        }
        init { this._rawData.Set("plugin_id", value); }
    }

    public required string PluginVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_version_id");
        }
        init { this._rawData.Set("plugin_version_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("registration_pending")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.PluginID;
        _ = this.PluginVersionID;
    }

    public BetaRegistrationPendingErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("registration_pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRegistrationPendingErrorDetails(
        BetaRegistrationPendingErrorDetails betaRegistrationPendingErrorDetails
    )
        : base(betaRegistrationPendingErrorDetails) { }
#pragma warning restore CS8618

    public BetaRegistrationPendingErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("registration_pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRegistrationPendingErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRegistrationPendingErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRegistrationPendingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRegistrationPendingErrorDetailsFromRaw : IFromRawJson<BetaRegistrationPendingErrorDetails>
{
    /// <inheritdoc/>
    public BetaRegistrationPendingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRegistrationPendingErrorDetails.FromRawUnchecked(rawData);
}
