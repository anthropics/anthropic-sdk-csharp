using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaTextCitationParamVariants = Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationParamConverter))]
public abstract record class BetaTextCitationParam
{
    internal BetaTextCitationParam() { }

    public static implicit operator BetaTextCitationParam(BetaCitationCharLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationCharLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(BetaCitationPageLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationPageLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParamVariant(value);

    public abstract void Validate();
}

sealed class BetaTextCitationParamConverter : JsonConverter<BetaTextCitationParam>
{
    public override BetaTextCitationParam? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new BetaTextCitationParamVariants::BetaCitationCharLocationParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaTextCitationParamVariants::BetaCitationPageLocationParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
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
            BetaTextCitationParamVariants::BetaCitationCharLocationParamVariant(
                var betaCitationCharLocationParam
            ) => betaCitationCharLocationParam,
            BetaTextCitationParamVariants::BetaCitationPageLocationParamVariant(
                var betaCitationPageLocationParam
            ) => betaCitationPageLocationParam,
            BetaTextCitationParamVariants::BetaCitationContentBlockLocationParamVariant(
                var betaCitationContentBlockLocationParam
            ) => betaCitationContentBlockLocationParam,
            BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParamVariant(
                var betaCitationWebSearchResultLocationParam
            ) => betaCitationWebSearchResultLocationParam,
            BetaTextCitationParamVariants::BetaCitationSearchResultLocationParamVariant(
                var betaCitationSearchResultLocationParam
            ) => betaCitationSearchResultLocationParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
