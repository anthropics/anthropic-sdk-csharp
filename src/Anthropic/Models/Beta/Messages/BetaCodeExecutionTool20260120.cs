using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Code execution tool with REPL state persistence (daemon mode + gVisor checkpoint).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaCodeExecutionTool20260120, BetaCodeExecutionTool20260120FromRaw>)
)]
public sealed record class BetaCodeExecutionTool20260120 : JsonModel
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

    public IReadOnlyList<
        ApiEnum<string, BetaCodeExecutionTool20260120AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaCodeExecutionTool20260120AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, BetaCodeExecutionTool20260120AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
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
                JsonSerializer.SerializeToElement("code_execution_20260120")
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

    public BetaCodeExecutionTool20260120()
    {
        this.Name = JsonSerializer.SerializeToElement("code_execution");
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCodeExecutionTool20260120(
        BetaCodeExecutionTool20260120 betaCodeExecutionTool20260120
    )
        : base(betaCodeExecutionTool20260120) { }
#pragma warning restore CS8618

    public BetaCodeExecutionTool20260120(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("code_execution");
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionTool20260120(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionTool20260120FromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionTool20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCodeExecutionTool20260120FromRaw : IFromRawJson<BetaCodeExecutionTool20260120>
{
    /// <inheritdoc/>
    public BetaCodeExecutionTool20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionTool20260120.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaCodeExecutionTool20260120AllowedCallerConverter))]
public enum BetaCodeExecutionTool20260120AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaCodeExecutionTool20260120AllowedCallerConverter
    : JsonConverter<BetaCodeExecutionTool20260120AllowedCaller>
{
    public override BetaCodeExecutionTool20260120AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaCodeExecutionTool20260120AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaCodeExecutionTool20260120AllowedCaller.CodeExecution20250825,
            _ => (BetaCodeExecutionTool20260120AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionTool20260120AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaCodeExecutionTool20260120AllowedCaller.Direct => "direct",
                BetaCodeExecutionTool20260120AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
