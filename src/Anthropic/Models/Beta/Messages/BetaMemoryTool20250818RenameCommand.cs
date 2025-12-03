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
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "command"); }
        init { ModelBase.Set(this._rawData, "command", value); }
    }

    /// <summary>
    /// New path for the file or directory
    /// </summary>
    public required string NewPath
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "new_path"); }
        init { ModelBase.Set(this._rawData, "new_path", value); }
    }

    /// <summary>
    /// Current path of the file or directory
    /// </summary>
    public required string OldPath
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "old_path"); }
        init { ModelBase.Set(this._rawData, "old_path", value); }
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

    /// <inheritdoc cref="BetaMemoryTool20250818RenameCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMemoryTool20250818RenameCommandFromRaw : IFromRaw<BetaMemoryTool20250818RenameCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818RenameCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818RenameCommand.FromRawUnchecked(rawData);
}
