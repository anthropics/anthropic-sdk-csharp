using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Token usage for an advisor sub-inference iteration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAdvisorMessageIterationUsage,
        BetaAdvisorMessageIterationUsageFromRaw
    >)
)]
public sealed record class BetaAdvisorMessageIterationUsage : JsonModel
{
    /// <summary>
    /// Breakdown of cached tokens by TTL
    /// </summary>
    public required BetaCacheCreation? CacheCreation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheCreation>("cache_creation");
        }
        init { this._rawData.Set("cache_creation", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the cache entry.
    /// </summary>
    public required long CacheCreationInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cache_creation_input_tokens");
        }
        init { this._rawData.Set("cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens which were used.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

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
    /// The number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// Usage for an advisor sub-inference iteration
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheCreation?.Validate();
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        this.Model.Raw();
        _ = this.OutputTokens;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("advisor_message"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorMessageIterationUsage()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorMessageIterationUsage(
        BetaAdvisorMessageIterationUsage betaAdvisorMessageIterationUsage
    )
        : base(betaAdvisorMessageIterationUsage) { }
#pragma warning restore CS8618

    public BetaAdvisorMessageIterationUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorMessageIterationUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorMessageIterationUsageFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorMessageIterationUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAdvisorMessageIterationUsageFromRaw : IFromRawJson<BetaAdvisorMessageIterationUsage>
{
    /// <inheritdoc/>
    public BetaAdvisorMessageIterationUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorMessageIterationUsage.FromRawUnchecked(rawData);
}
