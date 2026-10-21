using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The deployment's organization is disabled.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsOrganizationDisabledRunError,
        BetaManagedAgentsOrganizationDisabledRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsOrganizationDisabledRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("organization_disabled_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsOrganizationDisabledRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("organization_disabled_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsOrganizationDisabledRunError(
        BetaManagedAgentsOrganizationDisabledRunError betaManagedAgentsOrganizationDisabledRunError
    )
        : base(betaManagedAgentsOrganizationDisabledRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsOrganizationDisabledRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization_disabled_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsOrganizationDisabledRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsOrganizationDisabledRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsOrganizationDisabledRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsOrganizationDisabledRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsOrganizationDisabledRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsOrganizationDisabledRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsOrganizationDisabledRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsOrganizationDisabledRunError.FromRawUnchecked(rawData);
}
