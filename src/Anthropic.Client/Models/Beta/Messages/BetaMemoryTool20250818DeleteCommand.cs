using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMemoryTool20250818DeleteCommand>))]
public sealed record class BetaMemoryTool20250818DeleteCommand
    : ModelBase,
        IFromRaw<BetaMemoryTool20250818DeleteCommand>
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
                    new System::ArgumentOutOfRangeException("command", "Missing required argument")
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
    /// Path to the file or directory to delete
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this._properties.TryGetValue("path", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'path' cannot be null",
                    new System::ArgumentOutOfRangeException("path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'path' cannot be null",
                    new System::ArgumentNullException("path")
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
        _ = this.Command;
        _ = this.Path;
    }

    public BetaMemoryTool20250818DeleteCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
    }

    public BetaMemoryTool20250818DeleteCommand(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818DeleteCommand(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818DeleteCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaMemoryTool20250818DeleteCommand(string path)
        : this()
    {
        this.Path = path;
    }
}
