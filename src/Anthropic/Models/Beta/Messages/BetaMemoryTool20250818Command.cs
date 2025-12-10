using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaMemoryTool20250818CommandConverter))]
public record class BetaMemoryTool20250818Command
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Command
    {
        get
        {
            return Match(
                tool20250818View: (x) => x.Command,
                tool20250818Create: (x) => x.Command,
                tool20250818StrReplace: (x) => x.Command,
                tool20250818Insert: (x) => x.Command,
                tool20250818Delete: (x) => x.Command,
                tool20250818Rename: (x) => x.Command
            );
        }
    }

    public string? Path
    {
        get
        {
            return Match<string?>(
                tool20250818View: (x) => x.Path,
                tool20250818Create: (x) => x.Path,
                tool20250818StrReplace: (x) => x.Path,
                tool20250818Insert: (x) => x.Path,
                tool20250818Delete: (x) => x.Path,
                tool20250818Rename: (_) => null
            );
        }
    }

    public BetaMemoryTool20250818Command(
        BetaMemoryTool20250818ViewCommand value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMemoryTool20250818Command(
        BetaMemoryTool20250818CreateCommand value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMemoryTool20250818Command(
        BetaMemoryTool20250818StrReplaceCommand value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMemoryTool20250818Command(
        BetaMemoryTool20250818InsertCommand value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMemoryTool20250818Command(
        BetaMemoryTool20250818DeleteCommand value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMemoryTool20250818Command(
        BetaMemoryTool20250818RenameCommand value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaMemoryTool20250818Command(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818ViewCommand"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool20250818View(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818ViewCommand`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool20250818View(
        [NotNullWhen(true)] out BetaMemoryTool20250818ViewCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818ViewCommand;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818CreateCommand"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool20250818Create(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818CreateCommand`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool20250818Create(
        [NotNullWhen(true)] out BetaMemoryTool20250818CreateCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818CreateCommand;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818StrReplaceCommand"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool20250818StrReplace(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818StrReplaceCommand`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool20250818StrReplace(
        [NotNullWhen(true)] out BetaMemoryTool20250818StrReplaceCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818StrReplaceCommand;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818InsertCommand"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool20250818Insert(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818InsertCommand`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool20250818Insert(
        [NotNullWhen(true)] out BetaMemoryTool20250818InsertCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818InsertCommand;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818DeleteCommand"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool20250818Delete(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818DeleteCommand`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool20250818Delete(
        [NotNullWhen(true)] out BetaMemoryTool20250818DeleteCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818DeleteCommand;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818RenameCommand"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool20250818Rename(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818RenameCommand`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool20250818Rename(
        [NotNullWhen(true)] out BetaMemoryTool20250818RenameCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818RenameCommand;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (BetaMemoryTool20250818ViewCommand value) => {...},
    ///     (BetaMemoryTool20250818CreateCommand value) => {...},
    ///     (BetaMemoryTool20250818StrReplaceCommand value) => {...},
    ///     (BetaMemoryTool20250818InsertCommand value) => {...},
    ///     (BetaMemoryTool20250818DeleteCommand value) => {...},
    ///     (BetaMemoryTool20250818RenameCommand value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaMemoryTool20250818ViewCommand> tool20250818View,
        System::Action<BetaMemoryTool20250818CreateCommand> tool20250818Create,
        System::Action<BetaMemoryTool20250818StrReplaceCommand> tool20250818StrReplace,
        System::Action<BetaMemoryTool20250818InsertCommand> tool20250818Insert,
        System::Action<BetaMemoryTool20250818DeleteCommand> tool20250818Delete,
        System::Action<BetaMemoryTool20250818RenameCommand> tool20250818Rename
    )
    {
        switch (this.Value)
        {
            case BetaMemoryTool20250818ViewCommand value:
                tool20250818View(value);
                break;
            case BetaMemoryTool20250818CreateCommand value:
                tool20250818Create(value);
                break;
            case BetaMemoryTool20250818StrReplaceCommand value:
                tool20250818StrReplace(value);
                break;
            case BetaMemoryTool20250818InsertCommand value:
                tool20250818Insert(value);
                break;
            case BetaMemoryTool20250818DeleteCommand value:
                tool20250818Delete(value);
                break;
            case BetaMemoryTool20250818RenameCommand value:
                tool20250818Rename(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaMemoryTool20250818Command"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (BetaMemoryTool20250818ViewCommand value) => {...},
    ///     (BetaMemoryTool20250818CreateCommand value) => {...},
    ///     (BetaMemoryTool20250818StrReplaceCommand value) => {...},
    ///     (BetaMemoryTool20250818InsertCommand value) => {...},
    ///     (BetaMemoryTool20250818DeleteCommand value) => {...},
    ///     (BetaMemoryTool20250818RenameCommand value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaMemoryTool20250818ViewCommand, T> tool20250818View,
        System::Func<BetaMemoryTool20250818CreateCommand, T> tool20250818Create,
        System::Func<BetaMemoryTool20250818StrReplaceCommand, T> tool20250818StrReplace,
        System::Func<BetaMemoryTool20250818InsertCommand, T> tool20250818Insert,
        System::Func<BetaMemoryTool20250818DeleteCommand, T> tool20250818Delete,
        System::Func<BetaMemoryTool20250818RenameCommand, T> tool20250818Rename
    )
    {
        return this.Value switch
        {
            BetaMemoryTool20250818ViewCommand value => tool20250818View(value),
            BetaMemoryTool20250818CreateCommand value => tool20250818Create(value),
            BetaMemoryTool20250818StrReplaceCommand value => tool20250818StrReplace(value),
            BetaMemoryTool20250818InsertCommand value => tool20250818Insert(value),
            BetaMemoryTool20250818DeleteCommand value => tool20250818Delete(value),
            BetaMemoryTool20250818RenameCommand value => tool20250818Rename(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMemoryTool20250818Command"
            ),
        };
    }

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818ViewCommand value
    ) => new(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818CreateCommand value
    ) => new(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818StrReplaceCommand value
    ) => new(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818InsertCommand value
    ) => new(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818DeleteCommand value
    ) => new(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818RenameCommand value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMemoryTool20250818Command"
            );
        }
        this.Switch(
            (tool20250818View) => tool20250818View.Validate(),
            (tool20250818Create) => tool20250818Create.Validate(),
            (tool20250818StrReplace) => tool20250818StrReplace.Validate(),
            (tool20250818Insert) => tool20250818Insert.Validate(),
            (tool20250818Delete) => tool20250818Delete.Validate(),
            (tool20250818Rename) => tool20250818Rename.Validate()
        );
    }

    public virtual bool Equals(BetaMemoryTool20250818Command? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaMemoryTool20250818CommandConverter : JsonConverter<BetaMemoryTool20250818Command>
{
    public override BetaMemoryTool20250818Command? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? command;
        try
        {
            command = json.GetProperty("command").GetString();
        }
        catch
        {
            command = null;
        }

        switch (command)
        {
            case "view":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818ViewCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "create":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818CreateCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "str_replace":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818StrReplaceCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "insert":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818InsertCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "delete":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818DeleteCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "rename":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818RenameCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new BetaMemoryTool20250818Command(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMemoryTool20250818Command value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
