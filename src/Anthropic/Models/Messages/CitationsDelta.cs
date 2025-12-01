using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationsDelta, CitationsDeltaFromRaw>))]
public sealed record class CitationsDelta : ModelBase
{
    public required Citation Citation
    {
        get
        {
            if (!this._rawData.TryGetValue("citation", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'citation' cannot be null",
                    new System::ArgumentOutOfRangeException("citation", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Citation>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'citation' cannot be null",
                    new System::ArgumentNullException("citation")
                );
        }
        init
        {
            this._rawData["citation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Citation.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

    public CitationsDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CitationsDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}

class CitationsDeltaFromRaw : IFromRaw<CitationsDelta>
{
    public CitationsDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CitationsDelta.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CitationConverter))]
public record class Citation
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
                charLocation: (x) => x.CitedText,
                pageLocation: (x) => x.CitedText,
                contentBlockLocation: (x) => x.CitedText,
                citationsWebSearchResultLocation: (x) => x.CitedText,
                citationsSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                charLocation: (x) => x.DocumentIndex,
                pageLocation: (x) => x.DocumentIndex,
                contentBlockLocation: (x) => x.DocumentIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                charLocation: (x) => x.DocumentTitle,
                pageLocation: (x) => x.DocumentTitle,
                contentBlockLocation: (x) => x.DocumentTitle,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public string? FileID
    {
        get
        {
            return Match<string?>(
                charLocation: (x) => x.FileID,
                pageLocation: (x) => x.FileID,
                contentBlockLocation: (x) => x.FileID,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                charLocation: (x) => x.Type,
                pageLocation: (x) => x.Type,
                contentBlockLocation: (x) => x.Type,
                citationsWebSearchResultLocation: (x) => x.Type,
                citationsSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (x) => x.EndBlockIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (x) => x.StartBlockIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (_) => null,
                citationsWebSearchResultLocation: (x) => x.Title,
                citationsSearchResultLocation: (x) => x.Title
            );
        }
    }

    public Citation(CitationCharLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(CitationPageLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(CitationContentBlockLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(CitationsWebSearchResultLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(CitationsSearchResultLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickCharLocation([NotNullWhen(true)] out CitationCharLocation? value)
    {
        value = this.Value as CitationCharLocation;
        return value != null;
    }

    public bool TryPickPageLocation([NotNullWhen(true)] out CitationPageLocation? value)
    {
        value = this.Value as CitationPageLocation;
        return value != null;
    }

    public bool TryPickContentBlockLocation(
        [NotNullWhen(true)] out CitationContentBlockLocation? value
    )
    {
        value = this.Value as CitationContentBlockLocation;
        return value != null;
    }

    public bool TryPickCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out CitationsWebSearchResultLocation? value
    )
    {
        value = this.Value as CitationsWebSearchResultLocation;
        return value != null;
    }

    public bool TryPickCitationsSearchResultLocation(
        [NotNullWhen(true)] out CitationsSearchResultLocation? value
    )
    {
        value = this.Value as CitationsSearchResultLocation;
        return value != null;
    }

    public void Switch(
        System::Action<CitationCharLocation> charLocation,
        System::Action<CitationPageLocation> pageLocation,
        System::Action<CitationContentBlockLocation> contentBlockLocation,
        System::Action<CitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        System::Action<CitationsSearchResultLocation> citationsSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case CitationCharLocation value:
                charLocation(value);
                break;
            case CitationPageLocation value:
                pageLocation(value);
                break;
            case CitationContentBlockLocation value:
                contentBlockLocation(value);
                break;
            case CitationsWebSearchResultLocation value:
                citationsWebSearchResultLocation(value);
                break;
            case CitationsSearchResultLocation value:
                citationsSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Citation"
                );
        }
    }

    public T Match<T>(
        System::Func<CitationCharLocation, T> charLocation,
        System::Func<CitationPageLocation, T> pageLocation,
        System::Func<CitationContentBlockLocation, T> contentBlockLocation,
        System::Func<CitationsWebSearchResultLocation, T> citationsWebSearchResultLocation,
        System::Func<CitationsSearchResultLocation, T> citationsSearchResultLocation
    )
    {
        return this.Value switch
        {
            CitationCharLocation value => charLocation(value),
            CitationPageLocation value => pageLocation(value),
            CitationContentBlockLocation value => contentBlockLocation(value),
            CitationsWebSearchResultLocation value => citationsWebSearchResultLocation(value),
            CitationsSearchResultLocation value => citationsSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Citation"
            ),
        };
    }

    public static implicit operator Citation(CitationCharLocation value) => new(value);

    public static implicit operator Citation(CitationPageLocation value) => new(value);

    public static implicit operator Citation(CitationContentBlockLocation value) => new(value);

    public static implicit operator Citation(CitationsWebSearchResultLocation value) => new(value);

    public static implicit operator Citation(CitationsSearchResultLocation value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Citation");
        }
    }

    public virtual bool Equals(Citation? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class CitationConverter : JsonConverter<Citation>
{
    public override Citation? Read(
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
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<CitationsSearchResultLocation>(
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
                return new Citation(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
