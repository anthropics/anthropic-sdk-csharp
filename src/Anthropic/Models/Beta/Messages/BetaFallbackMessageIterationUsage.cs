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
/// Token usage for the fallback-model attempt of a server-side fallback request.
///
/// <para>Produced in place of a `message` entry for whichever hop served the response.
/// A declined hop produces the existing `message` entry. Whether a fallback model
/// served the response is signalled by the presence of this entry in `usage.iterations`.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaFallbackMessageIterationUsage,
        BetaFallbackMessageIterationUsageFromRaw
    >)
)]
public sealed record class BetaFallbackMessageIterationUsage : JsonModel
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
    /// The model that will complete your prompt.
    ///
    /// <para>See [models](https://docs.anthropic.com/en/docs/models-overview) for
    /// additional details and options.</para>
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
    /// Usage for the fallback-model attempt that served the response
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
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("fallback_message")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaFallbackMessageIterationUsage()
    {
        this.Type = JsonSerializer.SerializeToElement("fallback_message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackMessageIterationUsage(
        BetaFallbackMessageIterationUsage betaFallbackMessageIterationUsage
    )
        : base(betaFallbackMessageIterationUsage) { }
#pragma warning restore CS8618

    public BetaFallbackMessageIterationUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("fallback_message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackMessageIterationUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackMessageIterationUsageFromRaw.FromRawUnchecked"/>
    public static BetaFallbackMessageIterationUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFallbackMessageIterationUsageFromRaw : IFromRawJson<BetaFallbackMessageIterationUsage>
{
    /// <inheritdoc/>
    public BetaFallbackMessageIterationUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackMessageIterationUsage.FromRawUnchecked(rawData);
}
