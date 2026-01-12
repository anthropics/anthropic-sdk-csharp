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
        BetaMemoryTool20250818StrReplaceCommand,
        BetaMemoryTool20250818StrReplaceCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818StrReplaceCommand : JsonModel
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
    /// Text to replace with
    /// </summary>
    public required string NewStr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("new_str");
        }
        init { this._rawData.Set("new_str", value); }
    }

    /// <summary>
    /// Text to search for and replace
    /// </summary>
    public required string OldStr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("old_str");
        }
        init { this._rawData.Set("old_str", value); }
    }

    /// <summary>
    /// Path to the file where text should be replaced
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Command,
                JsonSerializer.Deserialize<JsonElement>("\"str_replace\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.NewStr;
        _ = this.OldStr;
        _ = this.Path;
    }

    public BetaMemoryTool20250818StrReplaceCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"str_replace\"");
    }

    public BetaMemoryTool20250818StrReplaceCommand(
        BetaMemoryTool20250818StrReplaceCommand betaMemoryTool20250818StrReplaceCommand
    )
        : base(betaMemoryTool20250818StrReplaceCommand) { }

    public BetaMemoryTool20250818StrReplaceCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"str_replace\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818StrReplaceCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMemoryTool20250818StrReplaceCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818StrReplaceCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMemoryTool20250818StrReplaceCommandFromRaw
    : IFromRawJson<BetaMemoryTool20250818StrReplaceCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818StrReplaceCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818StrReplaceCommand.FromRawUnchecked(rawData);
}
