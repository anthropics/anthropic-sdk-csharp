using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaCitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public record class Citation
{
    public object Value { get; private init; }

    public string CitedText
    {
        get
        {
            return Match(
                betaCitationCharLocation: (x) => x.CitedText,
                betaCitationPageLocation: (x) => x.CitedText,
                betaCitationContentBlockLocation: (x) => x.CitedText,
                betaCitationsWebSearchResultLocation: (x) => x.CitedText,
                betaCitationSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                betaCitationCharLocation: (x) => x.DocumentIndex,
                betaCitationPageLocation: (x) => x.DocumentIndex,
                betaCitationContentBlockLocation: (x) => x.DocumentIndex,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                betaCitationCharLocation: (x) => x.DocumentTitle,
                betaCitationPageLocation: (x) => x.DocumentTitle,
                betaCitationContentBlockLocation: (x) => x.DocumentTitle,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (_) => null
            );
        }
    }

    public string? FileID
    {
        get
        {
            return Match<string?>(
                betaCitationCharLocation: (x) => x.FileID,
                betaCitationPageLocation: (x) => x.FileID,
                betaCitationContentBlockLocation: (x) => x.FileID,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaCitationCharLocation: (x) => x.Type,
                betaCitationPageLocation: (x) => x.Type,
                betaCitationContentBlockLocation: (x) => x.Type,
                betaCitationsWebSearchResultLocation: (x) => x.Type,
                betaCitationSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                betaCitationCharLocation: (_) => null,
                betaCitationPageLocation: (_) => null,
                betaCitationContentBlockLocation: (x) => x.EndBlockIndex,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                betaCitationCharLocation: (_) => null,
                betaCitationPageLocation: (_) => null,
                betaCitationContentBlockLocation: (x) => x.StartBlockIndex,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                betaCitationCharLocation: (_) => null,
                betaCitationPageLocation: (_) => null,
                betaCitationContentBlockLocation: (_) => null,
                betaCitationsWebSearchResultLocation: (x) => x.Title,
                betaCitationSearchResultLocation: (x) => x.Title
            );
        }
    }

    public Citation(BetaCitationCharLocation value)
    {
        Value = value;
    }

    public Citation(BetaCitationPageLocation value)
    {
        Value = value;
    }

    public Citation(BetaCitationContentBlockLocation value)
    {
        Value = value;
    }

    public Citation(BetaCitationsWebSearchResultLocation value)
    {
        Value = value;
    }

    public Citation(BetaCitationSearchResultLocation value)
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

    public bool TryPickBetaCitationCharLocation(
        [NotNullWhen(true)] out BetaCitationCharLocation? value
    )
    {
        value = this.Value as BetaCitationCharLocation;
        return value != null;
    }

    public bool TryPickBetaCitationPageLocation(
        [NotNullWhen(true)] out BetaCitationPageLocation? value
    )
    {
        value = this.Value as BetaCitationPageLocation;
        return value != null;
    }

    public bool TryPickBetaCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocation? value
    )
    {
        value = this.Value as BetaCitationContentBlockLocation;
        return value != null;
    }

    public bool TryPickBetaCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationsWebSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationsWebSearchResultLocation;
        return value != null;
    }

    public bool TryPickBetaCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationSearchResultLocation;
        return value != null;
    }

    public void Switch(
        Action<BetaCitationCharLocation> betaCitationCharLocation,
        Action<BetaCitationPageLocation> betaCitationPageLocation,
        Action<BetaCitationContentBlockLocation> betaCitationContentBlockLocation,
        Action<BetaCitationsWebSearchResultLocation> betaCitationsWebSearchResultLocation,
        Action<BetaCitationSearchResultLocation> betaCitationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case BetaCitationCharLocation value:
                betaCitationCharLocation(value);
                break;
            case BetaCitationPageLocation value:
                betaCitationPageLocation(value);
                break;
            case BetaCitationContentBlockLocation value:
                betaCitationContentBlockLocation(value);
                break;
            case BetaCitationsWebSearchResultLocation value:
                betaCitationsWebSearchResultLocation(value);
                break;
            case BetaCitationSearchResultLocation value:
                betaCitationSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Citation"
                );
        }
    }

    public T Match<T>(
        Func<BetaCitationCharLocation, T> betaCitationCharLocation,
        Func<BetaCitationPageLocation, T> betaCitationPageLocation,
        Func<BetaCitationContentBlockLocation, T> betaCitationContentBlockLocation,
        Func<BetaCitationsWebSearchResultLocation, T> betaCitationsWebSearchResultLocation,
        Func<BetaCitationSearchResultLocation, T> betaCitationSearchResultLocation
    )
    {
        return this.Value switch
        {
            BetaCitationCharLocation value => betaCitationCharLocation(value),
            BetaCitationPageLocation value => betaCitationPageLocation(value),
            BetaCitationContentBlockLocation value => betaCitationContentBlockLocation(value),
            BetaCitationsWebSearchResultLocation value => betaCitationsWebSearchResultLocation(
                value
            ),
            BetaCitationSearchResultLocation value => betaCitationSearchResultLocation(value),
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
        Type typeToConvert,
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationCharLocation'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "page_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationPageLocation'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationContentBlockLocation'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "web_search_result_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

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
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationsWebSearchResultLocation'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "search_result_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationSearchResultLocation'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
