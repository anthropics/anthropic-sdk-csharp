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
/// The deployment's agent was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentArchivedRunError,
        BetaManagedAgentsAgentArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentArchivedRunError : JsonModel
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

    public required ApiEnum<string, global::Anthropic.Models.Beta.DeploymentRuns.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.DeploymentRuns.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsAgentArchivedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentArchivedRunError(
        BetaManagedAgentsAgentArchivedRunError betaManagedAgentsAgentArchivedRunError
    )
        : base(betaManagedAgentsAgentArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentArchivedRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsAgentArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentArchivedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AgentArchivedError,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.DeploymentRuns.Type>
{
    public override global::Anthropic.Models.Beta.DeploymentRuns.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_archived_error" => global::Anthropic
                .Models
                .Beta
                .DeploymentRuns
                .Type
                .AgentArchivedError,
            _ => (global::Anthropic.Models.Beta.DeploymentRuns.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.DeploymentRuns.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.DeploymentRuns.Type.AgentArchivedError =>
                    "agent_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
