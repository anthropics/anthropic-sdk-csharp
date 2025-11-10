using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMCPToolUseBlockParam>))]
public sealed record class BetaMCPToolUseBlockParam : ModelBase, IFromRaw<BetaMCPToolUseBlockParam>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Dictionary<string, JsonElement> Input
    {
        get
        {
            if (!this._properties.TryGetValue("input", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new ArgumentOutOfRangeException("input", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new ArgumentNullException("input")
                );
        }
        init
        {
            this._properties["input"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the MCP server
    /// </summary>
    public required string ServerName
    {
        get
        {
            if (!this._properties.TryGetValue("server_name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'server_name' cannot be null",
                    new ArgumentOutOfRangeException("server_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'server_name' cannot be null",
                    new ArgumentNullException("server_name")
                );
        }
        init
        {
            this._properties["server_name"] = JsonSerializer.SerializeToElement(
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
        _ = this.ID;
        _ = this.Input;
        _ = this.Name;
        _ = this.ServerName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaMCPToolUseBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

    public BetaMCPToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolUseBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMCPToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
