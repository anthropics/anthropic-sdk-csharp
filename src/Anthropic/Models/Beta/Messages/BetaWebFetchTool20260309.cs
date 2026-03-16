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
/// Web fetch tool with use_cache parameter for bypassing cached content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaWebFetchTool20260309, BetaWebFetchTool20260309FromRaw>)
)]
public sealed record class BetaWebFetchTool20260309 : JsonModel
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

    public IReadOnlyList<ApiEnum<string, BetaWebFetchTool20260309AllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaWebFetchTool20260309AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, BetaWebFetchTool20260309AllowedCaller>
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
                JsonSerializer.SerializeToElement("web_fetch_20260309")
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
        _ = this.Strict;
        _ = this.UseCache;
    }

    public BetaWebFetchTool20260309()
    {
        this.Name = JsonSerializer.SerializeToElement("web_fetch");
        this.Type = JsonSerializer.SerializeToElement("web_fetch_20260309");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchTool20260309(BetaWebFetchTool20260309 betaWebFetchTool20260309)
        : base(betaWebFetchTool20260309) { }
#pragma warning restore CS8618

    public BetaWebFetchTool20260309(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("web_fetch");
        this.Type = JsonSerializer.SerializeToElement("web_fetch_20260309");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchTool20260309(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchTool20260309FromRaw.FromRawUnchecked"/>
    public static BetaWebFetchTool20260309 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchTool20260309FromRaw : IFromRawJson<BetaWebFetchTool20260309>
{
    /// <inheritdoc/>
    public BetaWebFetchTool20260309 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchTool20260309.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies who can invoke a tool.
///
/// <para>Values:     direct: The model can call this tool directly.     code_execution_20250825:
/// The tool can be called from the code execution environment (v1).     code_execution_20260120:
/// The tool can be called from the code execution environment (v2 with persistence).</para>
/// </summary>
[JsonConverter(typeof(BetaWebFetchTool20260309AllowedCallerConverter))]
public enum BetaWebFetchTool20260309AllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
}

sealed class BetaWebFetchTool20260309AllowedCallerConverter
    : JsonConverter<BetaWebFetchTool20260309AllowedCaller>
{
    public override BetaWebFetchTool20260309AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaWebFetchTool20260309AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaWebFetchTool20260309AllowedCaller.CodeExecution20250825,
            "code_execution_20260120" =>
                BetaWebFetchTool20260309AllowedCaller.CodeExecution20260120,
            _ => (BetaWebFetchTool20260309AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchTool20260309AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebFetchTool20260309AllowedCaller.Direct => "direct",
                BetaWebFetchTool20260309AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                BetaWebFetchTool20260309AllowedCaller.CodeExecution20260120 =>
                    "code_execution_20260120",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
