using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTool, BetaToolFromRaw>))]
public sealed record class BetaTool : ModelBase
{
    /// <summary>
    /// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
    ///
    /// <para>This defines the shape of the `input` that your tool accepts and that
    /// the model will produce.</para>
    /// </summary>
    public required InputSchema InputSchema
    {
        get { return ModelBase.GetNotNullClass<InputSchema>(this.RawData, "input_schema"); }
        init { ModelBase.Set(this._rawData, "input_schema", value); }
    }

    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public IReadOnlyList<ApiEnum<string, BetaToolAllowedCaller>>? AllowedCallers
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, BetaToolAllowedCaller>>>(
                this.RawData,
                "allowed_callers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "allowed_callers", value);
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "defer_loading"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "defer_loading", value);
        }
    }

    /// <summary>
    /// Description of what this tool does.
    ///
    /// <para>Tool descriptions should be as detailed as possible. The more information
    /// that the model has about what the tool is and how to use it, the better it
    /// will perform. You can use natural language descriptions to reinforce important
    /// aspects of the tool input JSON schema.</para>
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "description", value);
        }
    }

    public IReadOnlyList<Dictionary<string, JsonElement>>? InputExamples
    {
        get
        {
            return ModelBase.GetNullableClass<List<Dictionary<string, JsonElement>>>(
                this.RawData,
                "input_examples"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "input_examples", value);
        }
    }

    public bool? Strict
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "strict"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "strict", value);
        }
    }

    public ApiEnum<string, BetaToolType>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, BetaToolType>>(this.RawData, "type");
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public override void Validate()
    {
        this.InputSchema.Validate();
        _ = this.Name;
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.Description;
        _ = this.InputExamples;
        _ = this.Strict;
        this.Type?.Validate();
    }

    public BetaTool() { }

    public BetaTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolFromRaw : IFromRaw<BetaTool>
{
    public BetaTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTool.FromRawUnchecked(rawData);
}

/// <summary>
/// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
///
/// <para>This defines the shape of the `input` that your tool accepts and that the
/// model will produce.</para>
/// </summary>
[JsonConverter(typeof(ModelConverter<InputSchema, InputSchemaFromRaw>))]
public sealed record class InputSchema : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Properties
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "properties"
            );
        }
        init { ModelBase.Set(this._rawData, "properties", value); }
    }

    public IReadOnlyList<string>? Required
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "required"); }
        init { ModelBase.Set(this._rawData, "required", value); }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"object\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Properties;
        _ = this.Required;
    }

    public InputSchema()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"object\"");
    }

    public InputSchema(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"object\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputSchema(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static InputSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputSchemaFromRaw : IFromRaw<InputSchema>
{
    public InputSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputSchema.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolAllowedCallerConverter))]
public enum BetaToolAllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaToolAllowedCallerConverter : JsonConverter<BetaToolAllowedCaller>
{
    public override BetaToolAllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaToolAllowedCaller.Direct,
            "code_execution_20250825" => BetaToolAllowedCaller.CodeExecution20250825,
            _ => (BetaToolAllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolAllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolAllowedCaller.Direct => "direct",
                BetaToolAllowedCaller.CodeExecution20250825 => "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaToolTypeConverter))]
public enum BetaToolType
{
    Custom,
}

sealed class BetaToolTypeConverter : JsonConverter<BetaToolType>
{
    public override BetaToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => BetaToolType.Custom,
            _ => (BetaToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
