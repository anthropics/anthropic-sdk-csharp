using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using CitationVariants = Anthropic.Client.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaCitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(BetaCitationCharLocation value) =>
        new CitationVariants::BetaCitationCharLocation(value);

    public static implicit operator Citation(BetaCitationPageLocation value) =>
        new CitationVariants::BetaCitationPageLocation(value);

    public static implicit operator Citation(BetaCitationContentBlockLocation value) =>
        new CitationVariants::BetaCitationContentBlockLocation(value);

    public static implicit operator Citation(BetaCitationsWebSearchResultLocation value) =>
        new CitationVariants::BetaCitationsWebSearchResultLocation(value);

    public static implicit operator Citation(BetaCitationSearchResultLocation value) =>
        new CitationVariants::BetaCitationSearchResultLocation(value);

    public bool TryPickBetaCitationCharLocation(
        [NotNullWhen(true)] out BetaCitationCharLocation? value
    )
    {
        value = (this as CitationVariants::BetaCitationCharLocation)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationPageLocation(
        [NotNullWhen(true)] out BetaCitationPageLocation? value
    )
    {
        value = (this as CitationVariants::BetaCitationPageLocation)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocation? value
    )
    {
        value = (this as CitationVariants::BetaCitationContentBlockLocation)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationsWebSearchResultLocation? value
    )
    {
        value = (this as CitationVariants::BetaCitationsWebSearchResultLocation)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = (this as CitationVariants::BetaCitationSearchResultLocation)?.Value;
        return value != null;
    }

    public void Switch(
        Action<CitationVariants::BetaCitationCharLocation> betaCitationCharLocation,
        Action<CitationVariants::BetaCitationPageLocation> betaCitationPageLocation,
        Action<CitationVariants::BetaCitationContentBlockLocation> betaCitationContentBlockLocation,
        Action<CitationVariants::BetaCitationsWebSearchResultLocation> betaCitationsWebSearchResultLocation,
        Action<CitationVariants::BetaCitationSearchResultLocation> betaCitationSearchResultLocation
    )
    {
        switch (this)
        {
            case CitationVariants::BetaCitationCharLocation inner:
                betaCitationCharLocation(inner);
                break;
            case CitationVariants::BetaCitationPageLocation inner:
                betaCitationPageLocation(inner);
                break;
            case CitationVariants::BetaCitationContentBlockLocation inner:
                betaCitationContentBlockLocation(inner);
                break;
            case CitationVariants::BetaCitationsWebSearchResultLocation inner:
                betaCitationsWebSearchResultLocation(inner);
                break;
            case CitationVariants::BetaCitationSearchResultLocation inner:
                betaCitationSearchResultLocation(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Citation"
                );
        }
    }

    public T Match<T>(
        Func<CitationVariants::BetaCitationCharLocation, T> betaCitationCharLocation,
        Func<CitationVariants::BetaCitationPageLocation, T> betaCitationPageLocation,
        Func<
            CitationVariants::BetaCitationContentBlockLocation,
            T
        > betaCitationContentBlockLocation,
        Func<
            CitationVariants::BetaCitationsWebSearchResultLocation,
            T
        > betaCitationsWebSearchResultLocation,
        Func<CitationVariants::BetaCitationSearchResultLocation, T> betaCitationSearchResultLocation
    )
    {
        return this switch
        {
            CitationVariants::BetaCitationCharLocation inner => betaCitationCharLocation(inner),
            CitationVariants::BetaCitationPageLocation inner => betaCitationPageLocation(inner),
            CitationVariants::BetaCitationContentBlockLocation inner =>
                betaCitationContentBlockLocation(inner),
            CitationVariants::BetaCitationsWebSearchResultLocation inner =>
                betaCitationsWebSearchResultLocation(inner),
            CitationVariants::BetaCitationSearchResultLocation inner =>
                betaCitationSearchResultLocation(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Citation"
            ),
        };
    }

    public abstract void Validate();
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
                        return new CitationVariants::BetaCitationCharLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant CitationVariants::BetaCitationCharLocation",
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
                        return new CitationVariants::BetaCitationPageLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant CitationVariants::BetaCitationPageLocation",
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
                        return new CitationVariants::BetaCitationContentBlockLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant CitationVariants::BetaCitationContentBlockLocation",
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
                        return new CitationVariants::BetaCitationsWebSearchResultLocation(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant CitationVariants::BetaCitationsWebSearchResultLocation",
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
                        return new CitationVariants::BetaCitationSearchResultLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant CitationVariants::BetaCitationSearchResultLocation",
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
        object variant = value switch
        {
            CitationVariants::BetaCitationCharLocation(var betaCitationCharLocation) =>
                betaCitationCharLocation,
            CitationVariants::BetaCitationPageLocation(var betaCitationPageLocation) =>
                betaCitationPageLocation,
            CitationVariants::BetaCitationContentBlockLocation(
                var betaCitationContentBlockLocation
            ) => betaCitationContentBlockLocation,
            CitationVariants::BetaCitationsWebSearchResultLocation(
                var betaCitationsWebSearchResultLocation
            ) => betaCitationsWebSearchResultLocation,
            CitationVariants::BetaCitationSearchResultLocation(
                var betaCitationSearchResultLocation
            ) => betaCitationSearchResultLocation,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Citation"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
