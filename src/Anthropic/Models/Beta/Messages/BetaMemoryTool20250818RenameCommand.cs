using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaMemoryTool20250818RenameCommand,
        BetaMemoryTool20250818RenameCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818RenameCommand : JsonModel
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("command");
        }
        init { this._rawData.Set("command", value); }
    }

    /// <summary>
    /// New path for the file or directory
    /// </summary>
    public required string NewPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("new_path");
        }
        init { this._rawData.Set("new_path", value); }
    }

    /// <summary>
    /// Current path of the file or directory
    /// </summary>
    public required string OldPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("old_path");
        }
        init { this._rawData.Set("old_path", value); }
    }

    /// <inheritdoc/>
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

    public BetaMemoryTool20250818RenameCommand(
        BetaMemoryTool20250818RenameCommand betaMemoryTool20250818RenameCommand
    )
        : base(betaMemoryTool20250818RenameCommand) { }

    public BetaMemoryTool20250818RenameCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"rename\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818RenameCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMemoryTool20250818RenameCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMemoryTool20250818RenameCommandFromRaw : IFromRawJson<BetaMemoryTool20250818RenameCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818RenameCommand.FromRawUnchecked(rawData);
}
