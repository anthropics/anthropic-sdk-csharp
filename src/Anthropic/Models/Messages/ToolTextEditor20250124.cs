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

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ToolTextEditor20250124, ToolTextEditor20250124FromRaw>))]
public sealed record class ToolTextEditor20250124 : JsonModel
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

    public IReadOnlyList<ApiEnum<string, ToolTextEditor20250124AllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ToolTextEditor20250124AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ToolTextEditor20250124AllowedCaller>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.SerializeToElement("str_replace_editor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_20250124")
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
        _ = this.InputExamples;
        _ = this.Strict;
    }

    public ToolTextEditor20250124()
    {
        this.Name = JsonSerializer.SerializeToElement("str_replace_editor");
        this.Type = JsonSerializer.SerializeToElement("text_editor_20250124");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolTextEditor20250124(ToolTextEditor20250124 toolTextEditor20250124)
        : base(toolTextEditor20250124) { }
#pragma warning restore CS8618

    public ToolTextEditor20250124(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("str_replace_editor");
        this.Type = JsonSerializer.SerializeToElement("text_editor_20250124");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolTextEditor20250124(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolTextEditor20250124FromRaw.FromRawUnchecked"/>
    public static ToolTextEditor20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolTextEditor20250124FromRaw : IFromRawJson<ToolTextEditor20250124>
{
    /// <inheritdoc/>
    public ToolTextEditor20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolTextEditor20250124.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolTextEditor20250124AllowedCallerConverter))]
public enum ToolTextEditor20250124AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class ToolTextEditor20250124AllowedCallerConverter
    : JsonConverter<ToolTextEditor20250124AllowedCaller>
{
    public override ToolTextEditor20250124AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => ToolTextEditor20250124AllowedCaller.Direct,
            "code_execution_20250825" => ToolTextEditor20250124AllowedCaller.CodeExecution20250825,
            _ => (ToolTextEditor20250124AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolTextEditor20250124AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolTextEditor20250124AllowedCaller.Direct => "direct",
                ToolTextEditor20250124AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
