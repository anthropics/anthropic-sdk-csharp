using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaAdvisorTool20260301, BetaAdvisorTool20260301FromRaw>))]
public sealed record class BetaAdvisorTool20260301 : JsonModel
{
    /// <summary>
    /// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required ApiEnum<string, Model> Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawData.Set("model", value); }
    }

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
        ApiEnum<string, global::Anthropic.Models.Beta.Messages.AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<
                    ApiEnum<string, global::Anthropic.Models.Beta.Messages.AllowedCaller>
                >
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, global::Anthropic.Models.Beta.Messages.AllowedCaller>
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
    /// Caching for the advisor's own prompt. When set, each advisor call writes
    /// a cache entry at the given TTL so subsequent calls in the same conversation
    /// read the stable prefix. When omitted, the advisor prompt is not cached.
    /// </summary>
    public BetaCacheControlEphemeral? Caching
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("caching");
        }
        init { this._rawData.Set("caching", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model.Raw();
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("advisor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("advisor_20260301")
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
        this.Caching?.Validate();
        _ = this.DeferLoading;
        _ = this.MaxUses;
        _ = this.Strict;
    }

    public BetaAdvisorTool20260301()
    {
        this.Name = JsonSerializer.SerializeToElement("advisor");
        this.Type = JsonSerializer.SerializeToElement("advisor_20260301");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorTool20260301(BetaAdvisorTool20260301 betaAdvisorTool20260301)
        : base(betaAdvisorTool20260301) { }
#pragma warning restore CS8618

    public BetaAdvisorTool20260301(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("advisor");
        this.Type = JsonSerializer.SerializeToElement("advisor_20260301");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorTool20260301(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorTool20260301FromRaw.FromRawUnchecked"/>
    public static BetaAdvisorTool20260301 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAdvisorTool20260301(ApiEnum<string, Model> model)
        : this()
    {
        this.Model = model;
    }
}

class BetaAdvisorTool20260301FromRaw : IFromRawJson<BetaAdvisorTool20260301>
{
    /// <inheritdoc/>
    public BetaAdvisorTool20260301 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorTool20260301.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies who can invoke a tool.
///
/// <para>Values:     direct: The model can call this tool directly.     code_execution_20250825:
/// The tool can be called from the code execution environment (v1).     code_execution_20260120:
/// The tool can be called from the code execution environment (v2 with persistence).</para>
/// </summary>
[JsonConverter(typeof(global::Anthropic.Models.Beta.Messages.AllowedCallerConverter))]
public enum AllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
}

sealed class AllowedCallerConverter
    : JsonConverter<global::Anthropic.Models.Beta.Messages.AllowedCaller>
{
    public override global::Anthropic.Models.Beta.Messages.AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => global::Anthropic.Models.Beta.Messages.AllowedCaller.Direct,
            "code_execution_20250825" => global::Anthropic
                .Models
                .Beta
                .Messages
                .AllowedCaller
                .CodeExecution20250825,
            "code_execution_20260120" => global::Anthropic
                .Models
                .Beta
                .Messages
                .AllowedCaller
                .CodeExecution20260120,
            _ => (global::Anthropic.Models.Beta.Messages.AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Messages.AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Messages.AllowedCaller.Direct => "direct",
                global::Anthropic.Models.Beta.Messages.AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                global::Anthropic.Models.Beta.Messages.AllowedCaller.CodeExecution20260120 =>
                    "code_execution_20260120",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
