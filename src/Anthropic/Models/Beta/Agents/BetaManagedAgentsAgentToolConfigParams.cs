using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Configuration override for a specific tool within a toolset.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentToolConfigParamsConverter))]
public record class BetaManagedAgentsAgentToolConfigParams : ModelBase
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

    public JsonElement Name
    {
        get
        {
            return Match(
                bash: (x) => x.Name,
                edit: (x) => x.Name,
                read: (x) => x.Name,
                write: (x) => x.Name,
                glob: (x) => x.Name,
                grep: (x) => x.Name,
                webFetch: (x) => x.Name,
                webSearch: (x) => x.Name
            );
        }
    }

    public bool? Enabled
    {
        get
        {
            return Match<bool?>(
                bash: (x) => x.Enabled,
                edit: (x) => x.Enabled,
                read: (x) => x.Enabled,
                write: (x) => x.Enabled,
                glob: (x) => x.Enabled,
                grep: (x) => x.Enabled,
                webFetch: (x) => x.Enabled,
                webSearch: (x) => x.Enabled
            );
        }
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsBashToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsEditToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsReadToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsWriteToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsGlobToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsGrepToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsWebFetchToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsWebSearchToolConfigParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfigParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsBashToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBash(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsBashToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBash([NotNullWhen(true)] out BetaManagedAgentsBashToolConfigParams? value)
    {
        value = this.Value as BetaManagedAgentsBashToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEditToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEdit(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEditToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEdit([NotNullWhen(true)] out BetaManagedAgentsEditToolConfigParams? value)
    {
        value = this.Value as BetaManagedAgentsEditToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsReadToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRead(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsReadToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRead([NotNullWhen(true)] out BetaManagedAgentsReadToolConfigParams? value)
    {
        value = this.Value as BetaManagedAgentsReadToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWriteToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWrite(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWriteToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWrite([NotNullWhen(true)] out BetaManagedAgentsWriteToolConfigParams? value)
    {
        value = this.Value as BetaManagedAgentsWriteToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGlobToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGlob(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGlobToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGlob([NotNullWhen(true)] out BetaManagedAgentsGlobToolConfigParams? value)
    {
        value = this.Value as BetaManagedAgentsGlobToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGrepToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGrep(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGrepToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGrep([NotNullWhen(true)] out BetaManagedAgentsGrepToolConfigParams? value)
    {
        value = this.Value as BetaManagedAgentsGrepToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetch(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetch(
        [NotNullWhen(true)] out BetaManagedAgentsWebFetchToolConfigParams? value
    )
    {
        value = this.Value as BetaManagedAgentsWebFetchToolConfigParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebSearchToolConfigParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearch(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebSearchToolConfigParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearch(
        [NotNullWhen(true)] out BetaManagedAgentsWebSearchToolConfigParams? value
    )
    {
        value = this.Value as BetaManagedAgentsWebSearchToolConfigParams;
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
    ///     (BetaManagedAgentsBashToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsEditToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsReadToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsWriteToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsGlobToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsGrepToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsWebSearchToolConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsBashToolConfigParams> bash,
        System::Action<BetaManagedAgentsEditToolConfigParams> edit,
        System::Action<BetaManagedAgentsReadToolConfigParams> read,
        System::Action<BetaManagedAgentsWriteToolConfigParams> write,
        System::Action<BetaManagedAgentsGlobToolConfigParams> glob,
        System::Action<BetaManagedAgentsGrepToolConfigParams> grep,
        System::Action<BetaManagedAgentsWebFetchToolConfigParams> webFetch,
        System::Action<BetaManagedAgentsWebSearchToolConfigParams> webSearch
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsBashToolConfigParams value:
                bash(value);
                break;
            case BetaManagedAgentsEditToolConfigParams value:
                edit(value);
                break;
            case BetaManagedAgentsReadToolConfigParams value:
                read(value);
                break;
            case BetaManagedAgentsWriteToolConfigParams value:
                write(value);
                break;
            case BetaManagedAgentsGlobToolConfigParams value:
                glob(value);
                break;
            case BetaManagedAgentsGrepToolConfigParams value:
                grep(value);
                break;
            case BetaManagedAgentsWebFetchToolConfigParams value:
                webFetch(value);
                break;
            case BetaManagedAgentsWebSearchToolConfigParams value:
                webSearch(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentToolConfigParams"
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
    ///     (BetaManagedAgentsBashToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsEditToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsReadToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsWriteToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsGlobToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsGrepToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchToolConfigParams value) =&gt; {...},
    ///     (BetaManagedAgentsWebSearchToolConfigParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsBashToolConfigParams, T> bash,
        System::Func<BetaManagedAgentsEditToolConfigParams, T> edit,
        System::Func<BetaManagedAgentsReadToolConfigParams, T> read,
        System::Func<BetaManagedAgentsWriteToolConfigParams, T> write,
        System::Func<BetaManagedAgentsGlobToolConfigParams, T> glob,
        System::Func<BetaManagedAgentsGrepToolConfigParams, T> grep,
        System::Func<BetaManagedAgentsWebFetchToolConfigParams, T> webFetch,
        System::Func<BetaManagedAgentsWebSearchToolConfigParams, T> webSearch
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsBashToolConfigParams value => bash(value),
            BetaManagedAgentsEditToolConfigParams value => edit(value),
            BetaManagedAgentsReadToolConfigParams value => read(value),
            BetaManagedAgentsWriteToolConfigParams value => write(value),
            BetaManagedAgentsGlobToolConfigParams value => glob(value),
            BetaManagedAgentsGrepToolConfigParams value => grep(value),
            BetaManagedAgentsWebFetchToolConfigParams value => webFetch(value),
            BetaManagedAgentsWebSearchToolConfigParams value => webSearch(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentToolConfigParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsBashToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsEditToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsReadToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsWriteToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsGlobToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsGrepToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsWebFetchToolConfigParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfigParams(
        BetaManagedAgentsWebSearchToolConfigParams value
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
                "Data did not match any variant of BetaManagedAgentsAgentToolConfigParams"
            );
        }
        this.Switch(
            (bash) => bash.Validate(),
            (edit) => edit.Validate(),
            (read) => read.Validate(),
            (write) => write.Validate(),
            (glob) => glob.Validate(),
            (grep) => grep.Validate(),
            (webFetch) => webFetch.Validate(),
            (webSearch) => webSearch.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsAgentToolConfigParams? other) =>
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
            BetaManagedAgentsBashToolConfigParams _ => 0,
            BetaManagedAgentsEditToolConfigParams _ => 1,
            BetaManagedAgentsReadToolConfigParams _ => 2,
            BetaManagedAgentsWriteToolConfigParams _ => 3,
            BetaManagedAgentsGlobToolConfigParams _ => 4,
            BetaManagedAgentsGrepToolConfigParams _ => 5,
            BetaManagedAgentsWebFetchToolConfigParams _ => 6,
            BetaManagedAgentsWebSearchToolConfigParams _ => 7,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentToolConfigParamsConverter
    : JsonConverter<BetaManagedAgentsAgentToolConfigParams>
{
    public override BetaManagedAgentsAgentToolConfigParams? Read(
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
            case "bash":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsBashToolConfigParams>(
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
            case "edit":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfigParams>(
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
            case "read":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsReadToolConfigParams>(
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
            case "write":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfigParams>(
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
            case "glob":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsGlobToolConfigParams>(
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
            case "grep":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfigParams>(
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
            case "web_fetch":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfigParams>(
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
            case "web_search":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfigParams>(
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
                return new BetaManagedAgentsAgentToolConfigParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolConfigParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
