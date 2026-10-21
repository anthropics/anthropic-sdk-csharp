using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles.ActionUrls;

/// <summary>
/// The action that the person who opens the URL takes, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaUserProfileActionConverter))]
public record class BetaUserProfileAction : ModelBase
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

    public BetaUserProfileAction(
        BetaUserProfileEnrollEndUserAction value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaUserProfileAction(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaUserProfileEnrollEndUserAction"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnrollEndUser(out var value)) {
    ///     // `value` is of type `BetaUserProfileEnrollEndUserAction`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnrollEndUser(
        [NotNullWhen(true)] out BetaUserProfileEnrollEndUserAction? value
    )
    {
        value = this.Value as BetaUserProfileEnrollEndUserAction;
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
    ///     (BetaUserProfileEnrollEndUserAction value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<BetaUserProfileEnrollEndUserAction> enrollEndUser)
    {
        switch (this.Value)
        {
            case BetaUserProfileEnrollEndUserAction value:
                enrollEndUser(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaUserProfileAction"
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
    ///     (BetaUserProfileEnrollEndUserAction value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<BetaUserProfileEnrollEndUserAction, T> enrollEndUser)
    {
        return this.Value switch
        {
            BetaUserProfileEnrollEndUserAction value => enrollEndUser(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaUserProfileAction"
            ),
        };
    }

    public static implicit operator BetaUserProfileAction(
        BetaUserProfileEnrollEndUserAction value
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
                "Data did not match any variant of BetaUserProfileAction"
            );
        }
        this.Switch((enrollEndUser) => enrollEndUser.Validate());
    }

    public virtual bool Equals(BetaUserProfileAction? other) =>
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
            BetaUserProfileEnrollEndUserAction _ => 0,
            _ => -1,
        };
    }
}

sealed class BetaUserProfileActionConverter : JsonConverter<BetaUserProfileAction>
{
    public override BetaUserProfileAction? Read(
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
            case "enroll_end_user":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaUserProfileEnrollEndUserAction>(
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
                return new BetaUserProfileAction(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUserProfileAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
