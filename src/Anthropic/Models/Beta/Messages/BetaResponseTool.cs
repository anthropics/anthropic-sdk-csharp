using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A custom tool definition, as sent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaResponseTool, BetaResponseToolFromRaw>))]
public sealed record class BetaResponseTool : JsonModel
{
    /// <summary>
    /// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
    ///
    /// <para>This defines the shape of the `input` that your tool accepts and that
    /// the model will produce.</para>
    /// </summary>
    public required BetaResponseToolInputSchema InputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaResponseToolInputSchema>("input_schema");
        }
        init { this._rawData.Set("input_schema", value); }
    }

    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
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

    public IReadOnlyList<ApiEnum<string, BetaResponseToolAllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaResponseToolAllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, BetaResponseToolAllowedCaller>>?>(
                "allowed_callers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defer_loading", value);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Enable eager input streaming for this tool. When true, tool input parameters
    /// will be streamed incrementally as they are generated, and types will be inferred
    /// on-the-fly rather than buffering the full JSON output. When false, streaming
    /// is disabled for this tool even if the fine-grained-tool-streaming beta is
    /// active. When null (default), uses the default behavior based on beta headers.
    /// </summary>
    public bool? EagerInputStreaming
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("eager_input_streaming");
        }
        init { this._rawData.Set("eager_input_streaming", value); }
    }

    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? InputExamples
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("input_examples");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "input_examples",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    /// <summary>
    /// When true, guarantees schema validation on tool names and inputs
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict", value);
        }
    }

    public ApiEnum<string, BetaResponseToolType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaResponseToolType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InputSchema.Validate();
        _ = this.Name;
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        _ = this.DeferLoading;
        _ = this.Description;
        _ = this.EagerInputStreaming;
        _ = this.InputExamples;
        _ = this.Strict;
        this.Type?.Validate();
    }

    public BetaResponseTool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaResponseTool(BetaResponseTool betaResponseTool)
        : base(betaResponseTool) { }
#pragma warning restore CS8618

    public BetaResponseTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaResponseTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaResponseToolFromRaw.FromRawUnchecked"/>
    public static BetaResponseTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaResponseToolFromRaw : IFromRawJson<BetaResponseTool>
{
    /// <inheritdoc/>
    public BetaResponseTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaResponseTool.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies who can invoke a tool.
///
/// <para>Values:     direct: The model can call this tool directly.     code_execution_20250825:
/// The tool can be called from the code execution environment (v1).     code_execution_20260120:
/// The tool can be called from the code execution environment (v2 with persistence).
///     code_execution_20260521: The tool can be called from the code execution environment
/// (v2 with persistence).</para>
/// </summary>
[JsonConverter(typeof(BetaResponseToolAllowedCallerConverter))]
public enum BetaResponseToolAllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
    CodeExecution20260521,
}

sealed class BetaResponseToolAllowedCallerConverter : JsonConverter<BetaResponseToolAllowedCaller>
{
    public override BetaResponseToolAllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaResponseToolAllowedCaller.Direct,
            "code_execution_20250825" => BetaResponseToolAllowedCaller.CodeExecution20250825,
            "code_execution_20260120" => BetaResponseToolAllowedCaller.CodeExecution20260120,
            "code_execution_20260521" => BetaResponseToolAllowedCaller.CodeExecution20260521,
            _ => (BetaResponseToolAllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaResponseToolAllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaResponseToolAllowedCaller.Direct => "direct",
                BetaResponseToolAllowedCaller.CodeExecution20250825 => "code_execution_20250825",
                BetaResponseToolAllowedCaller.CodeExecution20260120 => "code_execution_20260120",
                BetaResponseToolAllowedCaller.CodeExecution20260521 => "code_execution_20260521",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaResponseToolTypeConverter))]
public enum BetaResponseToolType
{
    Custom,
}

sealed class BetaResponseToolTypeConverter : JsonConverter<BetaResponseToolType>
{
    public override BetaResponseToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => BetaResponseToolType.Custom,
            _ => (BetaResponseToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaResponseToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaResponseToolType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
