using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// A custom tool that is executed by the API client rather than the agent. When the
/// agent calls this tool, an `agent.custom_tool_use` event is emitted and the session
/// goes idle, waiting for the client to provide the result via a `user.custom_tool_result` event.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCustomToolParams,
        BetaManagedAgentsCustomToolParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCustomToolParams : JsonModel
{
    /// <summary>
    /// Description of what the tool does, shown to the agent to help it decide when
    /// to use the tool. 1-1024 characters.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// JSON Schema for custom tool input parameters.
    /// </summary>
    public required BetaManagedAgentsCustomToolInputSchema InputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsCustomToolInputSchema>(
                "input_schema"
            );
        }
        init { this._rawData.Set("input_schema", value); }
    }

    /// <summary>
    /// Unique name for the tool. 1-128 characters; letters, digits, underscores,
    /// and hyphens.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsCustomToolParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsCustomToolParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        this.InputSchema.Validate();
        _ = this.Name;
        this.Type.Validate();
    }

    public BetaManagedAgentsCustomToolParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCustomToolParams(
        BetaManagedAgentsCustomToolParams betaManagedAgentsCustomToolParams
    )
        : base(betaManagedAgentsCustomToolParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCustomToolParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCustomToolParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCustomToolParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCustomToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCustomToolParamsFromRaw : IFromRawJson<BetaManagedAgentsCustomToolParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCustomToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCustomToolParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsCustomToolParamsTypeConverter))]
public enum BetaManagedAgentsCustomToolParamsType
{
    Custom,
}

sealed class BetaManagedAgentsCustomToolParamsTypeConverter
    : JsonConverter<BetaManagedAgentsCustomToolParamsType>
{
    public override BetaManagedAgentsCustomToolParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => BetaManagedAgentsCustomToolParamsType.Custom,
            _ => (BetaManagedAgentsCustomToolParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCustomToolParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCustomToolParamsType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
