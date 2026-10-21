using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// A limit Anthropic has placed on the entity this profile represents and not yet
/// resolved, discriminated by `type`: `restriction` or `ban`. More types may be added;
/// read a `type` you do not recognize as `restriction`.
/// </summary>
[JsonConverter(typeof(UserProfileEnforcementActionConverter))]
public record class UserProfileEnforcementAction : ModelBase
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

    public string ID
    {
        get
        {
            return this.Value switch
            {
                UserProfileEnforcementActionRestriction x => x.ID,
                UserProfileEnforcementActionBan x => x.ID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public ApiEnum<string, UserProfileEnforcementActionNextStep>? Action
    {
        get
        {
            return this.Value switch
            {
                UserProfileEnforcementActionRestriction x => x.Action,
                UserProfileEnforcementActionBan x => x.Action,
                _ => WrappedJsonSerializer.GetNullableClassProperty<
                    ApiEnum<string, UserProfileEnforcementActionNextStep>
                >(this.Json, "action"),
            };
        }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            return this.Value switch
            {
                UserProfileEnforcementActionRestriction x => x.ExpiresAt,
                UserProfileEnforcementActionBan x => x.ExpiresAt,
                _ => WrappedJsonSerializer.GetNullableStructProperty<DateTimeOffset>(
                    this.Json,
                    "expires_at"
                ),
            };
        }
    }

    public DateTimeOffset OpenedAt
    {
        get
        {
            return this.Value switch
            {
                UserProfileEnforcementActionRestriction x => x.OpenedAt,
                UserProfileEnforcementActionBan x => x.OpenedAt,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<DateTimeOffset>(
                    this.Json,
                    "opened_at"
                ),
            };
        }
    }

    public ApiEnum<string, UserProfileEnforcementActionReason> Reason
    {
        get
        {
            return this.Value switch
            {
                UserProfileEnforcementActionRestriction x => x.Reason,
                UserProfileEnforcementActionBan x => x.Reason,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, UserProfileEnforcementActionReason>
                >(this.Json, "reason"),
            };
        }
    }

    public ApiEnum<string, UserProfileEnforcementActionType> Type
    {
        get
        {
            return this.Value switch
            {
                UserProfileEnforcementActionRestriction _ =>
                    UserProfileEnforcementActionType.Restriction,
                UserProfileEnforcementActionBan _ => UserProfileEnforcementActionType.Ban,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, UserProfileEnforcementActionType>
                >(this.Json, "type"),
            };
        }
    }

    public UserProfileEnforcementAction(
        UserProfileEnforcementActionRestriction value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UserProfileEnforcementAction(
        UserProfileEnforcementActionBan value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UserProfileEnforcementAction(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserProfileEnforcementActionRestriction"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRestriction(out var value)) {
    ///     // `value` is of type `UserProfileEnforcementActionRestriction`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRestriction(
        [NotNullWhen(true)] out UserProfileEnforcementActionRestriction? value
    )
    {
        value = this.Value as UserProfileEnforcementActionRestriction;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserProfileEnforcementActionBan"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBan(out var value)) {
    ///     // `value` is of type `UserProfileEnforcementActionBan`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBan([NotNullWhen(true)] out UserProfileEnforcementActionBan? value)
    {
        value = this.Value as UserProfileEnforcementActionBan;
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
    ///     (UserProfileEnforcementActionRestriction value) =&gt; {...},
    ///     (UserProfileEnforcementActionBan value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UserProfileEnforcementActionRestriction> restriction,
        Action<UserProfileEnforcementActionBan> ban
    )
    {
        switch (this.Value)
        {
            case UserProfileEnforcementActionRestriction value:
                restriction(value);
                break;
            case UserProfileEnforcementActionBan value:
                ban(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of UserProfileEnforcementAction"
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
    ///     (UserProfileEnforcementActionRestriction value) =&gt; {...},
    ///     (UserProfileEnforcementActionBan value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UserProfileEnforcementActionRestriction, T> restriction,
        Func<UserProfileEnforcementActionBan, T> ban
    )
    {
        return this.Value switch
        {
            UserProfileEnforcementActionRestriction value => restriction(value),
            UserProfileEnforcementActionBan value => ban(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of UserProfileEnforcementAction"
            ),
        };
    }

    public static implicit operator UserProfileEnforcementAction(
        UserProfileEnforcementActionRestriction value
    ) => new(value);

    public static implicit operator UserProfileEnforcementAction(
        UserProfileEnforcementActionBan value
    ) => new(value);

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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of UserProfileEnforcementAction"
            );
        }
        this.Switch((restriction) => restriction.Validate(), (ban) => ban.Validate());
    }

    public virtual bool Equals(UserProfileEnforcementAction? other) =>
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
            UserProfileEnforcementActionRestriction _ => 0,
            UserProfileEnforcementActionBan _ => 1,
            _ => -1,
        };
    }
}

sealed class UserProfileEnforcementActionConverter : JsonConverter<UserProfileEnforcementAction>
{
    public override UserProfileEnforcementAction? Read(
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
            case "restriction":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UserProfileEnforcementActionRestriction>(
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
            case "ban":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UserProfileEnforcementActionBan>(
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
                return new UserProfileEnforcementAction(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileEnforcementAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UserProfileEnforcementActionTypeConverter))]
public enum UserProfileEnforcementActionType
{
    Restriction,
    Ban,
}

sealed class UserProfileEnforcementActionTypeConverter
    : JsonConverter<UserProfileEnforcementActionType>
{
    public override UserProfileEnforcementActionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "restriction" => UserProfileEnforcementActionType.Restriction,
            "ban" => UserProfileEnforcementActionType.Ban,
            _ => (UserProfileEnforcementActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileEnforcementActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileEnforcementActionType.Restriction => "restriction",
                UserProfileEnforcementActionType.Ban => "ban",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
