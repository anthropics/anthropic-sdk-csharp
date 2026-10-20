using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Which of the organization's workspaces a telemetry destination covers.
///
/// <para>Several destinations can cover the same workspace. Each of them receives
/// the workspace's spans while it is enabled.</para>
///
/// <para>The workspace list of an `include` or `exclude` destination isn't part of
/// the destination object. List the destination's workspaces to read it. Add or
/// remove one workspace at a time, or replace the whole list with an update. A list
/// holds at most 1,000 workspaces.</para>
/// </summary>
[JsonConverter(typeof(BetaTelemetryDestinationWorkspacesConverter))]
public record class BetaTelemetryDestinationWorkspaces : ModelBase
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
                BetaTelemetryDestinationWorkspacesAll x => x.Type,
                BetaTelemetryDestinationWorkspacesInclude x => x.Type,
                BetaTelemetryDestinationWorkspacesExclude x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaTelemetryDestinationWorkspaces(
        BetaTelemetryDestinationWorkspacesAll value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationWorkspaces(
        BetaTelemetryDestinationWorkspacesInclude value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationWorkspaces(
        BetaTelemetryDestinationWorkspacesExclude value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationWorkspaces(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationWorkspacesAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAll(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationWorkspacesAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAll([NotNullWhen(true)] out BetaTelemetryDestinationWorkspacesAll? value)
    {
        value = this.Value as BetaTelemetryDestinationWorkspacesAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationWorkspacesInclude"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInclude(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationWorkspacesInclude`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInclude(
        [NotNullWhen(true)] out BetaTelemetryDestinationWorkspacesInclude? value
    )
    {
        value = this.Value as BetaTelemetryDestinationWorkspacesInclude;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationWorkspacesExclude"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExclude(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationWorkspacesExclude`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExclude(
        [NotNullWhen(true)] out BetaTelemetryDestinationWorkspacesExclude? value
    )
    {
        value = this.Value as BetaTelemetryDestinationWorkspacesExclude;
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
    ///     (BetaTelemetryDestinationWorkspacesAll value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesInclude value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesExclude value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaTelemetryDestinationWorkspacesAll> all,
        Action<BetaTelemetryDestinationWorkspacesInclude> include,
        Action<BetaTelemetryDestinationWorkspacesExclude> exclude
    )
    {
        switch (this.Value)
        {
            case BetaTelemetryDestinationWorkspacesAll value:
                all(value);
                break;
            case BetaTelemetryDestinationWorkspacesInclude value:
                include(value);
                break;
            case BetaTelemetryDestinationWorkspacesExclude value:
                exclude(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTelemetryDestinationWorkspaces"
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
    ///     (BetaTelemetryDestinationWorkspacesAll value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesInclude value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesExclude value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaTelemetryDestinationWorkspacesAll, T> all,
        Func<BetaTelemetryDestinationWorkspacesInclude, T> include,
        Func<BetaTelemetryDestinationWorkspacesExclude, T> exclude
    )
    {
        return this.Value switch
        {
            BetaTelemetryDestinationWorkspacesAll value => all(value),
            BetaTelemetryDestinationWorkspacesInclude value => include(value),
            BetaTelemetryDestinationWorkspacesExclude value => exclude(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTelemetryDestinationWorkspaces"
            ),
        };
    }

    public static implicit operator BetaTelemetryDestinationWorkspaces(
        BetaTelemetryDestinationWorkspacesAll value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationWorkspaces(
        BetaTelemetryDestinationWorkspacesInclude value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationWorkspaces(
        BetaTelemetryDestinationWorkspacesExclude value
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
                "Data did not match any variant of BetaTelemetryDestinationWorkspaces"
            );
        }
        this.Switch(
            (all) => all.Validate(),
            (include) => include.Validate(),
            (exclude) => exclude.Validate()
        );
    }

    public virtual bool Equals(BetaTelemetryDestinationWorkspaces? other) =>
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
            BetaTelemetryDestinationWorkspacesAll _ => 0,
            BetaTelemetryDestinationWorkspacesInclude _ => 1,
            BetaTelemetryDestinationWorkspacesExclude _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaTelemetryDestinationWorkspacesConverter
    : JsonConverter<BetaTelemetryDestinationWorkspaces>
{
    public override BetaTelemetryDestinationWorkspaces? Read(
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
            case "all":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesAll>(
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
            case "include":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesInclude>(
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
            case "exclude":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesExclude>(
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
                return new BetaTelemetryDestinationWorkspaces(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationWorkspaces value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
