using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebFetchTool20250910, BetaWebFetchTool20250910FromRaw>))]
public sealed record class BetaWebFetchTool20250910 : ModelBase
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

    public IReadOnlyList<ApiEnum<string, BetaWebFetchTool20250910AllowedCaller>>? AllowedCallers
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, BetaWebFetchTool20250910AllowedCaller>>
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
    /// List of domains to allow fetching from
    /// </summary>
    public IReadOnlyList<string>? AllowedDomains
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "allowed_domains"); }
        init { ModelBase.Set(this._rawData, "allowed_domains", value); }
    }

    /// <summary>
    /// List of domains to block fetching from
    /// </summary>
    public IReadOnlyList<string>? BlockedDomains
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "blocked_domains"); }
        init { ModelBase.Set(this._rawData, "blocked_domains", value); }
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
    /// Citations configuration for fetched documents. Citations are disabled by default.
    /// </summary>
    public BetaCitationsConfigParam? Citations
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCitationsConfigParam>(this.RawData, "citations");
        }
        init { ModelBase.Set(this._rawData, "citations", value); }
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
    /// Maximum number of tokens used by including web page text content in the context.
    /// The limit is approximate and does not apply to binary content such as PDFs.
    /// </summary>
    public long? MaxContentTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "max_content_tokens"); }
        init { ModelBase.Set(this._rawData, "max_content_tokens", value); }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "max_uses"); }
        init { ModelBase.Set(this._rawData, "max_uses", value); }
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
                JsonSerializer.Deserialize<JsonElement>("\"web_fetch\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_fetch_20250910\"")
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
    }

    public BetaWebFetchTool20250910()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_fetch\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_20250910\"");
    }

    public BetaWebFetchTool20250910(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_fetch\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_20250910\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchTool20250910(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchTool20250910FromRaw.FromRawUnchecked"/>
    public static BetaWebFetchTool20250910 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchTool20250910FromRaw : IFromRaw<BetaWebFetchTool20250910>
{
    /// <inheritdoc/>
    public BetaWebFetchTool20250910 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchTool20250910.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaWebFetchTool20250910AllowedCallerConverter))]
public enum BetaWebFetchTool20250910AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaWebFetchTool20250910AllowedCallerConverter
    : JsonConverter<BetaWebFetchTool20250910AllowedCaller>
{
    public override BetaWebFetchTool20250910AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaWebFetchTool20250910AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaWebFetchTool20250910AllowedCaller.CodeExecution20250825,
            _ => (BetaWebFetchTool20250910AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchTool20250910AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebFetchTool20250910AllowedCaller.Direct => "direct",
                BetaWebFetchTool20250910AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
