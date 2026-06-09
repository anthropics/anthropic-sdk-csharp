using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    public required ApiEnum<string, BetaManagedAgentsManualTriggerContextType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsManualTriggerContextType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsManualTriggerContext() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsManualTriggerContext(
        ApiEnum<string, BetaManagedAgentsManualTriggerContextType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(typeof(BetaManagedAgentsManualTriggerContextTypeConverter))]
public enum BetaManagedAgentsManualTriggerContextType
{
    Manual,
}

sealed class BetaManagedAgentsManualTriggerContextTypeConverter
    : JsonConverter<BetaManagedAgentsManualTriggerContextType>
{
    public override BetaManagedAgentsManualTriggerContextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual" => BetaManagedAgentsManualTriggerContextType.Manual,
            _ => (BetaManagedAgentsManualTriggerContextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsManualTriggerContextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsManualTriggerContextType.Manual => "manual",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
