using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaToolReferenceBlock, BetaToolReferenceBlockFromRaw>))]
public sealed record class BetaToolReferenceBlock : JsonModel
{
    public required string ToolName
    {
        get { return this._rawData.GetNotNullClass<string>("tool_name"); }
        init { this._rawData.Set("tool_name", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ToolName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolReferenceBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");
    }

    public BetaToolReferenceBlock(BetaToolReferenceBlock betaToolReferenceBlock)
        : base(betaToolReferenceBlock) { }

    public BetaToolReferenceBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolReferenceBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolReferenceBlockFromRaw.FromRawUnchecked"/>
    public static BetaToolReferenceBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolReferenceBlock(string toolName)
        : this()
    {
        this.ToolName = toolName;
    }
}

class BetaToolReferenceBlockFromRaw : IFromRawJson<BetaToolReferenceBlock>
{
    /// <inheritdoc/>
    public BetaToolReferenceBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolReferenceBlock.FromRawUnchecked(rawData);
}
