using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawMessageDeltaEvent>))]
public sealed record class RawMessageDeltaEvent : ModelBase, IFromRaw<RawMessageDeltaEvent>
{
    public required Delta Delta
    {
        get
        {
            if (!this._properties.TryGetValue("delta", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'delta' cannot be null",
                    new System::ArgumentOutOfRangeException("delta", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'delta' cannot be null",
                    new System::ArgumentNullException("delta")
                );
        }
        init
        {
            this._properties["delta"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Billing and rate-limit usage.
    ///
    /// Anthropic's API bills and rate-limits by token counts, as tokens represent
    /// the underlying cost to our systems.
    ///
    /// Under the hood, the API transforms requests into a format suitable for the
    /// model. The model's output then goes through a parsing stage before becoming
    /// an API response. As a result, the token counts in `usage` will not match
    /// one-to-one with the exact visible content of an API request or response.
    ///
    /// For example, `output_tokens` will be non-zero, even for an empty string response
    /// from Claude.
    ///
    /// Total input tokens in a request is the summation of `input_tokens`, `cache_creation_input_tokens`,
    /// and `cache_read_input_tokens`.
    /// </summary>
    public required MessageDeltaUsage Usage
    {
        get
        {
            if (!this._properties.TryGetValue("usage", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'usage' cannot be null",
                    new System::ArgumentOutOfRangeException("usage", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageDeltaUsage>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'usage' cannot be null",
                    new System::ArgumentNullException("usage")
                );
        }
        init
        {
            this._properties["usage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Delta.Validate();
        _ = this.Type;
        this.Usage.Validate();
    }

    public RawMessageDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

    public RawMessageDeltaEvent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageDeltaEvent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RawMessageDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Delta>))]
public sealed record class Delta : ModelBase, IFromRaw<Delta>
{
    public required ApiEnum<string, StopReason>? StopReason
    {
        get
        {
            if (!this._properties.TryGetValue("stop_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, StopReason>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["stop_reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? StopSequence
    {
        get
        {
            if (!this._properties.TryGetValue("stop_sequence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["stop_sequence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.StopReason?.Validate();
        _ = this.StopSequence;
    }

    public Delta() { }

    public Delta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Delta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
