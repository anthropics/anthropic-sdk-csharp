using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

[JsonConverter(typeof(ModelConverter<BetaMessageBatchRequestCounts>))]
public sealed record class BetaMessageBatchRequestCounts
    : ModelBase,
        IFromRaw<BetaMessageBatchRequestCounts>
{
    /// <summary>
    /// Number of requests in the Message Batch that have been canceled.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Canceled
    {
        get
        {
            if (!this._properties.TryGetValue("canceled", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'canceled' cannot be null",
                    new ArgumentOutOfRangeException("canceled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["canceled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that encountered an error.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Errored
    {
        get
        {
            if (!this._properties.TryGetValue("errored", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'errored' cannot be null",
                    new ArgumentOutOfRangeException("errored", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["errored"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have expired.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Expired
    {
        get
        {
            if (!this._properties.TryGetValue("expired", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'expired' cannot be null",
                    new ArgumentOutOfRangeException("expired", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["expired"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that are processing.
    /// </summary>
    public required long Processing
    {
        get
        {
            if (!this._properties.TryGetValue("processing", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'processing' cannot be null",
                    new ArgumentOutOfRangeException("processing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["processing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have completed successfully.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Succeeded
    {
        get
        {
            if (!this._properties.TryGetValue("succeeded", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'succeeded' cannot be null",
                    new ArgumentOutOfRangeException("succeeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["succeeded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Canceled;
        _ = this.Errored;
        _ = this.Expired;
        _ = this.Processing;
        _ = this.Succeeded;
    }

    public BetaMessageBatchRequestCounts() { }

    public BetaMessageBatchRequestCounts(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchRequestCounts(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
