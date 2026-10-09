using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Why a workflow run did not finish, or was not created. More types may be added.
/// On `workflow_run.status_ended`, for a `type` you do not recognize, rely on the
/// event's `result.type`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsWorkflowRunErrorConverter))]
public record class BetaManagedAgentsWorkflowRunError : ModelBase
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

    public string Message
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsTimeoutWorkflowRunError x => x.Message,
                BetaManagedAgentsProgramWorkflowRunError x => x.Message,
                BetaManagedAgentsUnknownWorkflowRunError x => x.Message,
                BetaManagedAgentsThreadLimitWorkflowRunError x => x.Message,
                BetaManagedAgentsMaxWorkflowRunsWorkflowRunError x => x.Message,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "message"),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsTimeoutWorkflowRunError x => x.Type,
                BetaManagedAgentsProgramWorkflowRunError x => x.Type,
                BetaManagedAgentsUnknownWorkflowRunError x => x.Type,
                BetaManagedAgentsThreadLimitWorkflowRunError x => x.Type,
                BetaManagedAgentsMaxWorkflowRunsWorkflowRunError x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsTimeoutWorkflowRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsProgramWorkflowRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsUnknownWorkflowRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsThreadLimitWorkflowRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsMaxWorkflowRunsWorkflowRunError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWorkflowRunError(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTimeoutWorkflowRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTimeout(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTimeoutWorkflowRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTimeout(
        [NotNullWhen(true)] out BetaManagedAgentsTimeoutWorkflowRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsTimeoutWorkflowRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsProgramWorkflowRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProgram(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsProgramWorkflowRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickProgram(
        [NotNullWhen(true)] out BetaManagedAgentsProgramWorkflowRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsProgramWorkflowRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUnknownWorkflowRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnknown(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUnknownWorkflowRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnknown(
        [NotNullWhen(true)] out BetaManagedAgentsUnknownWorkflowRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsUnknownWorkflowRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsThreadLimitWorkflowRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThreadLimit(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsThreadLimitWorkflowRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadLimit(
        [NotNullWhen(true)] out BetaManagedAgentsThreadLimitWorkflowRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsThreadLimitWorkflowRunError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMaxWorkflowRunsWorkflowRunError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMaxWorkflowRuns(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMaxWorkflowRunsWorkflowRunError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMaxWorkflowRuns(
        [NotNullWhen(true)] out BetaManagedAgentsMaxWorkflowRunsWorkflowRunError? value
    )
    {
        value = this.Value as BetaManagedAgentsMaxWorkflowRunsWorkflowRunError;
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
    ///     (BetaManagedAgentsTimeoutWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsProgramWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsUnknownWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsThreadLimitWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsMaxWorkflowRunsWorkflowRunError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTimeoutWorkflowRunError> timeout,
        System::Action<BetaManagedAgentsProgramWorkflowRunError> program,
        System::Action<BetaManagedAgentsUnknownWorkflowRunError> unknown,
        System::Action<BetaManagedAgentsThreadLimitWorkflowRunError> threadLimit,
        System::Action<BetaManagedAgentsMaxWorkflowRunsWorkflowRunError> maxWorkflowRuns
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTimeoutWorkflowRunError value:
                timeout(value);
                break;
            case BetaManagedAgentsProgramWorkflowRunError value:
                program(value);
                break;
            case BetaManagedAgentsUnknownWorkflowRunError value:
                unknown(value);
                break;
            case BetaManagedAgentsThreadLimitWorkflowRunError value:
                threadLimit(value);
                break;
            case BetaManagedAgentsMaxWorkflowRunsWorkflowRunError value:
                maxWorkflowRuns(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsWorkflowRunError"
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
    ///     (BetaManagedAgentsTimeoutWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsProgramWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsUnknownWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsThreadLimitWorkflowRunError value) =&gt; {...},
    ///     (BetaManagedAgentsMaxWorkflowRunsWorkflowRunError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsTimeoutWorkflowRunError, T> timeout,
        System::Func<BetaManagedAgentsProgramWorkflowRunError, T> program,
        System::Func<BetaManagedAgentsUnknownWorkflowRunError, T> unknown,
        System::Func<BetaManagedAgentsThreadLimitWorkflowRunError, T> threadLimit,
        System::Func<BetaManagedAgentsMaxWorkflowRunsWorkflowRunError, T> maxWorkflowRuns
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTimeoutWorkflowRunError value => timeout(value),
            BetaManagedAgentsProgramWorkflowRunError value => program(value),
            BetaManagedAgentsUnknownWorkflowRunError value => unknown(value),
            BetaManagedAgentsThreadLimitWorkflowRunError value => threadLimit(value),
            BetaManagedAgentsMaxWorkflowRunsWorkflowRunError value => maxWorkflowRuns(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsWorkflowRunError"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsTimeoutWorkflowRunError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsProgramWorkflowRunError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsUnknownWorkflowRunError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsThreadLimitWorkflowRunError value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWorkflowRunError(
        BetaManagedAgentsMaxWorkflowRunsWorkflowRunError value
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
                "Data did not match any variant of BetaManagedAgentsWorkflowRunError"
            );
        }
        this.Switch(
            (timeout) => timeout.Validate(),
            (program) => program.Validate(),
            (unknown) => unknown.Validate(),
            (threadLimit) => threadLimit.Validate(),
            (maxWorkflowRuns) => maxWorkflowRuns.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsWorkflowRunError? other) =>
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
            BetaManagedAgentsTimeoutWorkflowRunError _ => 0,
            BetaManagedAgentsProgramWorkflowRunError _ => 1,
            BetaManagedAgentsUnknownWorkflowRunError _ => 2,
            BetaManagedAgentsThreadLimitWorkflowRunError _ => 3,
            BetaManagedAgentsMaxWorkflowRunsWorkflowRunError _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsWorkflowRunErrorConverter
    : JsonConverter<BetaManagedAgentsWorkflowRunError>
{
    public override BetaManagedAgentsWorkflowRunError? Read(
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
            case "timeout_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsTimeoutWorkflowRunError>(
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
            case "program_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsProgramWorkflowRunError>(
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
            case "unknown_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUnknownWorkflowRunError>(
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
            case "thread_limit_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsThreadLimitWorkflowRunError>(
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
            case "max_workflow_runs_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMaxWorkflowRunsWorkflowRunError>(
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
                return new BetaManagedAgentsWorkflowRunError(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWorkflowRunError value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
