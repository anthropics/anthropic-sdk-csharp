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
    typeof(JsonModelConverter<BetaWebFetchTool20260318, BetaWebFetchTool20260318FromRaw>)
)]
public sealed record class BetaWebFetchTool20260318 : JsonModel
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

    public IReadOnlyList<ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// List of domains to allow fetching from
    /// </summary>
    public IReadOnlyList<string>? AllowedDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_domains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of domains to block fetching from
    /// </summary>
    public IReadOnlyList<string>? BlockedDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("blocked_domains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "blocked_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Citations configuration for fetched documents. Citations are disabled by default.
    /// </summary>
    public BetaCitationsConfigParam? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCitationsConfigParam>("citations");
        }
        init { this._rawData.Set("citations", value); }
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
    /// Maximum number of tokens used by including web page text content in the context.
    /// The limit is approximate and does not apply to binary content such as PDFs.
    /// </summary>
    public long? MaxContentTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_content_tokens");
        }
        init { this._rawData.Set("max_content_tokens", value); }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_uses");
        }
        init { this._rawData.Set("max_uses", value); }
    }

    /// <summary>
    /// How this tool's result blocks appear in the API response when the result was
    /// consumed by a completed code_execution call in the same turn. 'full' returns
    /// the complete content (default). 'excluded' drops the nested server_tool_use
    /// and result block pair entirely. Results from direct calls, or from code_execution
    /// calls that paused before completing, are always returned in full so they can
    /// be sent back on the next turn.
    /// </summary>
    public ApiEnum<string, ResponseInclusion>? ResponseInclusion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ResponseInclusion>>(
                "response_inclusion"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("response_inclusion", value);
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

    /// <summary>
    /// Whether to use cached content. Set to false to bypass the cache and fetch
    /// fresh content. Only set to false when the user explicitly requests fresh
    /// content or when fetching rapidly-changing sources.
    /// </summary>
    public bool? UseCache
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_cache");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("use_cache", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("web_fetch")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_fetch_20260318")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        _ = this.AllowedDomains;
        _ = this.BlockedDomains;
        this.CacheControl?.Validate();
        this.Citations?.Validate();
        _ = this.DeferLoading;
        _ = this.MaxContentTokens;
        _ = this.MaxUses;
        this.ResponseInclusion?.Validate();
        _ = this.Strict;
        _ = this.UseCache;
    }

    public BetaWebFetchTool20260318()
    {
        this.Name = JsonSerializer.SerializeToElement("web_fetch");
        this.Type = JsonSerializer.SerializeToElement("web_fetch_20260318");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchTool20260318(BetaWebFetchTool20260318 betaWebFetchTool20260318)
        : base(betaWebFetchTool20260318) { }
#pragma warning restore CS8618

    public BetaWebFetchTool20260318(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("web_fetch");
        this.Type = JsonSerializer.SerializeToElement("web_fetch_20260318");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchTool20260318(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchTool20260318FromRaw.FromRawUnchecked"/>
    public static BetaWebFetchTool20260318 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchTool20260318FromRaw : IFromRawJson<BetaWebFetchTool20260318>
{
    /// <inheritdoc/>
    public BetaWebFetchTool20260318 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchTool20260318.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies who can invoke a tool.
///
/// <para>Values:     direct: The model can call this tool directly.     code_execution_20250825:
/// The tool can be called from the code execution environment (v1).     code_execution_20260120:
/// The tool can be called from the code execution environment (v2 with persistence).
///     code_execution_20260521: The tool can be called from the code execution environment
/// (v2 with persistence).</para>
/// </summary>
[JsonConverter(typeof(BetaWebFetchTool20260318AllowedCallerConverter))]
public enum BetaWebFetchTool20260318AllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
    CodeExecution20260521,
}

sealed class BetaWebFetchTool20260318AllowedCallerConverter
    : JsonConverter<BetaWebFetchTool20260318AllowedCaller>
{
    public override BetaWebFetchTool20260318AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaWebFetchTool20260318AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaWebFetchTool20260318AllowedCaller.CodeExecution20250825,
            "code_execution_20260120" =>
                BetaWebFetchTool20260318AllowedCaller.CodeExecution20260120,
            "code_execution_20260521" =>
                BetaWebFetchTool20260318AllowedCaller.CodeExecution20260521,
            _ => (BetaWebFetchTool20260318AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchTool20260318AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebFetchTool20260318AllowedCaller.Direct => "direct",
                BetaWebFetchTool20260318AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                BetaWebFetchTool20260318AllowedCaller.CodeExecution20260120 =>
                    "code_execution_20260120",
                BetaWebFetchTool20260318AllowedCaller.CodeExecution20260521 =>
                    "code_execution_20260521",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How this tool's result blocks appear in the API response when the result was
/// consumed by a completed code_execution call in the same turn. 'full' returns
/// the complete content (default). 'excluded' drops the nested server_tool_use and
/// result block pair entirely. Results from direct calls, or from code_execution
/// calls that paused before completing, are always returned in full so they can
/// be sent back on the next turn.
/// </summary>
[JsonConverter(typeof(ResponseInclusionConverter))]
public enum ResponseInclusion
{
    Full,
    Excluded,
}

sealed class ResponseInclusionConverter : JsonConverter<ResponseInclusion>
{
    public override ResponseInclusion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => ResponseInclusion.Full,
            "excluded" => ResponseInclusion.Excluded,
            _ => (ResponseInclusion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseInclusion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResponseInclusion.Full => "full",
                ResponseInclusion.Excluded => "excluded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
