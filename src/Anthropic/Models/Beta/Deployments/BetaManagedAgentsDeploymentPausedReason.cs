using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// Why a deployment is paused. Non-null exactly when `status` is `paused`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsDeploymentPausedReasonConverter))]
public record class BetaManagedAgentsDeploymentPausedReason : ModelBase
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

    public BetaManagedAgentsDeploymentPausedReason(
        BetaManagedAgentsManualDeploymentPausedReason value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReason(
        BetaManagedAgentsErrorDeploymentPausedReason value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsDeploymentPausedReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsManualDeploymentPausedReason"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickManual(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsManualDeploymentPausedReason`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickManual(
        [NotNullWhen(true)] out BetaManagedAgentsManualDeploymentPausedReason? value
    )
    {
        value = this.Value as BetaManagedAgentsManualDeploymentPausedReason;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsErrorDeploymentPausedReason"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsErrorDeploymentPausedReason`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError(
        [NotNullWhen(true)] out BetaManagedAgentsErrorDeploymentPausedReason? value
    )
    {
        value = this.Value as BetaManagedAgentsErrorDeploymentPausedReason;
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
    ///     (BetaManagedAgentsManualDeploymentPausedReason value) =&gt; {...},
    ///     (BetaManagedAgentsErrorDeploymentPausedReason value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsManualDeploymentPausedReason> manual,
        System::Action<BetaManagedAgentsErrorDeploymentPausedReason> error
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsManualDeploymentPausedReason value:
                manual(value);
                break;
            case BetaManagedAgentsErrorDeploymentPausedReason value:
                error(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsDeploymentPausedReason"
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
    ///     (BetaManagedAgentsManualDeploymentPausedReason value) =&gt; {...},
    ///     (BetaManagedAgentsErrorDeploymentPausedReason value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsManualDeploymentPausedReason, T> manual,
        System::Func<BetaManagedAgentsErrorDeploymentPausedReason, T> error
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsManualDeploymentPausedReason value => manual(value),
            BetaManagedAgentsErrorDeploymentPausedReason value => error(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsDeploymentPausedReason"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsDeploymentPausedReason(
        BetaManagedAgentsManualDeploymentPausedReason value
    ) => new(value);

    public static implicit operator BetaManagedAgentsDeploymentPausedReason(
        BetaManagedAgentsErrorDeploymentPausedReason value
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
                "Data did not match any variant of BetaManagedAgentsDeploymentPausedReason"
            );
        }
        this.Switch((manual) => manual.Validate(), (error) => error.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsDeploymentPausedReason? other) =>
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
            BetaManagedAgentsManualDeploymentPausedReason _ => 0,
            BetaManagedAgentsErrorDeploymentPausedReason _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsDeploymentPausedReasonConverter
    : JsonConverter<BetaManagedAgentsDeploymentPausedReason>
{
    public override BetaManagedAgentsDeploymentPausedReason? Read(
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
            case "manual":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsManualDeploymentPausedReason>(
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
            case "error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsErrorDeploymentPausedReason>(
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
                return new BetaManagedAgentsDeploymentPausedReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentPausedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
