using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationsDelta, BetaCitationsDeltaFromRaw>))]
public sealed record class BetaCitationsDelta : ModelBase
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

    public BetaCitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

    public BetaCitationsDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationsDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaCitationsDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}

class BetaCitationsDeltaFromRaw : IFromRaw<BetaCitationsDelta>
{
    public BetaCitationsDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCitationsDelta.FromRawUnchecked(rawData);
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

    public Citation(BetaCitationCharLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(BetaCitationPageLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(BetaCitationContentBlockLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(BetaCitationsWebSearchResultLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(BetaCitationSearchResultLocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Citation(JsonElement json)
    {
        this._json = json;
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
        System::Action<BetaCitationCharLocation> betaCitationCharLocation,
        System::Action<BetaCitationPageLocation> betaCitationPageLocation,
        System::Action<BetaCitationContentBlockLocation> betaCitationContentBlockLocation,
        System::Action<BetaCitationsWebSearchResultLocation> betaCitationsWebSearchResultLocation,
        System::Action<BetaCitationSearchResultLocation> betaCitationSearchResultLocation
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
        System::Func<BetaCitationCharLocation, T> betaCitationCharLocation,
        System::Func<BetaCitationPageLocation, T> betaCitationPageLocation,
        System::Func<BetaCitationContentBlockLocation, T> betaCitationContentBlockLocation,
        System::Func<BetaCitationsWebSearchResultLocation, T> betaCitationsWebSearchResultLocation,
        System::Func<BetaCitationSearchResultLocation, T> betaCitationSearchResultLocation
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

    public static implicit operator Citation(BetaCitationCharLocation value) => new(value);

    public static implicit operator Citation(BetaCitationPageLocation value) => new(value);

    public static implicit operator Citation(BetaCitationContentBlockLocation value) => new(value);

    public static implicit operator Citation(BetaCitationsWebSearchResultLocation value) =>
        new(value);

    public static implicit operator Citation(BetaCitationSearchResultLocation value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Citation");
        }
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
                return new Citation(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
