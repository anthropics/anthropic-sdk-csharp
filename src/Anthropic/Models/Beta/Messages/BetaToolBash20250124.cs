using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolBash20250124>))]
public sealed record class BetaToolBash20250124 : ModelBase, IFromRaw<BetaToolBash20250124>
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
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
                    new ArgumentOutOfRangeException("type", "Missing required argument")
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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.Deserialize<JsonElement>("\"bash\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaToolBash20250124()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
    }

    public BetaToolBash20250124(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolBash20250124(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaToolBash20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
