using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaContextManagementResponse>))]
public sealed record class BetaContextManagementResponse
    : ModelBase,
        IFromRaw<BetaContextManagementResponse>
{
    /// <summary>
    /// List of context management edits that were applied.
    /// </summary>
    public required List<AppliedEdit> AppliedEdits
    {
        get
        {
            if (!this.Properties.TryGetValue("applied_edits", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'applied_edits' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applied_edits",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<AppliedEdit>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'applied_edits' cannot be null",
                    new System::ArgumentNullException("applied_edits")
                );
        }
        set
        {
            this.Properties["applied_edits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.AppliedEdits)
        {
            item.Validate();
        }
    }

    public BetaContextManagementResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContextManagementResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaContextManagementResponse(List<AppliedEdit> appliedEdits)
        : this()
    {
        this.AppliedEdits = appliedEdits;
    }
}

[JsonConverter(typeof(AppliedEditConverter))]
public record class AppliedEdit
{
    public object Value { get; private init; }

    public long ClearedInputTokens
    {
        get
        {
            return Match(
                betaClearToolUses20250919EditResponse: (x) => x.ClearedInputTokens,
                betaClearThinking20251015EditResponse: (x) => x.ClearedInputTokens
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaClearToolUses20250919EditResponse: (x) => x.Type,
                betaClearThinking20251015EditResponse: (x) => x.Type
            );
        }
    }

    public AppliedEdit(BetaClearToolUses20250919EditResponse value)
    {
        Value = value;
    }

    public AppliedEdit(BetaClearThinking20251015EditResponse value)
    {
        Value = value;
    }

    AppliedEdit(UnknownVariant value)
    {
        Value = value;
    }

    public static AppliedEdit CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaClearToolUses20250919EditResponse(
        [NotNullWhen(true)] out BetaClearToolUses20250919EditResponse? value
    )
    {
        value = this.Value as BetaClearToolUses20250919EditResponse;
        return value != null;
    }

    public bool TryPickBetaClearThinking20251015EditResponse(
        [NotNullWhen(true)] out BetaClearThinking20251015EditResponse? value
    )
    {
        value = this.Value as BetaClearThinking20251015EditResponse;
        return value != null;
    }

    public void Switch(
        System::Action<BetaClearToolUses20250919EditResponse> betaClearToolUses20250919EditResponse,
        System::Action<BetaClearThinking20251015EditResponse> betaClearThinking20251015EditResponse
    )
    {
        switch (this.Value)
        {
            case BetaClearToolUses20250919EditResponse value:
                betaClearToolUses20250919EditResponse(value);
                break;
            case BetaClearThinking20251015EditResponse value:
                betaClearThinking20251015EditResponse(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of AppliedEdit"
                );
        }
    }

    public T Match<T>(
        System::Func<
            BetaClearToolUses20250919EditResponse,
            T
        > betaClearToolUses20250919EditResponse,
        System::Func<BetaClearThinking20251015EditResponse, T> betaClearThinking20251015EditResponse
    )
    {
        return this.Value switch
        {
            BetaClearToolUses20250919EditResponse value => betaClearToolUses20250919EditResponse(
                value
            ),
            BetaClearThinking20251015EditResponse value => betaClearThinking20251015EditResponse(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of AppliedEdit"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of AppliedEdit"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class AppliedEditConverter : JsonConverter<AppliedEdit>
{
    public override AppliedEdit? Read(
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
            case "clear_tool_uses_20250919":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClearToolUses20250919EditResponse>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new AppliedEdit(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaClearToolUses20250919EditResponse'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "clear_thinking_20251015":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClearThinking20251015EditResponse>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new AppliedEdit(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaClearThinking20251015EditResponse'",
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

    public override void Write(
        Utf8JsonWriter writer,
        AppliedEdit value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
