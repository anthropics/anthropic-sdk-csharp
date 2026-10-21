using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The Anthropic-managed service account — the default execution principal. Carries
/// no identifier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsServiceAccountExecutionIdentityParams,
        BetaManagedAgentsServiceAccountExecutionIdentityParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsServiceAccountExecutionIdentityParams : JsonModel
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

    public BetaManagedAgentsServiceAccountExecutionIdentityParams()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsServiceAccountExecutionIdentityParams(
        BetaManagedAgentsServiceAccountExecutionIdentityParams betaManagedAgentsServiceAccountExecutionIdentityParams
    )
        : base(betaManagedAgentsServiceAccountExecutionIdentityParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsServiceAccountExecutionIdentityParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsServiceAccountExecutionIdentityParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsServiceAccountExecutionIdentityParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsServiceAccountExecutionIdentityParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsServiceAccountExecutionIdentityParamsFromRaw
    : IFromRawJson<BetaManagedAgentsServiceAccountExecutionIdentityParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsServiceAccountExecutionIdentityParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsServiceAccountExecutionIdentityParams.FromRawUnchecked(rawData);
}
