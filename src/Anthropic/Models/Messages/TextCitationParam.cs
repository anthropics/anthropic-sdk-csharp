using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(TextCitationParamConverter))]
public record class TextCitationParam
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string CitedText
    {
        get
        {
            return Match(
                citationCharLocation: (x) => x.CitedText,
                citationPageLocation: (x) => x.CitedText,
                citationContentBlockLocation: (x) => x.CitedText,
                citationWebSearchResultLocation: (x) => x.CitedText,
                citationSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (x) => x.DocumentIndex,
                citationPageLocation: (x) => x.DocumentIndex,
                citationContentBlockLocation: (x) => x.DocumentIndex,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (x) => x.DocumentTitle,
                citationPageLocation: (x) => x.DocumentTitle,
                citationContentBlockLocation: (x) => x.DocumentTitle,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                citationCharLocation: (x) => x.Type,
                citationPageLocation: (x) => x.Type,
                citationContentBlockLocation: (x) => x.Type,
                citationWebSearchResultLocation: (x) => x.Type,
                citationSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (x) => x.EndBlockIndex,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (x) => x.StartBlockIndex,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (_) => null,
                citationWebSearchResultLocation: (x) => x.Title,
                citationSearchResultLocation: (x) => x.Title
            );
        }
    }

    public TextCitationParam(CitationCharLocationParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TextCitationParam(CitationPageLocationParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TextCitationParam(CitationContentBlockLocationParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TextCitationParam(CitationWebSearchResultLocationParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TextCitationParam(CitationSearchResultLocationParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TextCitationParam(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickCitationCharLocation(
        [NotNullWhen(true)] out CitationCharLocationParam? value
    )
    {
        value = this.Value as CitationCharLocationParam;
        return value != null;
    }

    public bool TryPickCitationPageLocation(
        [NotNullWhen(true)] out CitationPageLocationParam? value
    )
    {
        value = this.Value as CitationPageLocationParam;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out CitationContentBlockLocationParam? value
    )
    {
        value = this.Value as CitationContentBlockLocationParam;
        return value != null;
    }

    public bool TryPickCitationWebSearchResultLocation(
        [NotNullWhen(true)] out CitationWebSearchResultLocationParam? value
    )
    {
        value = this.Value as CitationWebSearchResultLocationParam;
        return value != null;
    }

    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out CitationSearchResultLocationParam? value
    )
    {
        value = this.Value as CitationSearchResultLocationParam;
        return value != null;
    }

    public void Switch(
        System::Action<CitationCharLocationParam> citationCharLocation,
        System::Action<CitationPageLocationParam> citationPageLocation,
        System::Action<CitationContentBlockLocationParam> citationContentBlockLocation,
        System::Action<CitationWebSearchResultLocationParam> citationWebSearchResultLocation,
        System::Action<CitationSearchResultLocationParam> citationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case CitationCharLocationParam value:
                citationCharLocation(value);
                break;
            case CitationPageLocationParam value:
                citationPageLocation(value);
                break;
            case CitationContentBlockLocationParam value:
                citationContentBlockLocation(value);
                break;
            case CitationWebSearchResultLocationParam value:
                citationWebSearchResultLocation(value);
                break;
            case CitationSearchResultLocationParam value:
                citationSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of TextCitationParam"
                );
        }
    }

    public T Match<T>(
        System::Func<CitationCharLocationParam, T> citationCharLocation,
        System::Func<CitationPageLocationParam, T> citationPageLocation,
        System::Func<CitationContentBlockLocationParam, T> citationContentBlockLocation,
        System::Func<CitationWebSearchResultLocationParam, T> citationWebSearchResultLocation,
        System::Func<CitationSearchResultLocationParam, T> citationSearchResultLocation
    )
    {
        return this.Value switch
        {
            CitationCharLocationParam value => citationCharLocation(value),
            CitationPageLocationParam value => citationPageLocation(value),
            CitationContentBlockLocationParam value => citationContentBlockLocation(value),
            CitationWebSearchResultLocationParam value => citationWebSearchResultLocation(value),
            CitationSearchResultLocationParam value => citationSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextCitationParam"
            ),
        };
    }

    public static implicit operator TextCitationParam(CitationCharLocationParam value) =>
        new(value);

    public static implicit operator TextCitationParam(CitationPageLocationParam value) =>
        new(value);

    public static implicit operator TextCitationParam(CitationContentBlockLocationParam value) =>
        new(value);

    public static implicit operator TextCitationParam(CitationWebSearchResultLocationParam value) =>
        new(value);

    public static implicit operator TextCitationParam(CitationSearchResultLocationParam value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextCitationParam"
            );
        }
    }

    public virtual bool Equals(TextCitationParam? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class TextCitationParamConverter : JsonConverter<TextCitationParam>
{
    public override TextCitationParam? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "char_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "page_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "content_block_location":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CitationContentBlockLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "web_search_result_location":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CitationWebSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "search_result_location":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CitationSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new TextCitationParam(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextCitationParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
