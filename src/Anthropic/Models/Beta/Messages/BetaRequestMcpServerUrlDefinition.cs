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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public required string Url
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    public string? AuthorizationToken
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "authorization_token"); }
        init { JsonModel.Set(this._rawData, "authorization_token", value); }
    }

    public BetaRequestMcpServerToolConfiguration? ToolConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<BetaRequestMcpServerToolConfiguration>(
                this.RawData,
                "tool_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "tool_configuration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"url\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.AuthorizationToken;
        this.ToolConfiguration?.Validate();
    }

    public BetaRequestMcpServerUrlDefinition()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

    public BetaRequestMcpServerUrlDefinition(
        BetaRequestMcpServerUrlDefinition betaRequestMcpServerUrlDefinition
    )
        : base(betaRequestMcpServerUrlDefinition) { }

    public BetaRequestMcpServerUrlDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMcpServerUrlDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
