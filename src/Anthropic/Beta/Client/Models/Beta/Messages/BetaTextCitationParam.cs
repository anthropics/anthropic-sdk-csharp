using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaTextCitationParamVariants = Anthropic.Beta.Client.Models.Beta.Messages.BetaTextCitationParamVariants;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationParamConverter))]
public abstract record class BetaTextCitationParam
{
    internal BetaTextCitationParam() { }

    public static implicit operator BetaTextCitationParam(BetaCitationCharLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationCharLocationParam(value);

    public static implicit operator BetaTextCitationParam(BetaCitationPageLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationPageLocationParam(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam(value);

    public bool TryPickCitationCharLocation(
        [NotNullWhen(true)] out BetaCitationCharLocationParam? value
    )
    {
        value = (this as BetaTextCitationParamVariants::BetaCitationCharLocationParam)?.Value;
        return value != null;
    }

    public bool TryPickCitationPageLocation(
        [NotNullWhen(true)] out BetaCitationPageLocationParam? value
    )
    {
        value = (this as BetaTextCitationParamVariants::BetaCitationPageLocationParam)?.Value;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocationParam? value
    )
    {
        value = (
            this as BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam
        )?.Value;
        return value != null;
    }

    public bool TryPickCitationWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationWebSearchResultLocationParam? value
    )
    {
        value = (
            this as BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam
        )?.Value;
        return value != null;
    }

    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocationParam? value
    )
    {
        value = (
            this as BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaTextCitationParamVariants::BetaCitationCharLocationParam> citationCharLocation,
        Action<BetaTextCitationParamVariants::BetaCitationPageLocationParam> citationPageLocation,
        Action<BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam> citationContentBlockLocation,
        Action<BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam> citationWebSearchResultLocation,
        Action<BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam> citationSearchResultLocation
    )
    {
        switch (this)
        {
            case BetaTextCitationParamVariants::BetaCitationCharLocationParam inner:
                citationCharLocation(inner);
                break;
            case BetaTextCitationParamVariants::BetaCitationPageLocationParam inner:
                citationPageLocation(inner);
                break;
            case BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam inner:
                citationContentBlockLocation(inner);
                break;
            case BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam inner:
                citationWebSearchResultLocation(inner);
                break;
            case BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam inner:
                citationSearchResultLocation(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaTextCitationParamVariants::BetaCitationCharLocationParam, T> citationCharLocation,
        Func<BetaTextCitationParamVariants::BetaCitationPageLocationParam, T> citationPageLocation,
        Func<
            BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam,
            T
        > citationContentBlockLocation,
        Func<
            BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam,
            T
        > citationWebSearchResultLocation,
        Func<
            BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam,
            T
        > citationSearchResultLocation
    )
    {
        return this switch
        {
            BetaTextCitationParamVariants::BetaCitationCharLocationParam inner =>
                citationCharLocation(inner),
            BetaTextCitationParamVariants::BetaCitationPageLocationParam inner =>
                citationPageLocation(inner),
            BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam inner =>
                citationContentBlockLocation(inner),
            BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam inner =>
                citationWebSearchResultLocation(inner),
            BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam inner =>
                citationSearchResultLocation(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaTextCitationParamConverter : JsonConverter<BetaTextCitationParam>
{
    public override BetaTextCitationParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationParamVariants::BetaCitationCharLocationParam(
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
                        return new BetaTextCitationParamVariants::BetaCitationPageLocationParam(
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
                        return new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam(
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
                        JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam(
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
        BetaTextCitationParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaTextCitationParamVariants::BetaCitationCharLocationParam(
                var citationCharLocation
            ) => citationCharLocation,
            BetaTextCitationParamVariants::BetaCitationPageLocationParam(
                var citationPageLocation
            ) => citationPageLocation,
            BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam(
                var citationContentBlockLocation
            ) => citationContentBlockLocation,
            BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam(
                var citationWebSearchResultLocation
            ) => citationWebSearchResultLocation,
            BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam(
                var citationSearchResultLocation
            ) => citationSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
