using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<Tool, ToolFromRaw>))]
public sealed record class Tool : ModelBase
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
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

    public ApiEnum<string, global::Anthropic.Models.Messages.Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, global::Anthropic.Models.Messages.Type>
            >(this.RawData, "type");
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InputSchema.Validate();
        _ = this.Name;
        this.CacheControl?.Validate();
        _ = this.Description;
        this.Type?.Validate();
    }

    public Tool() { }

    public Tool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolFromRaw.FromRawUnchecked"/>
    public static Tool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolFromRaw : IFromRaw<Tool>
{
    /// <inheritdoc/>
    public Tool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tool.FromRawUnchecked(rawData);
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

    /// <inheritdoc/>
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

    /// <inheritdoc cref="InputSchemaFromRaw.FromRawUnchecked"/>
    public static InputSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputSchemaFromRaw : IFromRaw<InputSchema>
{
    /// <inheritdoc/>
    public InputSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputSchema.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Custom,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Messages.Type>
{
    public override global::Anthropic.Models.Messages.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => global::Anthropic.Models.Messages.Type.Custom,
            _ => (global::Anthropic.Models.Messages.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Messages.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Messages.Type.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
