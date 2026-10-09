using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Whether the agent can start workflow runs.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionMultiagentWorkflowsConverter))]
public record class BetaManagedAgentsSessionMultiagentWorkflows : ModelBase
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
                BetaManagedAgentsSessionMultiagentWorkflowsEnabled x => x.Type,
                BetaManagedAgentsMultiagentWorkflowsDisabled x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsSessionMultiagentWorkflows(
        BetaManagedAgentsSessionMultiagentWorkflowsEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagentWorkflows(
        BetaManagedAgentsMultiagentWorkflowsDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionMultiagentWorkflows(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionMultiagentWorkflowsEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionMultiagentWorkflowsEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaManagedAgentsSessionMultiagentWorkflowsEnabled? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionMultiagentWorkflowsEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMultiagentWorkflowsDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiagentWorkflowsDisabled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentWorkflowsDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiagentWorkflowsDisabled(
        [NotNullWhen(true)] out BetaManagedAgentsMultiagentWorkflowsDisabled? value
    )
    {
        value = this.Value as BetaManagedAgentsMultiagentWorkflowsDisabled;
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
    ///     (BetaManagedAgentsSessionMultiagentWorkflowsEnabled value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentWorkflowsDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsSessionMultiagentWorkflowsEnabled> enabled,
        System::Action<BetaManagedAgentsMultiagentWorkflowsDisabled> multiagentWorkflowsDisabled
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsSessionMultiagentWorkflowsEnabled value:
                enabled(value);
                break;
            case BetaManagedAgentsMultiagentWorkflowsDisabled value:
                multiagentWorkflowsDisabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionMultiagentWorkflows"
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
    ///     (BetaManagedAgentsSessionMultiagentWorkflowsEnabled value) =&gt; {...},
    ///     (BetaManagedAgentsMultiagentWorkflowsDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsSessionMultiagentWorkflowsEnabled, T> enabled,
        System::Func<BetaManagedAgentsMultiagentWorkflowsDisabled, T> multiagentWorkflowsDisabled
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionMultiagentWorkflowsEnabled value => enabled(value),
            BetaManagedAgentsMultiagentWorkflowsDisabled value => multiagentWorkflowsDisabled(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionMultiagentWorkflows"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionMultiagentWorkflows(
        BetaManagedAgentsSessionMultiagentWorkflowsEnabled value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionMultiagentWorkflows(
        BetaManagedAgentsMultiagentWorkflowsDisabled value
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
                "Data did not match any variant of BetaManagedAgentsSessionMultiagentWorkflows"
            );
        }
        this.Switch(
            (enabled) => enabled.Validate(),
            (multiagentWorkflowsDisabled) => multiagentWorkflowsDisabled.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionMultiagentWorkflows? other) =>
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
            BetaManagedAgentsSessionMultiagentWorkflowsEnabled _ => 0,
            BetaManagedAgentsMultiagentWorkflowsDisabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionMultiagentWorkflowsConverter
    : JsonConverter<BetaManagedAgentsSessionMultiagentWorkflows>
{
    public override BetaManagedAgentsSessionMultiagentWorkflows? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionMultiagentWorkflowsEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMultiagentWorkflowsDisabled>(
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
                return new BetaManagedAgentsSessionMultiagentWorkflows(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionMultiagentWorkflows value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
