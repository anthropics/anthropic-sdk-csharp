using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A tool defined by value, as a `compaction` block's `tool_changes` entry reports
/// it: `definition` is the tool's definition as it was sent, in the form of a `tools`
/// entry, without `cache_control`. Send it back unchanged with the block.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaToolChangeToolDefinition, BetaToolChangeToolDefinitionFromRaw>)
)]
public sealed record class BetaToolChangeToolDefinition : JsonModel
{
    public required BetaResponseToolUnion Definition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaResponseToolUnion>("definition");
        }
        init { this._rawData.Set("definition", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Definition.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_definition"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolChangeToolDefinition()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_definition");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolChangeToolDefinition(BetaToolChangeToolDefinition betaToolChangeToolDefinition)
        : base(betaToolChangeToolDefinition) { }
#pragma warning restore CS8618

    public BetaToolChangeToolDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_definition");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChangeToolDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChangeToolDefinitionFromRaw.FromRawUnchecked"/>
    public static BetaToolChangeToolDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolChangeToolDefinition(BetaResponseToolUnion definition)
        : this()
    {
        this.Definition = definition;
    }
}

class BetaToolChangeToolDefinitionFromRaw : IFromRawJson<BetaToolChangeToolDefinition>
{
    /// <inheritdoc/>
    public BetaToolChangeToolDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolChangeToolDefinition.FromRawUnchecked(rawData);
}
