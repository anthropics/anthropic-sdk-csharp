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
        BetaMemoryTool20250818InsertCommand,
        BetaMemoryTool20250818InsertCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818InsertCommand : ModelBase
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "command"); }
        init { ModelBase.Set(this._rawData, "command", value); }
    }

    /// <summary>
    /// Line number where text should be inserted
    /// </summary>
    public required long InsertLine
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "insert_line"); }
        init { ModelBase.Set(this._rawData, "insert_line", value); }
    }

    /// <summary>
    /// Text to insert at the specified line
    /// </summary>
    public required string InsertText
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "insert_text"); }
        init { ModelBase.Set(this._rawData, "insert_text", value); }
    }

    /// <summary>
    /// Path to the file where text should be inserted
    /// </summary>
    public required string Path
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "path"); }
        init { ModelBase.Set(this._rawData, "path", value); }
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

    public BetaMemoryTool20250818InsertCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"insert\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818InsertCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaMemoryTool20250818InsertCommandFromRaw : IFromRaw<BetaMemoryTool20250818InsertCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818InsertCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818InsertCommand.FromRawUnchecked(rawData);
}
