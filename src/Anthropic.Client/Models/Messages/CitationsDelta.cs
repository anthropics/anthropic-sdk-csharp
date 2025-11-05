using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationsDelta>))]
public sealed record class CitationsDelta : ModelBase, IFromRaw<CitationsDelta>
{
    public required Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out JsonElement element))
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
        set
        {
            this.Properties["citation"] = JsonSerializer.SerializeToElement(
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
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
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
        this.Citation.Validate();
        _ = this.Type;
    }

    public CitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationsDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public CitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}

[JsonConverter(typeof(CitationConverter))]
public record class Citation
{
    public object Value { get; private init; }

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

    public Citation(CitationCharLocation value)
    {
        Value = value;
    }

    public Citation(CitationPageLocation value)
    {
        Value = value;
    }

    public Citation(CitationContentBlockLocation value)
    {
        Value = value;
    }

    public Citation(CitationsWebSearchResultLocation value)
    {
        Value = value;
    }

    public Citation(CitationsSearchResultLocation value)
    {
        Value = value;
    }

    Citation(UnknownVariant value)
    {
        Value = value;
    }

    public static Citation CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Citation");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationCharLocation'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "page_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationPageLocation'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "content_block_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationContentBlockLocation'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "web_search_result_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationsWebSearchResultLocation'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "search_result_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationsSearchResultLocation'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
