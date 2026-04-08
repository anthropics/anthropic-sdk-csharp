using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Specification for an Agent. Provide a specific `version` or use the short-form
/// `agent="agent_id"` for the most recent version
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsAgentParams, BetaManagedAgentsAgentParamsFromRaw>)
)]
public sealed record class BetaManagedAgentsAgentParams : JsonModel
{
    /// <summary>
    /// The `agent` ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The specific `agent` version to use. Omit to use the latest version. Must
    /// be at least 1 if specified.
    /// </summary>
    public int? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaManagedAgentsAgentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentParams(BetaManagedAgentsAgentParams betaManagedAgentsAgentParams)
        : base(betaManagedAgentsAgentParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentParamsFromRaw : IFromRawJson<BetaManagedAgentsAgentParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Agent,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Type>
{
    public override global::Anthropic.Models.Beta.Sessions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent" => global::Anthropic.Models.Beta.Sessions.Type.Agent,
            _ => (global::Anthropic.Models.Beta.Sessions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Sessions.Type.Agent => "agent",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
