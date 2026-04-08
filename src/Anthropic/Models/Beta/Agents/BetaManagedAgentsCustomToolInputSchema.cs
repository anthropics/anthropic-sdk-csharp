using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// JSON Schema for custom tool input parameters.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCustomToolInputSchema,
        BetaManagedAgentsCustomToolInputSchemaFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCustomToolInputSchema : JsonModel
{
    /// <summary>
    /// JSON Schema properties defining the tool's input parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// List of required property names.
    /// </summary>
    public IReadOnlyList<string>? Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("required");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Must be 'object' for tool input schemas.
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsCustomToolInputSchemaType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsCustomToolInputSchemaType>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public BetaManagedAgentsCustomToolInputSchema() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCustomToolInputSchema(
        BetaManagedAgentsCustomToolInputSchema betaManagedAgentsCustomToolInputSchema
    )
        : base(betaManagedAgentsCustomToolInputSchema) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCustomToolInputSchema(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCustomToolInputSchema(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCustomToolInputSchemaFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCustomToolInputSchema FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCustomToolInputSchemaFromRaw
    : IFromRawJson<BetaManagedAgentsCustomToolInputSchema>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCustomToolInputSchema FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCustomToolInputSchema.FromRawUnchecked(rawData);
}

/// <summary>
/// Must be 'object' for tool input schemas.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsCustomToolInputSchemaTypeConverter))]
public enum BetaManagedAgentsCustomToolInputSchemaType
{
    Object,
}

sealed class BetaManagedAgentsCustomToolInputSchemaTypeConverter
    : JsonConverter<BetaManagedAgentsCustomToolInputSchemaType>
{
    public override BetaManagedAgentsCustomToolInputSchemaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => BetaManagedAgentsCustomToolInputSchemaType.Object,
            _ => (BetaManagedAgentsCustomToolInputSchemaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCustomToolInputSchemaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCustomToolInputSchemaType.Object => "object",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
