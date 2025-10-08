using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolTextEditor20250124>))]
public sealed record class BetaToolTextEditor20250124
    : ModelBase,
        IFromRaw<BetaToolTextEditor20250124>
{
    /// <summary>
    /// Name of the tool.
    ///
    /// This is how the tool will be called by the model and in `tool_use` blocks.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.CacheControl?.Validate();
    }

    public BetaToolTextEditor20250124()
    {
        this.Name = new();
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolTextEditor20250124(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolTextEditor20250124 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
