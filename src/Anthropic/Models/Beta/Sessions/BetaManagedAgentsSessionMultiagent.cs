using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved multiagent orchestration configuration as returned on a `session`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionMultiagentConverter))]
public record class BetaManagedAgentsSessionMultiagent : ModelBase
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

    public BetaManagedAgentsSessionMultiagent(
        BetaManagedAgentsSessionMultiagentCoordinator value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagent(
        BetaManagedAgentsSessionMultiagent20261001 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionMultiagentCoordinator"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoordinator(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionMultiagentCoordinator`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoordinator(
        [NotNullWhen(true)] out BetaManagedAgentsSessionMultiagentCoordinator? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionMultiagentCoordinator;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionMultiagent20261001"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiagent20261001(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionMultiagent20261001`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiagent20261001(
        [NotNullWhen(true)] out BetaManagedAgentsSessionMultiagent20261001? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionMultiagent20261001;
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
    ///     (BetaManagedAgentsSessionMultiagentCoordinator value) =&gt; {...},
    ///     (BetaManagedAgentsSessionMultiagent20261001 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsSessionMultiagentCoordinator> coordinator,
        System::Action<BetaManagedAgentsSessionMultiagent20261001> multiagent20261001
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsSessionMultiagentCoordinator value:
                coordinator(value);
                break;
            case BetaManagedAgentsSessionMultiagent20261001 value:
                multiagent20261001(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionMultiagent"
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
    ///     (BetaManagedAgentsSessionMultiagentCoordinator value) =&gt; {...},
    ///     (BetaManagedAgentsSessionMultiagent20261001 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsSessionMultiagentCoordinator, T> coordinator,
        System::Func<BetaManagedAgentsSessionMultiagent20261001, T> multiagent20261001
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionMultiagentCoordinator value => coordinator(value),
            BetaManagedAgentsSessionMultiagent20261001 value => multiagent20261001(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionMultiagent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionMultiagent(
        BetaManagedAgentsSessionMultiagentCoordinator value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionMultiagent(
        BetaManagedAgentsSessionMultiagent20261001 value
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
                "Data did not match any variant of BetaManagedAgentsSessionMultiagent"
            );
        }
        this.Switch(
            (coordinator) => coordinator.Validate(),
            (multiagent20261001) => multiagent20261001.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionMultiagent? other) =>
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
            BetaManagedAgentsSessionMultiagentCoordinator _ => 0,
            BetaManagedAgentsSessionMultiagent20261001 _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionMultiagentConverter
    : JsonConverter<BetaManagedAgentsSessionMultiagent>
{
    public override BetaManagedAgentsSessionMultiagent? Read(
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
            case "coordinator":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentCoordinator>(
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
            case "multiagent_20261001":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagent20261001>(
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
                return new BetaManagedAgentsSessionMultiagent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionMultiagent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
