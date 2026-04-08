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
/// A custom tool as returned in API responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsCustomTool, BetaManagedAgentsCustomToolFromRaw>)
)]
public sealed record class BetaManagedAgentsCustomTool : JsonModel
{
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

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsCustomToolType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsCustomToolType>>(
                "type"
            );
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

    public BetaManagedAgentsCustomTool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCustomTool(BetaManagedAgentsCustomTool betaManagedAgentsCustomTool)
        : base(betaManagedAgentsCustomTool) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCustomTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCustomTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCustomToolFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCustomTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCustomToolFromRaw : IFromRawJson<BetaManagedAgentsCustomTool>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCustomTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCustomTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsCustomToolTypeConverter))]
public enum BetaManagedAgentsCustomToolType
{
    Custom,
}

sealed class BetaManagedAgentsCustomToolTypeConverter
    : JsonConverter<BetaManagedAgentsCustomToolType>
{
    public override BetaManagedAgentsCustomToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => BetaManagedAgentsCustomToolType.Custom,
            _ => (BetaManagedAgentsCustomToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCustomToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCustomToolType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
