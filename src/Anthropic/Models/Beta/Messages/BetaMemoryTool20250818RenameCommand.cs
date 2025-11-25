using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaMemoryTool20250818RenameCommand,
        BetaMemoryTool20250818RenameCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818RenameCommand : ModelBase
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get
        {
            if (!this._rawData.TryGetValue("command", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'command' cannot be null",
                    new ArgumentOutOfRangeException("command", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["command"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("new_path", out JsonElement element))
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
        init
        {
            this._rawData["new_path"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("old_path", out JsonElement element))
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
        init
        {
            this._rawData["old_path"] = JsonSerializer.SerializeToElement(
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
                JsonSerializer.Deserialize<JsonElement>("\"rename\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.NewPath;
        _ = this.OldPath;
    }

    public BetaMemoryTool20250818RenameCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"rename\"");
    }

    public BetaMemoryTool20250818RenameCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"rename\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818RenameCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMemoryTool20250818RenameCommandFromRaw : IFromRaw<BetaMemoryTool20250818RenameCommand>
{
    public BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818RenameCommand.FromRawUnchecked(rawData);
}
