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

[JsonConverter(
    typeof(JsonModelConverter<
        BetaToolSearchToolRegex20251119,
        BetaToolSearchToolRegex20251119FromRaw
    >)
)]
public sealed record class BetaToolSearchToolRegex20251119 : JsonModel
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

    public required ApiEnum<string, BetaToolSearchToolRegex20251119Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaToolSearchToolRegex20251119Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<
        ApiEnum<string, BetaToolSearchToolRegex20251119AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaToolSearchToolRegex20251119AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, BetaToolSearchToolRegex20251119AllowedCaller>
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
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.SerializeToElement("tool_search_tool_regex")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Type.Validate();
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.Strict;
    }

    public BetaToolSearchToolRegex20251119()
    {
        this.Name = JsonSerializer.SerializeToElement("tool_search_tool_regex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolSearchToolRegex20251119(
        BetaToolSearchToolRegex20251119 betaToolSearchToolRegex20251119
    )
        : base(betaToolSearchToolRegex20251119) { }
#pragma warning restore CS8618

    public BetaToolSearchToolRegex20251119(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("tool_search_tool_regex");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolRegex20251119(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolSearchToolRegex20251119FromRaw.FromRawUnchecked"/>
    public static BetaToolSearchToolRegex20251119 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolSearchToolRegex20251119(
        ApiEnum<string, BetaToolSearchToolRegex20251119Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaToolSearchToolRegex20251119FromRaw : IFromRawJson<BetaToolSearchToolRegex20251119>
{
    /// <inheritdoc/>
    public BetaToolSearchToolRegex20251119 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolRegex20251119.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolRegex20251119TypeConverter))]
public enum BetaToolSearchToolRegex20251119Type
{
    ToolSearchToolRegex20251119,
    ToolSearchToolRegex,
}

sealed class BetaToolSearchToolRegex20251119TypeConverter
    : JsonConverter<BetaToolSearchToolRegex20251119Type>
{
    public override BetaToolSearchToolRegex20251119Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tool_search_tool_regex_20251119" =>
                BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            "tool_search_tool_regex" => BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex,
            _ => (BetaToolSearchToolRegex20251119Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolRegex20251119Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119 =>
                    "tool_search_tool_regex_20251119",
                BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex => "tool_search_tool_regex",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaToolSearchToolRegex20251119AllowedCallerConverter))]
public enum BetaToolSearchToolRegex20251119AllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
}

sealed class BetaToolSearchToolRegex20251119AllowedCallerConverter
    : JsonConverter<BetaToolSearchToolRegex20251119AllowedCaller>
{
    public override BetaToolSearchToolRegex20251119AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaToolSearchToolRegex20251119AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaToolSearchToolRegex20251119AllowedCaller.CodeExecution20250825,
            "code_execution_20260120" =>
                BetaToolSearchToolRegex20251119AllowedCaller.CodeExecution20260120,
            _ => (BetaToolSearchToolRegex20251119AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolRegex20251119AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolSearchToolRegex20251119AllowedCaller.Direct => "direct",
                BetaToolSearchToolRegex20251119AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                BetaToolSearchToolRegex20251119AllowedCaller.CodeExecution20260120 =>
                    "code_execution_20260120",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
