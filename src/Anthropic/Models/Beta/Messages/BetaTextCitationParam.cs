using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationParamConverter))]
public abstract record class BetaTextCitationParam
{
    internal BetaTextCitationParam() { }

    public static implicit operator BetaTextCitationParam(BetaCitationCharLocationParam value) =>
        new BetaCitationCharLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(BetaCitationPageLocationParam value) =>
        new BetaCitationPageLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value
    ) => new BetaCitationContentBlockLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value
    ) => new BetaCitationWebSearchResultLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value
    ) => new BetaCitationSearchResultLocationParamVariant(value);

    public bool TryPickBetaCitationCharLocationParamVariant(
        [NotNullWhen(true)] out BetaCitationCharLocationParam? value
    )
    {
        value = (this as BetaCitationCharLocationParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationPageLocationParamVariant(
        [NotNullWhen(true)] out BetaCitationPageLocationParam? value
    )
    {
        value = (this as BetaCitationPageLocationParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationContentBlockLocationParamVariant(
        [NotNullWhen(true)] out BetaCitationContentBlockLocationParam? value
    )
    {
        value = (this as BetaCitationContentBlockLocationParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationWebSearchResultLocationParamVariant(
        [NotNullWhen(true)] out BetaCitationWebSearchResultLocationParam? value
    )
    {
        value = (this as BetaCitationWebSearchResultLocationParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationSearchResultLocationParamVariant(
        [NotNullWhen(true)] out BetaCitationSearchResultLocationParam? value
    )
    {
        value = (this as BetaCitationSearchResultLocationParamVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaCitationCharLocationParamVariant> betaCitationCharLocationParam,
        Action<BetaCitationPageLocationParamVariant> betaCitationPageLocationParam,
        Action<BetaCitationContentBlockLocationParamVariant> betaCitationContentBlockLocationParam,
        Action<BetaCitationWebSearchResultLocationParamVariant> betaCitationWebSearchResultLocationParam,
        Action<BetaCitationSearchResultLocationParamVariant> betaCitationSearchResultLocationParam
    )
    {
        switch (this)
        {
            case BetaCitationCharLocationParamVariant inner:
                betaCitationCharLocationParam(inner);
                break;
            case BetaCitationPageLocationParamVariant inner:
                betaCitationPageLocationParam(inner);
                break;
            case BetaCitationContentBlockLocationParamVariant inner:
                betaCitationContentBlockLocationParam(inner);
                break;
            case BetaCitationWebSearchResultLocationParamVariant inner:
                betaCitationWebSearchResultLocationParam(inner);
                break;
            case BetaCitationSearchResultLocationParamVariant inner:
                betaCitationSearchResultLocationParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaCitationCharLocationParamVariant, T> betaCitationCharLocationParam,
        Func<BetaCitationPageLocationParamVariant, T> betaCitationPageLocationParam,
        Func<BetaCitationContentBlockLocationParamVariant, T> betaCitationContentBlockLocationParam,
        Func<
            BetaCitationWebSearchResultLocationParamVariant,
            T
        > betaCitationWebSearchResultLocationParam,
        Func<BetaCitationSearchResultLocationParamVariant, T> betaCitationSearchResultLocationParam
    )
    {
        return this switch
        {
            BetaCitationCharLocationParamVariant inner => betaCitationCharLocationParam(inner),
            BetaCitationPageLocationParamVariant inner => betaCitationPageLocationParam(inner),
            BetaCitationContentBlockLocationParamVariant inner =>
                betaCitationContentBlockLocationParam(inner),
            BetaCitationWebSearchResultLocationParamVariant inner =>
                betaCitationWebSearchResultLocationParam(inner),
            BetaCitationSearchResultLocationParamVariant inner =>
                betaCitationSearchResultLocationParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaTextCitationParamConverter : JsonConverter<BetaTextCitationParam>
{
    public override BetaTextCitationParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaCitationCharLocationParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaCitationPageLocationParamVariant(deserialized);
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationContentBlockLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaCitationContentBlockLocationParamVariant(deserialized);
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
                        JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaCitationWebSearchResultLocationParamVariant(deserialized);
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaCitationSearchResultLocationParamVariant(deserialized);
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
        BetaTextCitationParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaCitationCharLocationParamVariant(var betaCitationCharLocationParam) =>
                betaCitationCharLocationParam,
            BetaCitationPageLocationParamVariant(var betaCitationPageLocationParam) =>
                betaCitationPageLocationParam,
            BetaCitationContentBlockLocationParamVariant(
                var betaCitationContentBlockLocationParam
            ) => betaCitationContentBlockLocationParam,
            BetaCitationWebSearchResultLocationParamVariant(
                var betaCitationWebSearchResultLocationParam
            ) => betaCitationWebSearchResultLocationParam,
            BetaCitationSearchResultLocationParamVariant(
                var betaCitationSearchResultLocationParam
            ) => betaCitationSearchResultLocationParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
