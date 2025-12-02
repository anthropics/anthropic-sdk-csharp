using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ToolUnionConverter))]
public record class ToolUnion
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
                bash20250124: (x) => x.CacheControl,
                textEditor20250124: (x) => x.CacheControl,
                textEditor20250429: (x) => x.CacheControl,
                textEditor20250728: (x) => x.CacheControl,
                webSearchTool20250305: (x) => x.CacheControl
            );
        }
    }

    public ToolUnion(Tool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolUnion(ToolBash20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolUnion(ToolTextEditor20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolUnion(ToolTextEditor20250429 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolUnion(ToolTextEditor20250728 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolUnion(WebSearchTool20250305 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolUnion(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickTool([NotNullWhen(true)] out Tool? value)
    {
        value = this.Value as Tool;
        return value != null;
    }

    public bool TryPickBash20250124([NotNullWhen(true)] out ToolBash20250124? value)
    {
        value = this.Value as ToolBash20250124;
        return value != null;
    }

    public bool TryPickTextEditor20250124([NotNullWhen(true)] out ToolTextEditor20250124? value)
    {
        value = this.Value as ToolTextEditor20250124;
        return value != null;
    }

    public bool TryPickTextEditor20250429([NotNullWhen(true)] out ToolTextEditor20250429? value)
    {
        value = this.Value as ToolTextEditor20250429;
        return value != null;
    }

    public bool TryPickTextEditor20250728([NotNullWhen(true)] out ToolTextEditor20250728? value)
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
        System::Action<ToolBash20250124> bash20250124,
        System::Action<ToolTextEditor20250124> textEditor20250124,
        System::Action<ToolTextEditor20250429> textEditor20250429,
        System::Action<ToolTextEditor20250728> textEditor20250728,
        System::Action<WebSearchTool20250305> webSearchTool20250305
    )
    {
        switch (this.Value)
        {
            case Tool value:
                tool(value);
                break;
            case ToolBash20250124 value:
                bash20250124(value);
                break;
            case ToolTextEditor20250124 value:
                textEditor20250124(value);
                break;
            case ToolTextEditor20250429 value:
                textEditor20250429(value);
                break;
            case ToolTextEditor20250728 value:
                textEditor20250728(value);
                break;
            case WebSearchTool20250305 value:
                webSearchTool20250305(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolUnion"
                );
        }
    }

    public T Match<T>(
        System::Func<Tool, T> tool,
        System::Func<ToolBash20250124, T> bash20250124,
        System::Func<ToolTextEditor20250124, T> textEditor20250124,
        System::Func<ToolTextEditor20250429, T> textEditor20250429,
        System::Func<ToolTextEditor20250728, T> textEditor20250728,
        System::Func<WebSearchTool20250305, T> webSearchTool20250305
    )
    {
        return this.Value switch
        {
            Tool value => tool(value),
            ToolBash20250124 value => bash20250124(value),
            ToolTextEditor20250124 value => textEditor20250124(value),
            ToolTextEditor20250429 value => textEditor20250429(value),
            ToolTextEditor20250728 value => textEditor20250728(value),
            WebSearchTool20250305 value => webSearchTool20250305(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolUnion"
            ),
        };
    }

    public static implicit operator ToolUnion(Tool value) => new(value);

    public static implicit operator ToolUnion(ToolBash20250124 value) => new(value);

    public static implicit operator ToolUnion(ToolTextEditor20250124 value) => new(value);

    public static implicit operator ToolUnion(ToolTextEditor20250429 value) => new(value);

    public static implicit operator ToolUnion(ToolTextEditor20250728 value) => new(value);

    public static implicit operator ToolUnion(WebSearchTool20250305 value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of ToolUnion");
        }
    }

    public virtual bool Equals(ToolUnion? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ToolUnionConverter : JsonConverter<ToolUnion>
{
    public override ToolUnion? Read(
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
        ToolUnion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
