using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMemoryTool20250818InsertCommand>))]
public sealed record class BetaMemoryTool20250818InsertCommand
    : ModelBase,
        IFromRaw<BetaMemoryTool20250818InsertCommand>
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get
        {
            if (!this._properties.TryGetValue("command", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'command' cannot be null",
                    new ArgumentOutOfRangeException("command", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["command"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Line number where text should be inserted
    /// </summary>
    public required long InsertLine
    {
        get
        {
            if (!this._properties.TryGetValue("insert_line", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'insert_line' cannot be null",
                    new ArgumentOutOfRangeException("insert_line", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["insert_line"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Text to insert at the specified line
    /// </summary>
    public required string InsertText
    {
        get
        {
            if (!this._properties.TryGetValue("insert_text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'insert_text' cannot be null",
                    new ArgumentOutOfRangeException("insert_text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'insert_text' cannot be null",
                    new ArgumentNullException("insert_text")
                );
        }
        init
        {
            this._properties["insert_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Path to the file where text should be inserted
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this._properties.TryGetValue("path", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'path' cannot be null",
                    new ArgumentOutOfRangeException("path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'path' cannot be null",
                    new ArgumentNullException("path")
                );
        }
        init
        {
            this._properties["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Command,
                JsonSerializer.Deserialize<JsonElement>("\"insert\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.InsertLine;
        _ = this.InsertText;
        _ = this.Path;
    }

    public BetaMemoryTool20250818InsertCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"insert\"");
    }

    public BetaMemoryTool20250818InsertCommand(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"insert\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818InsertCommand(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818InsertCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
