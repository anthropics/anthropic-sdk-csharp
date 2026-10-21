using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

[JsonConverter(
    typeof(JsonModelConverter<BetaSpendLimitIncreaseRequest, BetaSpendLimitIncreaseRequestFromRaw>)
)]
public sealed record class BetaSpendLimitIncreaseRequest : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required Actor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Actor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, BetaSpendLimitPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaSpendLimitPeriod>>("period");
        }
        init { this._rawData.Set("period", value); }
    }

    public required DateTimeOffset? ResolvedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("resolved_at");
        }
        init { this._rawData.Set("resolved_at", value); }
    }

    public required ResolvedBy? ResolvedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ResolvedBy>("resolved_by");
        }
        init { this._rawData.Set("resolved_by", value); }
    }

    /// <summary>
    /// Per-member effective-limit report row (`GET /spend_limits/effective`).
    /// </summary>
    public required BetaSpendSummary? SpendSummary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaSpendSummary>("spend_summary");
        }
        init { this._rawData.Set("spend_summary", value); }
    }

    public required ApiEnum<string, BetaSpendLimitIncreaseRequestStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Actor.Validate();
        _ = this.CreatedAt;
        this.Period.Validate();
        _ = this.ResolvedAt;
        this.ResolvedBy?.Validate();
        this.SpendSummary?.Validate();
        this.Status.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("spend_limit_increase_request")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSpendLimitIncreaseRequest()
    {
        this.Type = JsonSerializer.SerializeToElement("spend_limit_increase_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitIncreaseRequest(
        BetaSpendLimitIncreaseRequest betaSpendLimitIncreaseRequest
    )
        : base(betaSpendLimitIncreaseRequest) { }
#pragma warning restore CS8618

    public BetaSpendLimitIncreaseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("spend_limit_increase_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitIncreaseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitIncreaseRequestFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitIncreaseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendLimitIncreaseRequestFromRaw : IFromRawJson<BetaSpendLimitIncreaseRequest>
{
    /// <inheritdoc/>
    public BetaSpendLimitIncreaseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitIncreaseRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActorConverter))]
public record class Actor : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaSpendLimitUserActor x => x.Type,
                BetaSpendLimitScopedApiKeyActor x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Actor(BetaSpendLimitUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Actor(BetaSpendLimitScopedApiKeyActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Actor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitUser(out var value)) {
    ///     // `value` is of type `BetaSpendLimitUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitUser([NotNullWhen(true)] out BetaSpendLimitUserActor? value)
    {
        value = this.Value as BetaSpendLimitUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitScopedApiKeyActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitScopedApiKey(out var value)) {
    ///     // `value` is of type `BetaSpendLimitScopedApiKeyActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitScopedApiKey(
        [NotNullWhen(true)] out BetaSpendLimitScopedApiKeyActor? value
    )
    {
        value = this.Value as BetaSpendLimitScopedApiKeyActor;
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserActor> betaSpendLimitUser,
        Action<BetaSpendLimitScopedApiKeyActor> betaSpendLimitScopedApiKey
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserActor value:
                betaSpendLimitUser(value);
                break;
            case BetaSpendLimitScopedApiKeyActor value:
                betaSpendLimitScopedApiKey(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Actor");
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserActor, T> betaSpendLimitUser,
        Func<BetaSpendLimitScopedApiKeyActor, T> betaSpendLimitScopedApiKey
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserActor value => betaSpendLimitUser(value),
            BetaSpendLimitScopedApiKeyActor value => betaSpendLimitScopedApiKey(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Actor"),
        };
    }

    public static implicit operator Actor(BetaSpendLimitUserActor value) => new(value);

    public static implicit operator Actor(BetaSpendLimitScopedApiKeyActor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Actor");
        }
        this.Switch(
            (betaSpendLimitUser) => betaSpendLimitUser.Validate(),
            (betaSpendLimitScopedApiKey) => betaSpendLimitScopedApiKey.Validate()
        );
    }

    public virtual bool Equals(Actor? other) =>
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
            BetaSpendLimitUserActor _ => 0,
            BetaSpendLimitScopedApiKeyActor _ => 1,
            _ => -1,
        };
    }
}

sealed class ActorConverter : JsonConverter<Actor>
{
    public override Actor? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserActor>(
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
            case "scoped_api_key_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScopedApiKeyActor>(
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
                return new Actor(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Actor value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ResolvedByConverter))]
public record class ResolvedBy : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaSpendLimitUserActor x => x.Type,
                BetaSpendLimitScopedApiKeyActor x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ResolvedBy(BetaSpendLimitUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResolvedBy(BetaSpendLimitScopedApiKeyActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResolvedBy(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitUserActor(out var value)) {
    ///     // `value` is of type `BetaSpendLimitUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitUserActor(
        [NotNullWhen(true)] out BetaSpendLimitUserActor? value
    )
    {
        value = this.Value as BetaSpendLimitUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitScopedApiKeyActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaSpendLimitScopedApiKeyActor(out var value)) {
    ///     // `value` is of type `BetaSpendLimitScopedApiKeyActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaSpendLimitScopedApiKeyActor(
        [NotNullWhen(true)] out BetaSpendLimitScopedApiKeyActor? value
    )
    {
        value = this.Value as BetaSpendLimitScopedApiKeyActor;
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserActor> betaSpendLimitUserActor,
        Action<BetaSpendLimitScopedApiKeyActor> betaSpendLimitScopedApiKeyActor
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserActor value:
                betaSpendLimitUserActor(value);
                break;
            case BetaSpendLimitScopedApiKeyActor value:
                betaSpendLimitScopedApiKeyActor(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ResolvedBy"
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserActor, T> betaSpendLimitUserActor,
        Func<BetaSpendLimitScopedApiKeyActor, T> betaSpendLimitScopedApiKeyActor
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserActor value => betaSpendLimitUserActor(value),
            BetaSpendLimitScopedApiKeyActor value => betaSpendLimitScopedApiKeyActor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ResolvedBy"
            ),
        };
    }

    public static implicit operator ResolvedBy(BetaSpendLimitUserActor value) => new(value);

    public static implicit operator ResolvedBy(BetaSpendLimitScopedApiKeyActor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of ResolvedBy");
        }
        this.Switch(
            (betaSpendLimitUserActor) => betaSpendLimitUserActor.Validate(),
            (betaSpendLimitScopedApiKeyActor) => betaSpendLimitScopedApiKeyActor.Validate()
        );
    }

    public virtual bool Equals(ResolvedBy? other) =>
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
            BetaSpendLimitUserActor _ => 0,
            BetaSpendLimitScopedApiKeyActor _ => 1,
            _ => -1,
        };
    }
}

sealed class ResolvedByConverter : JsonConverter<ResolvedBy?>
{
    public override ResolvedBy? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserActor>(
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
            case "scoped_api_key_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScopedApiKeyActor>(
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
                return new ResolvedBy(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResolvedBy? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
