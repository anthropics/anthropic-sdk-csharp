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
        BetaMemoryTool20250818InsertCommand,
        BetaMemoryTool20250818InsertCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818InsertCommand : JsonModel
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("command"); }
        init { this._rawData.Set("command", value); }
    }

    /// <summary>
    /// Line number where text should be inserted
    /// </summary>
    public required long InsertLine
    {
        get { return this._rawData.GetNotNullStruct<long>("insert_line"); }
        init { this._rawData.Set("insert_line", value); }
    }

    /// <summary>
    /// Text to insert at the specified line
    /// </summary>
    public required string InsertText
    {
        get { return this._rawData.GetNotNullClass<string>("insert_text"); }
        init { this._rawData.Set("insert_text", value); }
    }

    /// <summary>
    /// Path to the file where text should be inserted
    /// </summary>
    public required string Path
    {
        get { return this._rawData.GetNotNullClass<string>("path"); }
        init { this._rawData.Set("path", value); }
    }

    /// <inheritdoc/>
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

    public BetaMemoryTool20250818InsertCommand(
        BetaMemoryTool20250818InsertCommand betaMemoryTool20250818InsertCommand
    )
        : base(betaMemoryTool20250818InsertCommand) { }

    public BetaMemoryTool20250818InsertCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"insert\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818InsertCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMemoryTool20250818InsertCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818InsertCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMemoryTool20250818InsertCommandFromRaw : IFromRawJson<BetaMemoryTool20250818InsertCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818InsertCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818InsertCommand.FromRawUnchecked(rawData);
}
