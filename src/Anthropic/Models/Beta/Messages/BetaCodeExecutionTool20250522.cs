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
    typeof(JsonModelConverter<BetaCodeExecutionTool20250522, BetaCodeExecutionTool20250522FromRaw>)
)]
public sealed record class BetaCodeExecutionTool20250522 : JsonModel
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

    public IReadOnlyList<ApiEnum<string, AllowedCaller>>? AllowedCallers
    {
        get
        {
            return JsonModel.GetNullableClass<List<ApiEnum<string, AllowedCaller>>>(
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
                JsonSerializer.Deserialize<JsonElement>("\"code_execution\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250522\"")
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

    public BetaCodeExecutionTool20250522()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250522\"");
    }

    public BetaCodeExecutionTool20250522(
        BetaCodeExecutionTool20250522 betaCodeExecutionTool20250522
    )
        : base(betaCodeExecutionTool20250522) { }

    public BetaCodeExecutionTool20250522(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250522\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionTool20250522(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionTool20250522FromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionTool20250522 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCodeExecutionTool20250522FromRaw : IFromRawJson<BetaCodeExecutionTool20250522>
{
    /// <inheritdoc/>
    public BetaCodeExecutionTool20250522 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionTool20250522.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AllowedCallerConverter))]
public enum AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class AllowedCallerConverter : JsonConverter<AllowedCaller>
{
    public override AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => AllowedCaller.Direct,
            "code_execution_20250825" => AllowedCaller.CodeExecution20250825,
            _ => (AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllowedCaller.Direct => "direct",
                AllowedCaller.CodeExecution20250825 => "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
