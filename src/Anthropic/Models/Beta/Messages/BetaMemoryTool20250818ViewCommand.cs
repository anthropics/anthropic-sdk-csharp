using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaMemoryTool20250818ViewCommand,
        BetaMemoryTool20250818ViewCommandFromRaw
    >)
)]
public sealed record class BetaMemoryTool20250818ViewCommand : JsonModel
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
    /// Path to directory or file to view
    /// </summary>
    public required string Path
    {
        get { return this._rawData.GetNotNullClass<string>("path"); }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// Optional line range for viewing specific lines
    /// </summary>
    public IReadOnlyList<long>? ViewRange
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<long>>("view_range"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "view_range",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Command,
                JsonSerializer.Deserialize<JsonElement>("\"view\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Path;
        _ = this.ViewRange;
    }

    public BetaMemoryTool20250818ViewCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"view\"");
    }

    public BetaMemoryTool20250818ViewCommand(
        BetaMemoryTool20250818ViewCommand betaMemoryTool20250818ViewCommand
    )
        : base(betaMemoryTool20250818ViewCommand) { }

    public BetaMemoryTool20250818ViewCommand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"view\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818ViewCommand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMemoryTool20250818ViewCommandFromRaw.FromRawUnchecked"/>
    public static BetaMemoryTool20250818ViewCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMemoryTool20250818ViewCommand(string path)
        : this()
    {
        this.Path = path;
    }
}

class BetaMemoryTool20250818ViewCommandFromRaw : IFromRawJson<BetaMemoryTool20250818ViewCommand>
{
    /// <inheritdoc/>
    public BetaMemoryTool20250818ViewCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMemoryTool20250818ViewCommand.FromRawUnchecked(rawData);
}
