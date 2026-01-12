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
    typeof(JsonModelConverter<BetaToolComputerUse20250124, BetaToolComputerUse20250124FromRaw>)
)]
public sealed record class BetaToolComputerUse20250124 : JsonModel
{
    /// <summary>
    /// The height of the display in pixels.
    /// </summary>
    public required long DisplayHeightPx
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "display_height_px"); }
        init { JsonModel.Set(this._rawData, "display_height_px", value); }
    }

    /// <summary>
    /// The width of the display in pixels.
    /// </summary>
    public required long DisplayWidthPx
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "display_width_px"); }
        init { JsonModel.Set(this._rawData, "display_width_px", value); }
    }

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

    public IReadOnlyList<ApiEnum<string, BetaToolComputerUse20250124AllowedCaller>>? AllowedCallers
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<ApiEnum<string, BetaToolComputerUse20250124AllowedCaller>>
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

    /// <summary>
    /// The X11 display number (e.g. 0, 1) for the display.
    /// </summary>
    public long? DisplayNumber
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "display_number"); }
        init { JsonModel.Set(this._rawData, "display_number", value); }
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
        _ = this.DisplayHeightPx;
        _ = this.DisplayWidthPx;
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"computer\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"computer_20250124\"")
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
        _ = this.DisplayNumber;
        _ = this.InputExamples;
        _ = this.Strict;
    }

    public BetaToolComputerUse20250124()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"computer\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"computer_20250124\"");
    }

    public BetaToolComputerUse20250124(BetaToolComputerUse20250124 betaToolComputerUse20250124)
        : base(betaToolComputerUse20250124) { }

    public BetaToolComputerUse20250124(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"computer\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"computer_20250124\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolComputerUse20250124(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolComputerUse20250124FromRaw.FromRawUnchecked"/>
    public static BetaToolComputerUse20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolComputerUse20250124FromRaw : IFromRawJson<BetaToolComputerUse20250124>
{
    /// <inheritdoc/>
    public BetaToolComputerUse20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolComputerUse20250124.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolComputerUse20250124AllowedCallerConverter))]
public enum BetaToolComputerUse20250124AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaToolComputerUse20250124AllowedCallerConverter
    : JsonConverter<BetaToolComputerUse20250124AllowedCaller>
{
    public override BetaToolComputerUse20250124AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaToolComputerUse20250124AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaToolComputerUse20250124AllowedCaller.CodeExecution20250825,
            _ => (BetaToolComputerUse20250124AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolComputerUse20250124AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolComputerUse20250124AllowedCaller.Direct => "direct",
                BetaToolComputerUse20250124AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
