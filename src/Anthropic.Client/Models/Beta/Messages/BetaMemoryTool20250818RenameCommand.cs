using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMemoryTool20250818RenameCommand>))]
public sealed record class BetaMemoryTool20250818RenameCommand
    : ModelBase,
        IFromRaw<BetaMemoryTool20250818RenameCommand>
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get
        {
            if (!this.Properties.TryGetValue("command", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'command' cannot be null",
                    new ArgumentOutOfRangeException("command", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["command"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New path for the file or directory
    /// </summary>
    public required string NewPath
    {
        get
        {
            if (!this.Properties.TryGetValue("new_path", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'new_path' cannot be null",
                    new ArgumentOutOfRangeException("new_path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'new_path' cannot be null",
                    new ArgumentNullException("new_path")
                );
        }
        set
        {
            this.Properties["new_path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current path of the file or directory
    /// </summary>
    public required string OldPath
    {
        get
        {
            if (!this.Properties.TryGetValue("old_path", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'old_path' cannot be null",
                    new ArgumentOutOfRangeException("old_path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'old_path' cannot be null",
                    new ArgumentNullException("old_path")
                );
        }
        set
        {
            this.Properties["old_path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Command;
        _ = this.NewPath;
        _ = this.OldPath;
    }

    public BetaMemoryTool20250818RenameCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"rename\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818RenameCommand(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
