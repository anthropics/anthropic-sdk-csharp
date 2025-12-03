using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolReferenceBlock, BetaToolReferenceBlockFromRaw>))]
public sealed record class BetaToolReferenceBlock : ModelBase
{
    public required string ToolName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tool_name"); }
        init { ModelBase.Set(this._rawData, "tool_name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolReferenceBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaToolReferenceBlockFromRaw : IFromRaw<BetaToolReferenceBlock>
{
    /// <inheritdoc/>
    public BetaToolReferenceBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolReferenceBlock.FromRawUnchecked(rawData);
}
