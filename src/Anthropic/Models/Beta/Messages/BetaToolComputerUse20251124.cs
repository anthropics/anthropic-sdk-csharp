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
    typeof(ModelConverter<BetaToolComputerUse20251124, BetaToolComputerUse20251124FromRaw>)
)]
public sealed record class BetaToolComputerUse20251124 : ModelBase
{
    /// <summary>
    /// The height of the display in pixels.
    /// </summary>
    public required long DisplayHeightPx
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "display_height_px"); }
        init { ModelBase.Set(this._rawData, "display_height_px", value); }
    }

    /// <summary>
    /// The width of the display in pixels.
    /// </summary>
    public required long DisplayWidthPx
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "display_width_px"); }
        init { ModelBase.Set(this._rawData, "display_width_px", value); }
    }

    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public IReadOnlyList<ApiEnum<string, BetaToolComputerUse20251124AllowedCaller>>? AllowedCallers
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, BetaToolComputerUse20251124AllowedCaller>>
            >(this.RawData, "allowed_callers");
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
    /// The X11 display number (e.g. 0, 1) for the display.
    /// </summary>
    public long? DisplayNumber
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "display_number"); }
        init { ModelBase.Set(this._rawData, "display_number", value); }
    }

    /// <summary>
    /// Whether to enable an action to take a zoomed-in screenshot of the screen.
    /// </summary>
    public bool? EnableZoom
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "enable_zoom"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "enable_zoom", value);
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
                JsonSerializer.Deserialize<JsonElement>("\"computer_20251124\"")
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
        _ = this.EnableZoom;
        _ = this.InputExamples;
        _ = this.Strict;
    }

    public BetaToolComputerUse20251124()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"computer\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"computer_20251124\"");
    }

    public BetaToolComputerUse20251124(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"computer\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"computer_20251124\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolComputerUse20251124(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolComputerUse20251124FromRaw.FromRawUnchecked"/>
    public static BetaToolComputerUse20251124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolComputerUse20251124FromRaw : IFromRaw<BetaToolComputerUse20251124>
{
    /// <inheritdoc/>
    public BetaToolComputerUse20251124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolComputerUse20251124.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolComputerUse20251124AllowedCallerConverter))]
public enum BetaToolComputerUse20251124AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaToolComputerUse20251124AllowedCallerConverter
    : JsonConverter<BetaToolComputerUse20251124AllowedCaller>
{
    public override BetaToolComputerUse20251124AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaToolComputerUse20251124AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaToolComputerUse20251124AllowedCaller.CodeExecution20250825,
            _ => (BetaToolComputerUse20251124AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolComputerUse20251124AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolComputerUse20251124AllowedCaller.Direct => "direct",
                BetaToolComputerUse20251124AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
