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
        BetaMemoryTool20250818DeleteCommand,
        BetaMemoryTool20250818DeleteCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818DeleteCommand : JsonModel
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
    /// Path to the file or directory to delete
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
                JsonSerializer.Deserialize<JsonElement>("\"delete\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Path;
    }

    public BetaMemoryTool20250818DeleteCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
    }

    public BetaMemoryTool20250818DeleteCommand(
        BetaMemoryTool20250818DeleteCommand betaMemoryTool20250818DeleteCommand
    )
        : base(betaMemoryTool20250818DeleteCommand) { }

    public BetaMemoryTool20250818DeleteCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818DeleteCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMemoryTool20250818DeleteCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818DeleteCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMemoryTool20250818DeleteCommand(string path)
        : this()
    {
        this.Path = path;
    }
}

class BetaMemoryTool20250818DeleteCommandFromRaw : IFromRawJson<BetaMemoryTool20250818DeleteCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818DeleteCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818DeleteCommand.FromRawUnchecked(rawData);
}
