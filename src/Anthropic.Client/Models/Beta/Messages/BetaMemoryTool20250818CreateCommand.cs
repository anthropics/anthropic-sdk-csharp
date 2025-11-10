using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMemoryTool20250818CreateCommand>))]
public sealed record class BetaMemoryTool20250818CreateCommand
    : ModelBase,
        IFromRaw<BetaMemoryTool20250818CreateCommand>
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
    /// Content to write to the file
    /// </summary>
    public required string FileText
    {
        get
        {
            if (!this._properties.TryGetValue("file_text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'file_text' cannot be null",
                    new ArgumentOutOfRangeException("file_text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'file_text' cannot be null",
                    new ArgumentNullException("file_text")
                );
        }
        init
        {
            this._properties["file_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Path where the file should be created
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
                JsonSerializer.Deserialize<JsonElement>("\"create\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.FileText;
        _ = this.Path;
    }

    public BetaMemoryTool20250818CreateCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"create\"");
    }

    public BetaMemoryTool20250818CreateCommand(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"create\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818CreateCommand(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818CreateCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
