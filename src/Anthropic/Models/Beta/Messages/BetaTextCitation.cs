using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationConverter))]
public record class BetaTextCitation
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
                citationsWebSearchResultLocation: (x) => x.CitedText,
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
                citationsWebSearchResultLocation: (_) => null,
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
                citationsWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (_) => null
            );
        }
    }

    public string? FileID
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (x) => x.FileID,
                citationPageLocation: (x) => x.FileID,
                citationContentBlockLocation: (x) => x.FileID,
                citationsWebSearchResultLocation: (_) => null,
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
                citationsWebSearchResultLocation: (x) => x.Type,
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
                citationsWebSearchResultLocation: (_) => null,
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
                citationsWebSearchResultLocation: (_) => null,
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
                citationsWebSearchResultLocation: (x) => x.Title,
                citationSearchResultLocation: (x) => x.Title
            );
        }
    }

    public BetaTextCitation(BetaCitationCharLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextCitation(BetaCitationPageLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextCitation(BetaCitationContentBlockLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextCitation(BetaCitationsWebSearchResultLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextCitation(BetaCitationSearchResultLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextCitation(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickCitationCharLocation([NotNullWhen(true)] out BetaCitationCharLocation? value)
    {
        value = this.Value as BetaCitationCharLocation;
        return value != null;
    }

    public bool TryPickCitationPageLocation([NotNullWhen(true)] out BetaCitationPageLocation? value)
    {
        value = this.Value as BetaCitationPageLocation;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocation? value
    )
    {
        value = this.Value as BetaCitationContentBlockLocation;
        return value != null;
    }

    public bool TryPickCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationsWebSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationsWebSearchResultLocation;
        return value != null;
    }

    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationSearchResultLocation;
        return value != null;
    }

    public void Switch(
        System::Action<BetaCitationCharLocation> citationCharLocation,
        System::Action<BetaCitationPageLocation> citationPageLocation,
        System::Action<BetaCitationContentBlockLocation> citationContentBlockLocation,
        System::Action<BetaCitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        System::Action<BetaCitationSearchResultLocation> citationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case BetaCitationCharLocation value:
                citationCharLocation(value);
                break;
            case BetaCitationPageLocation value:
                citationPageLocation(value);
                break;
            case BetaCitationContentBlockLocation value:
                citationContentBlockLocation(value);
                break;
            case BetaCitationsWebSearchResultLocation value:
                citationsWebSearchResultLocation(value);
                break;
            case BetaCitationSearchResultLocation value:
                citationSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTextCitation"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaCitationCharLocation, T> citationCharLocation,
        System::Func<BetaCitationPageLocation, T> citationPageLocation,
        System::Func<BetaCitationContentBlockLocation, T> citationContentBlockLocation,
        System::Func<BetaCitationsWebSearchResultLocation, T> citationsWebSearchResultLocation,
        System::Func<BetaCitationSearchResultLocation, T> citationSearchResultLocation
    )
    {
        return this.Value switch
        {
            BetaCitationCharLocation value => citationCharLocation(value),
            BetaCitationPageLocation value => citationPageLocation(value),
            BetaCitationContentBlockLocation value => citationContentBlockLocation(value),
            BetaCitationsWebSearchResultLocation value => citationsWebSearchResultLocation(value),
            BetaCitationSearchResultLocation value => citationSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextCitation"
            ),
        };
    }

    public static implicit operator BetaTextCitation(BetaCitationCharLocation value) => new(value);

    public static implicit operator BetaTextCitation(BetaCitationPageLocation value) => new(value);

    public static implicit operator BetaTextCitation(BetaCitationContentBlockLocation value) =>
        new(value);

    public static implicit operator BetaTextCitation(BetaCitationsWebSearchResultLocation value) =>
        new(value);

    public static implicit operator BetaTextCitation(BetaCitationSearchResultLocation value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextCitation"
            );
        }
    }
}

sealed class BetaTextCitationConverter : JsonConverter<BetaTextCitation>
{
    public override BetaTextCitation? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
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
                        JsonSerializer.Deserialize<BetaCitationsWebSearchResultLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(
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
                return new BetaTextCitation(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextCitation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
