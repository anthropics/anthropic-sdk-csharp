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
        BetaMemoryTool20250818CreateCommand,
        BetaMemoryTool20250818CreateCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818CreateCommand : JsonModel
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "command"); }
        init { JsonModel.Set(this._rawData, "command", value); }
    }

    /// <summary>
    /// Content to write to the file
    /// </summary>
    public required string FileText
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "file_text"); }
        init { JsonModel.Set(this._rawData, "file_text", value); }
    }

    /// <summary>
    /// Path where the file should be created
    /// </summary>
    public required string Path
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "path"); }
        init { JsonModel.Set(this._rawData, "path", value); }
    }

    /// <inheritdoc/>
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

    public BetaMemoryTool20250818CreateCommand(
        BetaMemoryTool20250818CreateCommand betaMemoryTool20250818CreateCommand
    )
        : base(betaMemoryTool20250818CreateCommand) { }

    public BetaMemoryTool20250818CreateCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"create\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818CreateCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMemoryTool20250818CreateCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818CreateCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMemoryTool20250818CreateCommandFromRaw : IFromRawJson<BetaMemoryTool20250818CreateCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818CreateCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818CreateCommand.FromRawUnchecked(rawData);
}
