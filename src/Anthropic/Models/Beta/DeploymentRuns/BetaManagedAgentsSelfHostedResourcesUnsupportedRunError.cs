using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The deployment configures resources, but its environment is self-hosted and cannot
/// mount them.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError,
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSelfHostedResourcesUnsupportedRunError : JsonModel
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
                JsonSerializer.SerializeToElement("self_hosted_resources_unsupported_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("self_hosted_resources_unsupported_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError betaManagedAgentsSelfHostedResourcesUnsupportedRunError
    )
        : base(betaManagedAgentsSelfHostedResourcesUnsupportedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("self_hosted_resources_unsupported_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSelfHostedResourcesUnsupportedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSelfHostedResourcesUnsupportedRunError.FromRawUnchecked(rawData);
}
