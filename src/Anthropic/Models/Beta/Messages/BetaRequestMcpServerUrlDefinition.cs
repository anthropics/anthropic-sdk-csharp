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
        BetaRequestMcpServerUrlDefinition,
        BetaRequestMcpServerUrlDefinitionFromRaw
    >)
)]
public sealed record class BetaRequestMcpServerUrlDefinition : JsonModel
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

    public string? AuthorizationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorization_token");
        }
        init { this._rawData.Set("authorization_token", value); }
    }

    public BetaRequestMcpServerToolConfiguration? ToolConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaRequestMcpServerToolConfiguration>(
                "tool_configuration"
            );
        }
        init { this._rawData.Set("tool_configuration", value); }
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
        _ = this.AuthorizationToken;
        this.ToolConfiguration?.Validate();
    }

    public BetaRequestMcpServerUrlDefinition()
    {
        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRequestMcpServerUrlDefinition(
        BetaRequestMcpServerUrlDefinition betaRequestMcpServerUrlDefinition
    )
        : base(betaRequestMcpServerUrlDefinition) { }
#pragma warning restore CS8618

    public BetaRequestMcpServerUrlDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMcpServerUrlDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestMcpServerUrlDefinitionFromRaw.FromRawUnchecked"/>
    public static BetaRequestMcpServerUrlDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRequestMcpServerUrlDefinitionFromRaw : IFromRawJson<BetaRequestMcpServerUrlDefinition>
{
    /// <inheritdoc/>
    public BetaRequestMcpServerUrlDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestMcpServerUrlDefinition.FromRawUnchecked(rawData);
}
