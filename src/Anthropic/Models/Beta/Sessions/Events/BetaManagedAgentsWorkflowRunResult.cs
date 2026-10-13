using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// How a workflow run ended.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsWorkflowRunResultConverter))]
public record class BetaManagedAgentsWorkflowRunResult : ModelBase
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
                BetaManagedAgentsWorkflowRunResultCompleted x => x.Type,
                BetaManagedAgentsWorkflowRunResultError x => x.Type,
                BetaManagedAgentsWorkflowRunResultStopped x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsWorkflowRunResult(
        BetaManagedAgentsWorkflowRunResultCompleted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunResult(
        BetaManagedAgentsWorkflowRunResultError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunResult(
        BetaManagedAgentsWorkflowRunResultStopped value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunResult(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWorkflowRunResultCompleted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompleted(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWorkflowRunResultCompleted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompleted(
        [NotNullWhen(true)] out BetaManagedAgentsWorkflowRunResultCompleted? value
    )
    {
        value = this.Value as BetaManagedAgentsWorkflowRunResultCompleted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWorkflowRunResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWorkflowRunResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out BetaManagedAgentsWorkflowRunResultError? value)
    {
        value = this.Value as BetaManagedAgentsWorkflowRunResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWorkflowRunResultStopped"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStopped(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWorkflowRunResultStopped`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStopped(
        [NotNullWhen(true)] out BetaManagedAgentsWorkflowRunResultStopped? value
    )
    {
        value = this.Value as BetaManagedAgentsWorkflowRunResultStopped;
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
    ///     (BetaManagedAgentsWorkflowRunResultCompleted value) =&gt; {...},
    ///     (BetaManagedAgentsWorkflowRunResultError value) =&gt; {...},
    ///     (BetaManagedAgentsWorkflowRunResultStopped value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsWorkflowRunResultCompleted> completed,
        System::Action<BetaManagedAgentsWorkflowRunResultError> error,
        System::Action<BetaManagedAgentsWorkflowRunResultStopped> stopped
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsWorkflowRunResultCompleted value:
                completed(value);
                break;
            case BetaManagedAgentsWorkflowRunResultError value:
                error(value);
                break;
            case BetaManagedAgentsWorkflowRunResultStopped value:
                stopped(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsWorkflowRunResult"
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
    ///     (BetaManagedAgentsWorkflowRunResultCompleted value) =&gt; {...},
    ///     (BetaManagedAgentsWorkflowRunResultError value) =&gt; {...},
    ///     (BetaManagedAgentsWorkflowRunResultStopped value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsWorkflowRunResultCompleted, T> completed,
        System::Func<BetaManagedAgentsWorkflowRunResultError, T> error,
        System::Func<BetaManagedAgentsWorkflowRunResultStopped, T> stopped
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsWorkflowRunResultCompleted value => completed(value),
            BetaManagedAgentsWorkflowRunResultError value => error(value),
            BetaManagedAgentsWorkflowRunResultStopped value => stopped(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsWorkflowRunResult"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsWorkflowRunResult(
        BetaManagedAgentsWorkflowRunResultCompleted value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWorkflowRunResult(
        BetaManagedAgentsWorkflowRunResultError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWorkflowRunResult(
        BetaManagedAgentsWorkflowRunResultStopped value
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
                "Data did not match any variant of BetaManagedAgentsWorkflowRunResult"
            );
        }
        this.Switch(
            (completed) => completed.Validate(),
            (error) => error.Validate(),
            (stopped) => stopped.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsWorkflowRunResult? other) =>
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
            BetaManagedAgentsWorkflowRunResultCompleted _ => 0,
            BetaManagedAgentsWorkflowRunResultError _ => 1,
            BetaManagedAgentsWorkflowRunResultStopped _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsWorkflowRunResultConverter
    : JsonConverter<BetaManagedAgentsWorkflowRunResult>
{
    public override BetaManagedAgentsWorkflowRunResult? Read(
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
            case "completed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResultCompleted>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResultError>(
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
            case "stopped":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunResultStopped>(
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
                return new BetaManagedAgentsWorkflowRunResult(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWorkflowRunResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
