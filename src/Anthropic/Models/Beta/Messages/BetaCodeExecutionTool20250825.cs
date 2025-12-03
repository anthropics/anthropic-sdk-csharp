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
    typeof(ModelConverter<BetaCodeExecutionTool20250825, BetaCodeExecutionTool20250825FromRaw>)
)]
public sealed record class BetaCodeExecutionTool20250825 : ModelBase
{
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

    public IReadOnlyList<
        ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>>
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
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"code_execution\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250825\"")
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

    public BetaCodeExecutionTool20250825()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250825\"");
    }

    public BetaCodeExecutionTool20250825(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250825\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionTool20250825(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionTool20250825FromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionTool20250825 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCodeExecutionTool20250825FromRaw : IFromRaw<BetaCodeExecutionTool20250825>
{
    /// <inheritdoc/>
    public BetaCodeExecutionTool20250825 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionTool20250825.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaCodeExecutionTool20250825AllowedCallerConverter))]
public enum BetaCodeExecutionTool20250825AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaCodeExecutionTool20250825AllowedCallerConverter
    : JsonConverter<BetaCodeExecutionTool20250825AllowedCaller>
{
    public override BetaCodeExecutionTool20250825AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaCodeExecutionTool20250825AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaCodeExecutionTool20250825AllowedCaller.CodeExecution20250825,
            _ => (BetaCodeExecutionTool20250825AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionTool20250825AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaCodeExecutionTool20250825AllowedCaller.Direct => "direct",
                BetaCodeExecutionTool20250825AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
