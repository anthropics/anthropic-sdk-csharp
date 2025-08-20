using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(BetaCitationCharLocation value) =>
        new BetaCitationCharLocationVariant(value);

    public static implicit operator Citation(BetaCitationPageLocation value) =>
        new BetaCitationPageLocationVariant(value);

    public static implicit operator Citation(BetaCitationContentBlockLocation value) =>
        new BetaCitationContentBlockLocationVariant(value);

    public static implicit operator Citation(BetaCitationsWebSearchResultLocation value) =>
        new BetaCitationsWebSearchResultLocationVariant(value);

    public static implicit operator Citation(BetaCitationSearchResultLocation value) =>
        new BetaCitationSearchResultLocationVariant(value);

    public bool TryPickBetaCitationCharLocationVariant(
        [NotNullWhen(true)] out BetaCitationCharLocation? value
    )
    {
        value = (this as BetaCitationCharLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationPageLocationVariant(
        [NotNullWhen(true)] out BetaCitationPageLocation? value
    )
    {
        value = (this as BetaCitationPageLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationContentBlockLocationVariant(
        [NotNullWhen(true)] out BetaCitationContentBlockLocation? value
    )
    {
        value = (this as BetaCitationContentBlockLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationsWebSearchResultLocationVariant(
        [NotNullWhen(true)] out BetaCitationsWebSearchResultLocation? value
    )
    {
        value = (this as BetaCitationsWebSearchResultLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationSearchResultLocationVariant(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = (this as BetaCitationSearchResultLocationVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaCitationCharLocationVariant> betaCitationCharLocation,
        Action<BetaCitationPageLocationVariant> betaCitationPageLocation,
        Action<BetaCitationContentBlockLocationVariant> betaCitationContentBlockLocation,
        Action<BetaCitationsWebSearchResultLocationVariant> betaCitationsWebSearchResultLocation,
        Action<BetaCitationSearchResultLocationVariant> betaCitationSearchResultLocation
    )
    {
        switch (this)
        {
            case BetaCitationCharLocationVariant inner:
                betaCitationCharLocation(inner);
                break;
            case BetaCitationPageLocationVariant inner:
                betaCitationPageLocation(inner);
                break;
            case BetaCitationContentBlockLocationVariant inner:
                betaCitationContentBlockLocation(inner);
                break;
            case BetaCitationsWebSearchResultLocationVariant inner:
                betaCitationsWebSearchResultLocation(inner);
                break;
            case BetaCitationSearchResultLocationVariant inner:
                betaCitationSearchResultLocation(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaCitationCharLocationVariant, T> betaCitationCharLocation,
        Func<BetaCitationPageLocationVariant, T> betaCitationPageLocation,
        Func<BetaCitationContentBlockLocationVariant, T> betaCitationContentBlockLocation,
        Func<BetaCitationsWebSearchResultLocationVariant, T> betaCitationsWebSearchResultLocation,
        Func<BetaCitationSearchResultLocationVariant, T> betaCitationSearchResultLocation
    )
    {
        return this switch
        {
            BetaCitationCharLocationVariant inner => betaCitationCharLocation(inner),
            BetaCitationPageLocationVariant inner => betaCitationPageLocation(inner),
            BetaCitationContentBlockLocationVariant inner => betaCitationContentBlockLocation(
                inner
            ),
            BetaCitationsWebSearchResultLocationVariant inner =>
                betaCitationsWebSearchResultLocation(inner),
            BetaCitationSearchResultLocationVariant inner => betaCitationSearchResultLocation(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class CitationConverter : JsonConverter<Citation>
{
    public override Citation? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                        return new BetaCitationCharLocationVariant(deserialized);
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
                        return new BetaCitationPageLocationVariant(deserialized);
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
                        return new BetaCitationContentBlockLocationVariant(deserialized);
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
                        return new BetaCitationsWebSearchResultLocationVariant(deserialized);
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
                        return new BetaCitationSearchResultLocationVariant(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BetaCitationCharLocationVariant(var betaCitationCharLocation) =>
                betaCitationCharLocation,
            BetaCitationPageLocationVariant(var betaCitationPageLocation) =>
                betaCitationPageLocation,
            BetaCitationContentBlockLocationVariant(var betaCitationContentBlockLocation) =>
                betaCitationContentBlockLocation,
            BetaCitationsWebSearchResultLocationVariant(var betaCitationsWebSearchResultLocation) =>
                betaCitationsWebSearchResultLocation,
            BetaCitationSearchResultLocationVariant(var betaCitationSearchResultLocation) =>
                betaCitationSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
