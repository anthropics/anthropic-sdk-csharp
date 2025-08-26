using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaTextCitationVariants = Anthropic.Beta.Client.Models.Beta.Messages.BetaTextCitationVariants;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationConverter))]
public abstract record class BetaTextCitation
{
    internal BetaTextCitation() { }

    public static implicit operator BetaTextCitation(BetaCitationCharLocation value) =>
        new BetaTextCitationVariants::BetaCitationCharLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationPageLocation value) =>
        new BetaTextCitationVariants::BetaCitationPageLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationContentBlockLocation value) =>
        new BetaTextCitationVariants::BetaCitationContentBlockLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationsWebSearchResultLocation value) =>
        new BetaTextCitationVariants::BetaCitationsWebSearchResultLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationSearchResultLocation value) =>
        new BetaTextCitationVariants::BetaCitationSearchResultLocation(value);

    public bool TryPickCitationCharLocation([NotNullWhen(true)] out BetaCitationCharLocation? value)
    {
        value = (this as BetaTextCitationVariants::BetaCitationCharLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationPageLocation([NotNullWhen(true)] out BetaCitationPageLocation? value)
    {
        value = (this as BetaTextCitationVariants::BetaCitationPageLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocation? value
    )
    {
        value = (this as BetaTextCitationVariants::BetaCitationContentBlockLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationsWebSearchResultLocation? value
    )
    {
        value = (this as BetaTextCitationVariants::BetaCitationsWebSearchResultLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = (this as BetaTextCitationVariants::BetaCitationSearchResultLocation)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaTextCitationVariants::BetaCitationCharLocation> citationCharLocation,
        Action<BetaTextCitationVariants::BetaCitationPageLocation> citationPageLocation,
        Action<BetaTextCitationVariants::BetaCitationContentBlockLocation> citationContentBlockLocation,
        Action<BetaTextCitationVariants::BetaCitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        Action<BetaTextCitationVariants::BetaCitationSearchResultLocation> citationSearchResultLocation
    )
    {
        switch (this)
        {
            case BetaTextCitationVariants::BetaCitationCharLocation inner:
                citationCharLocation(inner);
                break;
            case BetaTextCitationVariants::BetaCitationPageLocation inner:
                citationPageLocation(inner);
                break;
            case BetaTextCitationVariants::BetaCitationContentBlockLocation inner:
                citationContentBlockLocation(inner);
                break;
            case BetaTextCitationVariants::BetaCitationsWebSearchResultLocation inner:
                citationsWebSearchResultLocation(inner);
                break;
            case BetaTextCitationVariants::BetaCitationSearchResultLocation inner:
                citationSearchResultLocation(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaTextCitationVariants::BetaCitationCharLocation, T> citationCharLocation,
        Func<BetaTextCitationVariants::BetaCitationPageLocation, T> citationPageLocation,
        Func<
            BetaTextCitationVariants::BetaCitationContentBlockLocation,
            T
        > citationContentBlockLocation,
        Func<
            BetaTextCitationVariants::BetaCitationsWebSearchResultLocation,
            T
        > citationsWebSearchResultLocation,
        Func<
            BetaTextCitationVariants::BetaCitationSearchResultLocation,
            T
        > citationSearchResultLocation
    )
    {
        return this switch
        {
            BetaTextCitationVariants::BetaCitationCharLocation inner => citationCharLocation(inner),
            BetaTextCitationVariants::BetaCitationPageLocation inner => citationPageLocation(inner),
            BetaTextCitationVariants::BetaCitationContentBlockLocation inner =>
                citationContentBlockLocation(inner),
            BetaTextCitationVariants::BetaCitationsWebSearchResultLocation inner =>
                citationsWebSearchResultLocation(inner),
            BetaTextCitationVariants::BetaCitationSearchResultLocation inner =>
                citationSearchResultLocation(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaTextCitationConverter : JsonConverter<BetaTextCitation>
{
    public override BetaTextCitation? Read(
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationCharLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "page_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationPageLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationContentBlockLocation(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "web_search_result_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationsWebSearchResultLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationsWebSearchResultLocation(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "search_result_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationSearchResultLocation(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextCitation value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaTextCitationVariants::BetaCitationCharLocation(var citationCharLocation) =>
                citationCharLocation,
            BetaTextCitationVariants::BetaCitationPageLocation(var citationPageLocation) =>
                citationPageLocation,
            BetaTextCitationVariants::BetaCitationContentBlockLocation(
                var citationContentBlockLocation
            ) => citationContentBlockLocation,
            BetaTextCitationVariants::BetaCitationsWebSearchResultLocation(
                var citationsWebSearchResultLocation
            ) => citationsWebSearchResultLocation,
            BetaTextCitationVariants::BetaCitationSearchResultLocation(
                var citationSearchResultLocation
            ) => citationSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
