using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : ModelBase
{
    /// <summary>
    /// Breakdown of cached tokens by TTL
    /// </summary>
    public required CacheCreation? CacheCreation
    {
        get { return ModelBase.GetNullableClass<CacheCreation>(this.RawData, "cache_creation"); }
        init { ModelBase.Set(this._rawData, "cache_creation", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            return ModelBase.GetNullableStruct<long>(this.RawData, "cache_creation_input_tokens");
        }
        init { ModelBase.Set(this._rawData, "cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "cache_read_input_tokens"); }
        init { ModelBase.Set(this._rawData, "cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens which were used.
    /// </summary>
    public required long InputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "input_tokens"); }
        init { ModelBase.Set(this._rawData, "input_tokens", value); }
    }

    /// <summary>
    /// The number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "output_tokens"); }
        init { ModelBase.Set(this._rawData, "output_tokens", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required ServerToolUsage? ServerToolUse
    {
        get { return ModelBase.GetNullableClass<ServerToolUsage>(this.RawData, "server_tool_use"); }
        init { ModelBase.Set(this._rawData, "server_tool_use", value); }
    }

    /// <summary>
    /// If the request used the priority, standard, or batch tier.
    /// </summary>
    public required ApiEnum<string, UsageServiceTier>? ServiceTier
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, UsageServiceTier>>(
                this.RawData,
                "service_tier"
            );
        }
        init { ModelBase.Set(this._rawData, "service_tier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheCreation?.Validate();
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
        this.ServiceTier?.Validate();
    }

    public Usage() { }

    public Usage(Usage usage)
        : base(usage) { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRaw<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}

/// <summary>
/// If the request used the priority, standard, or batch tier.
/// </summary>
[JsonConverter(typeof(UsageServiceTierConverter))]
public enum UsageServiceTier
{
    Standard,
    Priority,
    Batch,
}

sealed class UsageServiceTierConverter : JsonConverter<UsageServiceTier>
{
    public override UsageServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => UsageServiceTier.Standard,
            "priority" => UsageServiceTier.Priority,
            "batch" => UsageServiceTier.Batch,
            _ => (UsageServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageServiceTier.Standard => "standard",
                UsageServiceTier.Priority => "priority",
                UsageServiceTier.Batch => "batch",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
