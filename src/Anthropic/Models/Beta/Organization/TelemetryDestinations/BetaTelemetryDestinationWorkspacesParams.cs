using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Which of the organization's workspaces a telemetry destination covers, as a create
/// or update request sets it.
/// </summary>
[JsonConverter(typeof(BetaTelemetryDestinationWorkspacesParamsConverter))]
public record class BetaTelemetryDestinationWorkspacesParams : ModelBase
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

    public ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaTelemetryDestinationWorkspacesAllParams _ =>
                    BetaTelemetryDestinationWorkspacesParamsType.All,
                BetaTelemetryDestinationWorkspacesIncludeParams _ =>
                    BetaTelemetryDestinationWorkspacesParamsType.Include,
                BetaTelemetryDestinationWorkspacesExcludeParams _ =>
                    BetaTelemetryDestinationWorkspacesParamsType.Exclude,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType>
                >(this.Json, "type"),
            };
        }
    }

    public IReadOnlyList<string>? WorkspaceIds
    {
        get
        {
            return this.Value switch
            {
                BetaTelemetryDestinationWorkspacesAllParams _ => null,
                BetaTelemetryDestinationWorkspacesIncludeParams x => x.WorkspaceIds,
                BetaTelemetryDestinationWorkspacesExcludeParams x => x.WorkspaceIds,
                _ => WrappedJsonSerializer.GetNullableClassProperty<IReadOnlyList<string>>(
                    this.Json,
                    "workspace_ids"
                ),
            };
        }
    }

    public BetaTelemetryDestinationWorkspacesParams(
        BetaTelemetryDestinationWorkspacesAllParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationWorkspacesParams(
        BetaTelemetryDestinationWorkspacesIncludeParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationWorkspacesParams(
        BetaTelemetryDestinationWorkspacesExcludeParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationWorkspacesParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationWorkspacesAllParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAll(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationWorkspacesAllParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAll(
        [NotNullWhen(true)] out BetaTelemetryDestinationWorkspacesAllParams? value
    )
    {
        value = this.Value as BetaTelemetryDestinationWorkspacesAllParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationWorkspacesIncludeParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInclude(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationWorkspacesIncludeParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInclude(
        [NotNullWhen(true)] out BetaTelemetryDestinationWorkspacesIncludeParams? value
    )
    {
        value = this.Value as BetaTelemetryDestinationWorkspacesIncludeParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationWorkspacesExcludeParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExclude(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationWorkspacesExcludeParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExclude(
        [NotNullWhen(true)] out BetaTelemetryDestinationWorkspacesExcludeParams? value
    )
    {
        value = this.Value as BetaTelemetryDestinationWorkspacesExcludeParams;
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
    ///     (BetaTelemetryDestinationWorkspacesAllParams value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesIncludeParams value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesExcludeParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaTelemetryDestinationWorkspacesAllParams> all,
        Action<BetaTelemetryDestinationWorkspacesIncludeParams> include,
        Action<BetaTelemetryDestinationWorkspacesExcludeParams> exclude
    )
    {
        switch (this.Value)
        {
            case BetaTelemetryDestinationWorkspacesAllParams value:
                all(value);
                break;
            case BetaTelemetryDestinationWorkspacesIncludeParams value:
                include(value);
                break;
            case BetaTelemetryDestinationWorkspacesExcludeParams value:
                exclude(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTelemetryDestinationWorkspacesParams"
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
    ///     (BetaTelemetryDestinationWorkspacesAllParams value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesIncludeParams value) =&gt; {...},
    ///     (BetaTelemetryDestinationWorkspacesExcludeParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaTelemetryDestinationWorkspacesAllParams, T> all,
        Func<BetaTelemetryDestinationWorkspacesIncludeParams, T> include,
        Func<BetaTelemetryDestinationWorkspacesExcludeParams, T> exclude
    )
    {
        return this.Value switch
        {
            BetaTelemetryDestinationWorkspacesAllParams value => all(value),
            BetaTelemetryDestinationWorkspacesIncludeParams value => include(value),
            BetaTelemetryDestinationWorkspacesExcludeParams value => exclude(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTelemetryDestinationWorkspacesParams"
            ),
        };
    }

    public static implicit operator BetaTelemetryDestinationWorkspacesParams(
        BetaTelemetryDestinationWorkspacesAllParams value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationWorkspacesParams(
        BetaTelemetryDestinationWorkspacesIncludeParams value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationWorkspacesParams(
        BetaTelemetryDestinationWorkspacesExcludeParams value
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
                "Data did not match any variant of BetaTelemetryDestinationWorkspacesParams"
            );
        }
        this.Switch(
            (all) => all.Validate(),
            (include) => include.Validate(),
            (exclude) => exclude.Validate()
        );
    }

    public virtual bool Equals(BetaTelemetryDestinationWorkspacesParams? other) =>
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
            BetaTelemetryDestinationWorkspacesAllParams _ => 0,
            BetaTelemetryDestinationWorkspacesIncludeParams _ => 1,
            BetaTelemetryDestinationWorkspacesExcludeParams _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaTelemetryDestinationWorkspacesParamsConverter
    : JsonConverter<BetaTelemetryDestinationWorkspacesParams>
{
    public override BetaTelemetryDestinationWorkspacesParams? Read(
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
                        JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesAllParams>(
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
                        JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesIncludeParams>(
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
                        JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesExcludeParams>(
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
                return new BetaTelemetryDestinationWorkspacesParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationWorkspacesParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaTelemetryDestinationWorkspacesParamsTypeConverter))]
public enum BetaTelemetryDestinationWorkspacesParamsType
{
    All,
    Include,
    Exclude,
}

sealed class BetaTelemetryDestinationWorkspacesParamsTypeConverter
    : JsonConverter<BetaTelemetryDestinationWorkspacesParamsType>
{
    public override BetaTelemetryDestinationWorkspacesParamsType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => BetaTelemetryDestinationWorkspacesParamsType.All,
            "include" => BetaTelemetryDestinationWorkspacesParamsType.Include,
            "exclude" => BetaTelemetryDestinationWorkspacesParamsType.Exclude,
            _ => (BetaTelemetryDestinationWorkspacesParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationWorkspacesParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTelemetryDestinationWorkspacesParamsType.All => "all",
                BetaTelemetryDestinationWorkspacesParamsType.Include => "include",
                BetaTelemetryDestinationWorkspacesParamsType.Exclude => "exclude",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
