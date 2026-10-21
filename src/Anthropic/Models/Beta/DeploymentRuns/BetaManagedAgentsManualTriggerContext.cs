using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The run was started manually by creating a session directly against the deployment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsManualTriggerContext,
        BetaManagedAgentsManualTriggerContextFromRaw
    >)
)]
public sealed record class BetaManagedAgentsManualTriggerContext : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("manual")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsManualTriggerContext()
    {
        this.Type = JsonSerializer.SerializeToElement("manual");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsManualTriggerContext(
        BetaManagedAgentsManualTriggerContext betaManagedAgentsManualTriggerContext
    )
        : base(betaManagedAgentsManualTriggerContext) { }
#pragma warning restore CS8618

    public BetaManagedAgentsManualTriggerContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("manual");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsManualTriggerContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsManualTriggerContextFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsManualTriggerContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsManualTriggerContextFromRaw
    : IFromRawJson<BetaManagedAgentsManualTriggerContext>
{
    /// <inheritdoc/>
    public BetaManagedAgentsManualTriggerContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsManualTriggerContext.FromRawUnchecked(rawData);
}
