using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The Anthropic-managed service account as returned in API responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsServiceAccountExecutionIdentity,
        BetaManagedAgentsServiceAccountExecutionIdentityFromRaw
    >)
)]
public sealed record class BetaManagedAgentsServiceAccountExecutionIdentity : JsonModel
{
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
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("service_account"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsServiceAccountExecutionIdentity()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsServiceAccountExecutionIdentity(
        BetaManagedAgentsServiceAccountExecutionIdentity betaManagedAgentsServiceAccountExecutionIdentity
    )
        : base(betaManagedAgentsServiceAccountExecutionIdentity) { }
#pragma warning restore CS8618

    public BetaManagedAgentsServiceAccountExecutionIdentity(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsServiceAccountExecutionIdentity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsServiceAccountExecutionIdentityFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsServiceAccountExecutionIdentity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsServiceAccountExecutionIdentityFromRaw
    : IFromRawJson<BetaManagedAgentsServiceAccountExecutionIdentity>
{
    /// <inheritdoc/>
    public BetaManagedAgentsServiceAccountExecutionIdentity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsServiceAccountExecutionIdentity.FromRawUnchecked(rawData);
}
