using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(MessageCountTokensToolConverter))]
public record class MessageCountTokensTool
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                tool: (x) => x.CacheControl,
                toolBash20250124: (x) => x.CacheControl,
                toolTextEditor20250124: (x) => x.CacheControl,
                toolTextEditor20250429: (x) => x.CacheControl,
                toolTextEditor20250728: (x) => x.CacheControl,
                webSearchTool20250305: (x) => x.CacheControl
            );
        }
    }

    public MessageCountTokensTool(Tool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageCountTokensTool(ToolBash20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageCountTokensTool(ToolTextEditor20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageCountTokensTool(ToolTextEditor20250429 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageCountTokensTool(ToolTextEditor20250728 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageCountTokensTool(WebSearchTool20250305 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageCountTokensTool(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickTool([NotNullWhen(true)] out Tool? value)
    {
        value = this.Value as Tool;
        return value != null;
    }

    public bool TryPickToolBash20250124([NotNullWhen(true)] out ToolBash20250124? value)
    {
        value = this.Value as ToolBash20250124;
        return value != null;
    }

    public bool TryPickToolTextEditor20250124([NotNullWhen(true)] out ToolTextEditor20250124? value)
    {
        value = this.Value as ToolTextEditor20250124;
        return value != null;
    }

    public bool TryPickToolTextEditor20250429([NotNullWhen(true)] out ToolTextEditor20250429? value)
    {
        value = this.Value as ToolTextEditor20250429;
        return value != null;
    }

    public bool TryPickToolTextEditor20250728([NotNullWhen(true)] out ToolTextEditor20250728? value)
    {
        value = this.Value as ToolTextEditor20250728;
        return value != null;
    }

    public bool TryPickWebSearchTool20250305([NotNullWhen(true)] out WebSearchTool20250305? value)
    {
        value = this.Value as WebSearchTool20250305;
        return value != null;
    }

    public void Switch(
        System::Action<Tool> tool,
        System::Action<ToolBash20250124> toolBash20250124,
        System::Action<ToolTextEditor20250124> toolTextEditor20250124,
        System::Action<ToolTextEditor20250429> toolTextEditor20250429,
        System::Action<ToolTextEditor20250728> toolTextEditor20250728,
        System::Action<WebSearchTool20250305> webSearchTool20250305
    )
    {
        switch (this.Value)
        {
            case Tool value:
                tool(value);
                break;
            case ToolBash20250124 value:
                toolBash20250124(value);
                break;
            case ToolTextEditor20250124 value:
                toolTextEditor20250124(value);
                break;
            case ToolTextEditor20250429 value:
                toolTextEditor20250429(value);
                break;
            case ToolTextEditor20250728 value:
                toolTextEditor20250728(value);
                break;
            case WebSearchTool20250305 value:
                webSearchTool20250305(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of MessageCountTokensTool"
                );
        }
    }

    public T Match<T>(
        System::Func<Tool, T> tool,
        System::Func<ToolBash20250124, T> toolBash20250124,
        System::Func<ToolTextEditor20250124, T> toolTextEditor20250124,
        System::Func<ToolTextEditor20250429, T> toolTextEditor20250429,
        System::Func<ToolTextEditor20250728, T> toolTextEditor20250728,
        System::Func<WebSearchTool20250305, T> webSearchTool20250305
    )
    {
        return this.Value switch
        {
            Tool value => tool(value),
            ToolBash20250124 value => toolBash20250124(value),
            ToolTextEditor20250124 value => toolTextEditor20250124(value),
            ToolTextEditor20250429 value => toolTextEditor20250429(value),
            ToolTextEditor20250728 value => toolTextEditor20250728(value),
            WebSearchTool20250305 value => webSearchTool20250305(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageCountTokensTool"
            ),
        };
    }

    public static implicit operator MessageCountTokensTool(Tool value) => new(value);

    public static implicit operator MessageCountTokensTool(ToolBash20250124 value) => new(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250124 value) =>
        new(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250429 value) =>
        new(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250728 value) =>
        new(value);

    public static implicit operator MessageCountTokensTool(WebSearchTool20250305 value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageCountTokensTool"
            );
        }
    }

    public virtual bool Equals(MessageCountTokensTool? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class MessageCountTokensToolConverter : JsonConverter<MessageCountTokensTool>
{
    public override MessageCountTokensTool? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Tool>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolBash20250124>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250124>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250429>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchTool20250305>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCountTokensTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
