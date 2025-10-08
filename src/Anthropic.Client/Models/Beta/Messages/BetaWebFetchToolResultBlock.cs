using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockProperties;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebFetchToolResultBlock>))]
public sealed record class BetaWebFetchToolResultBlock
    : ModelBase,
        IFromRaw<BetaWebFetchToolResultBlock>
{
    public required Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentNullException("content")
                );
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ToolUseID
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_use_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new ArgumentOutOfRangeException("tool_use_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new ArgumentNullException("tool_use_id")
                );
        }
        set
        {
            this.Properties["tool_use_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
    }

    public BetaWebFetchToolResultBlock()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebFetchToolResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
