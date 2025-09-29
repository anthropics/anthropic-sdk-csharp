using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaMemoryTool20250818CommandVariants = Anthropic.Client.Models.Beta.Messages.BetaMemoryTool20250818CommandVariants;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaMemoryTool20250818CommandConverter))]
public abstract record class BetaMemoryTool20250818Command
{
    internal BetaMemoryTool20250818Command() { }

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818ViewCommand value
    ) => new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818CreateCommand value
    ) => new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818StrReplaceCommand value
    ) => new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818InsertCommand value
    ) => new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818DeleteCommand value
    ) => new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand(value);

    public static implicit operator BetaMemoryTool20250818Command(
        BetaMemoryTool20250818RenameCommand value
    ) => new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand(value);

    public bool TryPickTool20250818View(
        [NotNullWhen(true)] out BetaMemoryTool20250818ViewCommand? value
    )
    {
        value = (
            this as BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand
        )?.Value;
        return value != null;
    }

    public bool TryPickTool20250818Create(
        [NotNullWhen(true)] out BetaMemoryTool20250818CreateCommand? value
    )
    {
        value = (
            this as BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand
        )?.Value;
        return value != null;
    }

    public bool TryPickTool20250818StrReplace(
        [NotNullWhen(true)] out BetaMemoryTool20250818StrReplaceCommand? value
    )
    {
        value = (
            this as BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand
        )?.Value;
        return value != null;
    }

    public bool TryPickTool20250818Insert(
        [NotNullWhen(true)] out BetaMemoryTool20250818InsertCommand? value
    )
    {
        value = (
            this as BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand
        )?.Value;
        return value != null;
    }

    public bool TryPickTool20250818Delete(
        [NotNullWhen(true)] out BetaMemoryTool20250818DeleteCommand? value
    )
    {
        value = (
            this as BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand
        )?.Value;
        return value != null;
    }

    public bool TryPickTool20250818Rename(
        [NotNullWhen(true)] out BetaMemoryTool20250818RenameCommand? value
    )
    {
        value = (
            this as BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand> tool20250818View,
        Action<BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand> tool20250818Create,
        Action<BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand> tool20250818StrReplace,
        Action<BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand> tool20250818Insert,
        Action<BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand> tool20250818Delete,
        Action<BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand> tool20250818Rename
    )
    {
        switch (this)
        {
            case BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand inner:
                tool20250818View(inner);
                break;
            case BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand inner:
                tool20250818Create(inner);
                break;
            case BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand inner:
                tool20250818StrReplace(inner);
                break;
            case BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand inner:
                tool20250818Insert(inner);
                break;
            case BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand inner:
                tool20250818Delete(inner);
                break;
            case BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand inner:
                tool20250818Rename(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand,
            T
        > tool20250818View,
        Func<
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand,
            T
        > tool20250818Create,
        Func<
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand,
            T
        > tool20250818StrReplace,
        Func<
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand,
            T
        > tool20250818Insert,
        Func<
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand,
            T
        > tool20250818Delete,
        Func<
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand,
            T
        > tool20250818Rename
    )
    {
        return this switch
        {
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand inner =>
                tool20250818View(inner),
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand inner =>
                tool20250818Create(inner),
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand inner =>
                tool20250818StrReplace(inner),
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand inner =>
                tool20250818Insert(inner),
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand inner =>
                tool20250818Delete(inner),
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand inner =>
                tool20250818Rename(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaMemoryTool20250818CommandConverter : JsonConverter<BetaMemoryTool20250818Command>
{
    public override BetaMemoryTool20250818Command? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818ViewCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "create":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818CreateCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "str_replace":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818StrReplaceCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "insert":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818InsertCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "delete":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818DeleteCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "rename":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaMemoryTool20250818RenameCommand>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMemoryTool20250818Command value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818ViewCommand(
                var tool20250818View
            ) => tool20250818View,
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818CreateCommand(
                var tool20250818Create
            ) => tool20250818Create,
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818StrReplaceCommand(
                var tool20250818StrReplace
            ) => tool20250818StrReplace,
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818InsertCommand(
                var tool20250818Insert
            ) => tool20250818Insert,
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818DeleteCommand(
                var tool20250818Delete
            ) => tool20250818Delete,
            BetaMemoryTool20250818CommandVariants::BetaMemoryTool20250818RenameCommand(
                var tool20250818Rename
            ) => tool20250818Rename,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
