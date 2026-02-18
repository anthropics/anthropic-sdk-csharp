using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionTool20250825, CodeExecutionTool20250825FromRaw>)
)]
public sealed record class CodeExecutionTool20250825 : JsonModel
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<ApiEnum<string, CodeExecutionTool20250825AllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, CodeExecutionTool20250825AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, CodeExecutionTool20250825AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("code_execution")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_20250825")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.Strict;
    }

    public CodeExecutionTool20250825()
    {
        this.Name = JsonSerializer.SerializeToElement("code_execution");
        this.Type = JsonSerializer.SerializeToElement("code_execution_20250825");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionTool20250825(CodeExecutionTool20250825 codeExecutionTool20250825)
        : base(codeExecutionTool20250825) { }
#pragma warning restore CS8618

    public CodeExecutionTool20250825(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("code_execution");
        this.Type = JsonSerializer.SerializeToElement("code_execution_20250825");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionTool20250825(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionTool20250825FromRaw.FromRawUnchecked"/>
    public static CodeExecutionTool20250825 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionTool20250825FromRaw : IFromRawJson<CodeExecutionTool20250825>
{
    /// <inheritdoc/>
    public CodeExecutionTool20250825 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionTool20250825.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CodeExecutionTool20250825AllowedCallerConverter))]
public enum CodeExecutionTool20250825AllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
}

sealed class CodeExecutionTool20250825AllowedCallerConverter
    : JsonConverter<CodeExecutionTool20250825AllowedCaller>
{
    public override CodeExecutionTool20250825AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => CodeExecutionTool20250825AllowedCaller.Direct,
            "code_execution_20250825" =>
                CodeExecutionTool20250825AllowedCaller.CodeExecution20250825,
            "code_execution_20260120" =>
                CodeExecutionTool20250825AllowedCaller.CodeExecution20260120,
            _ => (CodeExecutionTool20250825AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CodeExecutionTool20250825AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CodeExecutionTool20250825AllowedCaller.Direct => "direct",
                CodeExecutionTool20250825AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                CodeExecutionTool20250825AllowedCaller.CodeExecution20260120 =>
                    "code_execution_20260120",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
