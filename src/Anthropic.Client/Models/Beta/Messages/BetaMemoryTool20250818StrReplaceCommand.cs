using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMemoryTool20250818StrReplaceCommand>))]
public sealed record class BetaMemoryTool20250818StrReplaceCommand
    : ModelBase,
        IFromRaw<BetaMemoryTool20250818StrReplaceCommand>
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
    /// Text to replace with
    /// </summary>
    public required string NewStr
    {
        get
        {
            if (!this.Properties.TryGetValue("new_str", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'new_str' cannot be null",
                    new ArgumentOutOfRangeException("new_str", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'new_str' cannot be null",
                    new ArgumentNullException("new_str")
                );
        }
        set
        {
            this.Properties["new_str"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Text to search for and replace
    /// </summary>
    public required string OldStr
    {
        get
        {
            if (!this.Properties.TryGetValue("old_str", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'old_str' cannot be null",
                    new ArgumentOutOfRangeException("old_str", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'old_str' cannot be null",
                    new ArgumentNullException("old_str")
                );
        }
        set
        {
            this.Properties["old_str"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Path to the file where text should be replaced
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this.Properties.TryGetValue("path", out JsonElement element))
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
        set
        {
            this.Properties["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.NewStr;
        _ = this.OldStr;
        _ = this.Path;
    }

    public BetaMemoryTool20250818StrReplaceCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"str_replace\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818StrReplaceCommand(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818StrReplaceCommand FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
