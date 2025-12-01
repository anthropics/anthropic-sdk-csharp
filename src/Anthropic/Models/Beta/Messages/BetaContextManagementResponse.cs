using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<BetaContextManagementResponse, BetaContextManagementResponseFromRaw>)
)]
public sealed record class BetaContextManagementResponse : ModelBase
{
    /// <summary>
    /// List of context management edits that were applied.
    /// </summary>
    public required IReadOnlyList<AppliedEdit> AppliedEdits
    {
        get
        {
            if (!this._rawData.TryGetValue("applied_edits", out JsonElement element))
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
        init
        {
            this._rawData["applied_edits"] = JsonSerializer.SerializeToElement(
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

    public BetaContextManagementResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaContextManagementResponse(List<AppliedEdit> appliedEdits)
        : this()
    {
        this.AppliedEdits = appliedEdits;
    }
}

class BetaContextManagementResponseFromRaw : IFromRaw<BetaContextManagementResponse>
{
    public BetaContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContextManagementResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AppliedEditConverter))]
public record class AppliedEdit
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public AppliedEdit(BetaClearToolUses20250919EditResponse value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AppliedEdit(BetaClearThinking20251015EditResponse value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AppliedEdit(JsonElement json)
    {
        this._json = json;
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

    public static implicit operator AppliedEdit(BetaClearToolUses20250919EditResponse value) =>
        new(value);

    public static implicit operator AppliedEdit(BetaClearThinking20251015EditResponse value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of AppliedEdit"
            );
        }
    }

    public virtual bool Equals(AppliedEdit? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
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
            case "clear_thinking_20251015":
            {
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
                return new AppliedEdit(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliedEdit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
