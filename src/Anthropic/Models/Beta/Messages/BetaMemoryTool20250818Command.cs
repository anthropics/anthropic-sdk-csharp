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

    public bool TryPickTool20250818View(
        [NotNullWhen(true)] out BetaMemoryTool20250818ViewCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818ViewCommand;
        return value != null;
    }

    public bool TryPickTool20250818Create(
        [NotNullWhen(true)] out BetaMemoryTool20250818CreateCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818CreateCommand;
        return value != null;
    }

    public bool TryPickTool20250818StrReplace(
        [NotNullWhen(true)] out BetaMemoryTool20250818StrReplaceCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818StrReplaceCommand;
        return value != null;
    }

    public bool TryPickTool20250818Insert(
        [NotNullWhen(true)] out BetaMemoryTool20250818InsertCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818InsertCommand;
        return value != null;
    }

    public bool TryPickTool20250818Delete(
        [NotNullWhen(true)] out BetaMemoryTool20250818DeleteCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818DeleteCommand;
        return value != null;
    }

    public bool TryPickTool20250818Rename(
        [NotNullWhen(true)] out BetaMemoryTool20250818RenameCommand? value
    )
    {
        value = this.Value as BetaMemoryTool20250818RenameCommand;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMemoryTool20250818Command"
            );
        }
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
