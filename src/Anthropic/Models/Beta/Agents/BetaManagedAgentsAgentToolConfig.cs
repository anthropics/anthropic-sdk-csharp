using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Configuration for a specific agent tool.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentToolConfigConverter))]
public record class BetaManagedAgentsAgentToolConfig : ModelBase
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

    public bool Enabled
    {
        get
        {
            return Match(
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

    public JsonElement Type
    {
        get
        {
            return Match(
                bash: (x) => x.Type,
                edit: (x) => x.Type,
                read: (x) => x.Type,
                write: (x) => x.Type,
                glob: (x) => x.Type,
                grep: (x) => x.Type,
                webFetch: (x) => x.Type,
                webSearch: (x) => x.Type
            );
        }
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsBashToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsEditToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsReadToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsWriteToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsGlobToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsGrepToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsWebFetchToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsWebSearchToolConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsBashToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBash(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsBashToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBash([NotNullWhen(true)] out BetaManagedAgentsBashToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsBashToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsEditToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEdit(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsEditToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEdit([NotNullWhen(true)] out BetaManagedAgentsEditToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsEditToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsReadToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRead(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsReadToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRead([NotNullWhen(true)] out BetaManagedAgentsReadToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsReadToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWriteToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWrite(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWriteToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWrite([NotNullWhen(true)] out BetaManagedAgentsWriteToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsWriteToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGlobToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGlob(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGlobToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGlob([NotNullWhen(true)] out BetaManagedAgentsGlobToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsGlobToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGrepToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGrep(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGrepToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGrep([NotNullWhen(true)] out BetaManagedAgentsGrepToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsGrepToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetch(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetch([NotNullWhen(true)] out BetaManagedAgentsWebFetchToolConfig? value)
    {
        value = this.Value as BetaManagedAgentsWebFetchToolConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebSearchToolConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearch(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebSearchToolConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearch(
        [NotNullWhen(true)] out BetaManagedAgentsWebSearchToolConfig? value
    )
    {
        value = this.Value as BetaManagedAgentsWebSearchToolConfig;
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
    ///     (BetaManagedAgentsBashToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsEditToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsReadToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsWriteToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsGlobToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsGrepToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsWebSearchToolConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsBashToolConfig> bash,
        System::Action<BetaManagedAgentsEditToolConfig> edit,
        System::Action<BetaManagedAgentsReadToolConfig> read,
        System::Action<BetaManagedAgentsWriteToolConfig> write,
        System::Action<BetaManagedAgentsGlobToolConfig> glob,
        System::Action<BetaManagedAgentsGrepToolConfig> grep,
        System::Action<BetaManagedAgentsWebFetchToolConfig> webFetch,
        System::Action<BetaManagedAgentsWebSearchToolConfig> webSearch
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsBashToolConfig value:
                bash(value);
                break;
            case BetaManagedAgentsEditToolConfig value:
                edit(value);
                break;
            case BetaManagedAgentsReadToolConfig value:
                read(value);
                break;
            case BetaManagedAgentsWriteToolConfig value:
                write(value);
                break;
            case BetaManagedAgentsGlobToolConfig value:
                glob(value);
                break;
            case BetaManagedAgentsGrepToolConfig value:
                grep(value);
                break;
            case BetaManagedAgentsWebFetchToolConfig value:
                webFetch(value);
                break;
            case BetaManagedAgentsWebSearchToolConfig value:
                webSearch(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentToolConfig"
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
    ///     (BetaManagedAgentsBashToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsEditToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsReadToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsWriteToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsGlobToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsGrepToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchToolConfig value) =&gt; {...},
    ///     (BetaManagedAgentsWebSearchToolConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsBashToolConfig, T> bash,
        System::Func<BetaManagedAgentsEditToolConfig, T> edit,
        System::Func<BetaManagedAgentsReadToolConfig, T> read,
        System::Func<BetaManagedAgentsWriteToolConfig, T> write,
        System::Func<BetaManagedAgentsGlobToolConfig, T> glob,
        System::Func<BetaManagedAgentsGrepToolConfig, T> grep,
        System::Func<BetaManagedAgentsWebFetchToolConfig, T> webFetch,
        System::Func<BetaManagedAgentsWebSearchToolConfig, T> webSearch
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsBashToolConfig value => bash(value),
            BetaManagedAgentsEditToolConfig value => edit(value),
            BetaManagedAgentsReadToolConfig value => read(value),
            BetaManagedAgentsWriteToolConfig value => write(value),
            BetaManagedAgentsGlobToolConfig value => glob(value),
            BetaManagedAgentsGrepToolConfig value => grep(value),
            BetaManagedAgentsWebFetchToolConfig value => webFetch(value),
            BetaManagedAgentsWebSearchToolConfig value => webSearch(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentToolConfig"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsBashToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsEditToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsReadToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsWriteToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsGlobToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsGrepToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsWebFetchToolConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolConfig(
        BetaManagedAgentsWebSearchToolConfig value
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
                "Data did not match any variant of BetaManagedAgentsAgentToolConfig"
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

    public virtual bool Equals(BetaManagedAgentsAgentToolConfig? other) =>
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
            BetaManagedAgentsBashToolConfig _ => 0,
            BetaManagedAgentsEditToolConfig _ => 1,
            BetaManagedAgentsReadToolConfig _ => 2,
            BetaManagedAgentsWriteToolConfig _ => 3,
            BetaManagedAgentsGlobToolConfig _ => 4,
            BetaManagedAgentsGrepToolConfig _ => 5,
            BetaManagedAgentsWebFetchToolConfig _ => 6,
            BetaManagedAgentsWebSearchToolConfig _ => 7,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentToolConfigConverter
    : JsonConverter<BetaManagedAgentsAgentToolConfig>
{
    public override BetaManagedAgentsAgentToolConfig? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBashToolConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsReadToolConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsGlobToolConfig>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfig>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsWebFetchToolConfig>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsWebSearchToolConfig>(
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
                return new BetaManagedAgentsAgentToolConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
