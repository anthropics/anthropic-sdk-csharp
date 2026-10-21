using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// URL-based MCP server connection as returned in API responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpServerUrlDefinition,
        BetaManagedAgentsMcpServerUrlDefinitionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpServerUrlDefinition : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("url")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public BetaManagedAgentsMcpServerUrlDefinition()
    {
        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpServerUrlDefinition(
        BetaManagedAgentsMcpServerUrlDefinition betaManagedAgentsMcpServerUrlDefinition
    )
        : base(betaManagedAgentsMcpServerUrlDefinition) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpServerUrlDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpServerUrlDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpServerUrlDefinitionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpServerUrlDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpServerUrlDefinitionFromRaw
    : IFromRawJson<BetaManagedAgentsMcpServerUrlDefinition>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpServerUrlDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpServerUrlDefinition.FromRawUnchecked(rawData);
}
