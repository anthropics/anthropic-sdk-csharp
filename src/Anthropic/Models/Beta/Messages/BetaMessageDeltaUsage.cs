using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaMessageDeltaUsage, BetaMessageDeltaUsageFromRaw>))]
public sealed record class BetaMessageDeltaUsage : JsonModel
{
    /// <summary>
    /// The cumulative number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cache_creation_input_tokens");
        }
        init { this._rawData.Set("cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// Per-iteration token usage breakdown.
    ///
    /// <para>Each entry represents one sampling iteration, with its own input/output
    /// token counts and cache statistics. This allows you to: - Determine which
    /// iterations exceeded long context thresholds (&gt;=200k tokens) - Calculate
    /// the true context window size from the last iteration - Understand token accumulation
    /// across server-side tool use loops</para>
    /// </summary>
    public required IReadOnlyList<Iteration>? Iterations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Iteration>>("iterations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Iteration>?>(
                "iterations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The cumulative number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// Breakdown of output tokens by category.
    ///
    /// <para>`output_tokens` remains the inclusive, authoritative total used for
    /// billing. This object provides a read-only decomposition for observability
    /// — for example, how many of the billed output tokens were spent on internal
    /// reasoning that may have been summarized before being returned to you.</para>
    /// </summary>
    public required BetaOutputTokensDetails? OutputTokensDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaOutputTokensDetails>("output_tokens_details");
        }
        init { this._rawData.Set("output_tokens_details", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaServerToolUsage>("server_tool_use");
        }
        init { this._rawData.Set("server_tool_use", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        foreach (var item in this.Iterations ?? [])
        {
            item.Validate();
        }
        _ = this.OutputTokens;
        this.OutputTokensDetails?.Validate();
        this.ServerToolUse?.Validate();
    }

    public BetaMessageDeltaUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMessageDeltaUsage(BetaMessageDeltaUsage betaMessageDeltaUsage)
        : base(betaMessageDeltaUsage) { }
#pragma warning restore CS8618

    public BetaMessageDeltaUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageDeltaUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageDeltaUsageFromRaw.FromRawUnchecked"/>
    public static BetaMessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageDeltaUsageFromRaw : IFromRawJson<BetaMessageDeltaUsage>
{
    /// <inheritdoc/>
    public BetaMessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageDeltaUsage.FromRawUnchecked(rawData);
}

/// <summary>
/// Token usage for a sampling iteration.
/// </summary>
[JsonConverter(typeof(IterationConverter))]
public record class Iteration : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaCacheCreation? CacheCreation
    {
        get
        {
            return Match<BetaCacheCreation?>(
                betaMessageIterationUsage: (x) => x.CacheCreation,
                betaCompactionIterationUsage: (x) => x.CacheCreation,
                betaAdvisorMessageIterationUsage: (x) => x.CacheCreation,
                betaFallbackMessageIterationUsage: (x) => x.CacheCreation
            );
        }
    }

    public long CacheCreationInputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.CacheCreationInputTokens,
                betaCompactionIterationUsage: (x) => x.CacheCreationInputTokens,
                betaAdvisorMessageIterationUsage: (x) => x.CacheCreationInputTokens,
                betaFallbackMessageIterationUsage: (x) => x.CacheCreationInputTokens
            );
        }
    }

    public long CacheReadInputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.CacheReadInputTokens,
                betaCompactionIterationUsage: (x) => x.CacheReadInputTokens,
                betaAdvisorMessageIterationUsage: (x) => x.CacheReadInputTokens,
                betaFallbackMessageIterationUsage: (x) => x.CacheReadInputTokens
            );
        }
    }

    public long InputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.InputTokens,
                betaCompactionIterationUsage: (x) => x.InputTokens,
                betaAdvisorMessageIterationUsage: (x) => x.InputTokens,
                betaFallbackMessageIterationUsage: (x) => x.InputTokens
            );
        }
    }

    public ApiEnum<string, Model>? Model
    {
        get
        {
            return Match<ApiEnum<string, Model>?>(
                betaMessageIterationUsage: (x) => x.Model,
                betaCompactionIterationUsage: (_) => null,
                betaAdvisorMessageIterationUsage: (x) => x.Model,
                betaFallbackMessageIterationUsage: (x) => x.Model
            );
        }
    }

    public long OutputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.OutputTokens,
                betaCompactionIterationUsage: (x) => x.OutputTokens,
                betaAdvisorMessageIterationUsage: (x) => x.OutputTokens,
                betaFallbackMessageIterationUsage: (x) => x.OutputTokens
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.Type,
                betaCompactionIterationUsage: (x) => x.Type,
                betaAdvisorMessageIterationUsage: (x) => x.Type,
                betaFallbackMessageIterationUsage: (x) => x.Type
            );
        }
    }

    public Iteration(BetaMessageIterationUsage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Iteration(BetaCompactionIterationUsage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Iteration(BetaAdvisorMessageIterationUsage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Iteration(BetaFallbackMessageIterationUsage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Iteration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMessageIterationUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaMessageIterationUsage(out var value)) {
    ///     // `value` is of type `BetaMessageIterationUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaMessageIterationUsage(
        [NotNullWhen(true)] out BetaMessageIterationUsage? value
    )
    {
        value = this.Value as BetaMessageIterationUsage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCompactionIterationUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCompactionIterationUsage(out var value)) {
    ///     // `value` is of type `BetaCompactionIterationUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCompactionIterationUsage(
        [NotNullWhen(true)] out BetaCompactionIterationUsage? value
    )
    {
        value = this.Value as BetaCompactionIterationUsage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAdvisorMessageIterationUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAdvisorMessageIterationUsage(out var value)) {
    ///     // `value` is of type `BetaAdvisorMessageIterationUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAdvisorMessageIterationUsage(
        [NotNullWhen(true)] out BetaAdvisorMessageIterationUsage? value
    )
    {
        value = this.Value as BetaAdvisorMessageIterationUsage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaFallbackMessageIterationUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaFallbackMessageIterationUsage(out var value)) {
    ///     // `value` is of type `BetaFallbackMessageIterationUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaFallbackMessageIterationUsage(
        [NotNullWhen(true)] out BetaFallbackMessageIterationUsage? value
    )
    {
        value = this.Value as BetaFallbackMessageIterationUsage;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaMessageIterationUsage value) =&gt; {...},
    ///     (BetaCompactionIterationUsage value) =&gt; {...},
    ///     (BetaAdvisorMessageIterationUsage value) =&gt; {...},
    ///     (BetaFallbackMessageIterationUsage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaMessageIterationUsage> betaMessageIterationUsage,
        System::Action<BetaCompactionIterationUsage> betaCompactionIterationUsage,
        System::Action<BetaAdvisorMessageIterationUsage> betaAdvisorMessageIterationUsage,
        System::Action<BetaFallbackMessageIterationUsage> betaFallbackMessageIterationUsage
    )
    {
        switch (this.Value)
        {
            case BetaMessageIterationUsage value:
                betaMessageIterationUsage(value);
                break;
            case BetaCompactionIterationUsage value:
                betaCompactionIterationUsage(value);
                break;
            case BetaAdvisorMessageIterationUsage value:
                betaAdvisorMessageIterationUsage(value);
                break;
            case BetaFallbackMessageIterationUsage value:
                betaFallbackMessageIterationUsage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Iteration"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaMessageIterationUsage value) =&gt; {...},
    ///     (BetaCompactionIterationUsage value) =&gt; {...},
    ///     (BetaAdvisorMessageIterationUsage value) =&gt; {...},
    ///     (BetaFallbackMessageIterationUsage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaMessageIterationUsage, T> betaMessageIterationUsage,
        System::Func<BetaCompactionIterationUsage, T> betaCompactionIterationUsage,
        System::Func<BetaAdvisorMessageIterationUsage, T> betaAdvisorMessageIterationUsage,
        System::Func<BetaFallbackMessageIterationUsage, T> betaFallbackMessageIterationUsage
    )
    {
        return this.Value switch
        {
            BetaMessageIterationUsage value => betaMessageIterationUsage(value),
            BetaCompactionIterationUsage value => betaCompactionIterationUsage(value),
            BetaAdvisorMessageIterationUsage value => betaAdvisorMessageIterationUsage(value),
            BetaFallbackMessageIterationUsage value => betaFallbackMessageIterationUsage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Iteration"
            ),
        };
    }

    public static implicit operator Iteration(BetaMessageIterationUsage value) => new(value);

    public static implicit operator Iteration(BetaCompactionIterationUsage value) => new(value);

    public static implicit operator Iteration(BetaAdvisorMessageIterationUsage value) => new(value);

    public static implicit operator Iteration(BetaFallbackMessageIterationUsage value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Iteration");
        }
        this.Switch(
            (betaMessageIterationUsage) => betaMessageIterationUsage.Validate(),
            (betaCompactionIterationUsage) => betaCompactionIterationUsage.Validate(),
            (betaAdvisorMessageIterationUsage) => betaAdvisorMessageIterationUsage.Validate(),
            (betaFallbackMessageIterationUsage) => betaFallbackMessageIterationUsage.Validate()
        );
    }

    public virtual bool Equals(Iteration? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaMessageIterationUsage _ => 0,
            BetaCompactionIterationUsage _ => 1,
            BetaAdvisorMessageIterationUsage _ => 2,
            BetaFallbackMessageIterationUsage _ => 3,
            _ => -1,
        };
    }
}

sealed class IterationConverter : JsonConverter<Iteration>
{
    public override Iteration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "message":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMessageIterationUsage>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "compaction":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCompactionIterationUsage>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "advisor_message":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAdvisorMessageIterationUsage>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "fallback_message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaFallbackMessageIterationUsage>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Iteration(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Iteration value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
