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
    typeof(ModelConverter<BetaToolSearchToolBm25_20251119, BetaToolSearchToolBm25_20251119FromRaw>)
)]
public sealed record class BetaToolSearchToolBm25_20251119 : ModelBase
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
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, BetaToolSearchToolBm25_20251119Type> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BetaToolSearchToolBm25_20251119Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<ApiEnum<string, AllowedCaller8>>? AllowedCallers
    {
        get
        {
            if (!this._rawData.TryGetValue("allowed_callers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, AllowedCaller8>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["allowed_callers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawData.TryGetValue("defer_loading", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["defer_loading"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? Strict
    {
        get
        {
            if (!this._rawData.TryGetValue("strict", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["strict"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_bm25\"")
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

    public BetaToolSearchToolBm25_20251119()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_bm25\"");
    }

    public BetaToolSearchToolBm25_20251119(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_bm25\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolBm25_20251119(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaToolSearchToolBm25_20251119 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolSearchToolBm25_20251119(
        ApiEnum<string, BetaToolSearchToolBm25_20251119Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaToolSearchToolBm25_20251119FromRaw : IFromRaw<BetaToolSearchToolBm25_20251119>
{
    public BetaToolSearchToolBm25_20251119 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolBm25_20251119.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolBm25_20251119TypeConverter))]
public enum BetaToolSearchToolBm25_20251119Type
{
    ToolSearchToolBm25_20251119,
    ToolSearchToolBm25,
}

sealed class BetaToolSearchToolBm25_20251119TypeConverter
    : JsonConverter<BetaToolSearchToolBm25_20251119Type>
{
    public override BetaToolSearchToolBm25_20251119Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tool_search_tool_bm25_20251119" =>
                BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            "tool_search_tool_bm25" => BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25,
            _ => (BetaToolSearchToolBm25_20251119Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolBm25_20251119Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119 =>
                    "tool_search_tool_bm25_20251119",
                BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25 => "tool_search_tool_bm25",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AllowedCaller8Converter))]
public enum AllowedCaller8
{
    Direct,
    CodeExecution20250825,
}

sealed class AllowedCaller8Converter : JsonConverter<AllowedCaller8>
{
    public override AllowedCaller8 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => AllowedCaller8.Direct,
            "code_execution_20250825" => AllowedCaller8.CodeExecution20250825,
            _ => (AllowedCaller8)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllowedCaller8 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllowedCaller8.Direct => "direct",
                AllowedCaller8.CodeExecution20250825 => "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
