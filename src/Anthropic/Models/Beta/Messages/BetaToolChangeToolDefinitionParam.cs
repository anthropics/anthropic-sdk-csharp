using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A tool defined by value: `definition` is a `tools` entry (any kind `tools` accepts,
/// an MCP toolset included). An `mcp_toolset` given here also requires the `mcp-client-2026-09-15` beta.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaToolChangeToolDefinitionParam,
        BetaToolChangeToolDefinitionParamFromRaw
    >)
)]
public sealed record class BetaToolChangeToolDefinitionParam : JsonModel
{
    public required BetaToolUnion Definition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaToolUnion>("definition");
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

    public BetaToolChangeToolDefinitionParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_definition");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolChangeToolDefinitionParam(
        BetaToolChangeToolDefinitionParam betaToolChangeToolDefinitionParam
    )
        : base(betaToolChangeToolDefinitionParam) { }
#pragma warning restore CS8618

    public BetaToolChangeToolDefinitionParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_definition");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChangeToolDefinitionParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChangeToolDefinitionParamFromRaw.FromRawUnchecked"/>
    public static BetaToolChangeToolDefinitionParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolChangeToolDefinitionParam(BetaToolUnion definition)
        : this()
    {
        this.Definition = definition;
    }
}

class BetaToolChangeToolDefinitionParamFromRaw : IFromRawJson<BetaToolChangeToolDefinitionParam>
{
    /// <inheritdoc/>
    public BetaToolChangeToolDefinitionParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolChangeToolDefinitionParam.FromRawUnchecked(rawData);
}
