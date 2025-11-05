using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaServerToolUseBlockParam>))]
public sealed record class BetaServerToolUseBlockParam
    : ModelBase,
        IFromRaw<BetaServerToolUseBlockParam>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
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
                    new System::ArgumentOutOfRangeException("input", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new System::ArgumentNullException("input")
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

    public required ApiEnum<string, NameModel> Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, NameModel>>(
                element,
                ModelBase.SerializerOptions
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
        this.Name.Validate();
        _ = this.Type;
        this.CacheControl?.Validate();
    }

    public BetaServerToolUseBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

    public BetaServerToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUseBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(NameModelConverter))]
public enum NameModel
{
    WebSearch,
    WebFetch,
    CodeExecution,
    BashCodeExecution,
    TextEditorCodeExecution,
}

sealed class NameModelConverter : JsonConverter<NameModel>
{
    public override NameModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "web_search" => NameModel.WebSearch,
            "web_fetch" => NameModel.WebFetch,
            "code_execution" => NameModel.CodeExecution,
            "bash_code_execution" => NameModel.BashCodeExecution,
            "text_editor_code_execution" => NameModel.TextEditorCodeExecution,
            _ => (NameModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NameModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NameModel.WebSearch => "web_search",
                NameModel.WebFetch => "web_fetch",
                NameModel.CodeExecution => "code_execution",
                NameModel.BashCodeExecution => "bash_code_execution",
                NameModel.TextEditorCodeExecution => "text_editor_code_execution",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
