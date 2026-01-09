using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaToolTextEditor20250124, BetaToolTextEditor20250124FromRaw>)
)]
public sealed record class BetaToolTextEditor20250124 : JsonModel
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public IReadOnlyList<ApiEnum<string, BetaToolTextEditor20250124AllowedCaller>>? AllowedCallers
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<ApiEnum<string, BetaToolTextEditor20250124AllowedCaller>>
            >(this.RawData, "allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "allowed_callers", value);
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return JsonModel.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { JsonModel.Set(this._rawData, "cache_control", value); }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "defer_loading"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "defer_loading", value);
        }
    }

    public IReadOnlyList<Dictionary<string, JsonElement>>? InputExamples
    {
        get
        {
            return JsonModel.GetNullableClass<List<Dictionary<string, JsonElement>>>(
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

            JsonModel.Set(this._rawData, "input_examples", value);
        }
    }

    public bool? Strict
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "strict"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "strict", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"str_replace_editor\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250124\"")
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

    public BetaToolTextEditor20250124()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_editor\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250124\"");
    }

    public BetaToolTextEditor20250124(BetaToolTextEditor20250124 betaToolTextEditor20250124)
        : base(betaToolTextEditor20250124) { }

    public BetaToolTextEditor20250124(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_editor\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250124\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolTextEditor20250124(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolTextEditor20250124FromRaw.FromRawUnchecked"/>
    public static BetaToolTextEditor20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolTextEditor20250124FromRaw : IFromRawJson<BetaToolTextEditor20250124>
{
    /// <inheritdoc/>
    public BetaToolTextEditor20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolTextEditor20250124.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolTextEditor20250124AllowedCallerConverter))]
public enum BetaToolTextEditor20250124AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaToolTextEditor20250124AllowedCallerConverter
    : JsonConverter<BetaToolTextEditor20250124AllowedCaller>
{
    public override BetaToolTextEditor20250124AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaToolTextEditor20250124AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaToolTextEditor20250124AllowedCaller.CodeExecution20250825,
            _ => (BetaToolTextEditor20250124AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolTextEditor20250124AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolTextEditor20250124AllowedCaller.Direct => "direct",
                BetaToolTextEditor20250124AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
