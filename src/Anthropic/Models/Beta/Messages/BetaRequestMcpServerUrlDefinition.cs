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
        BetaRequestMcpServerURLDefinition,
        BetaRequestMcpServerURLDefinitionFromRaw
    >)
)]
public sealed record class BetaRequestMcpServerURLDefinition : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"url\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.AuthorizationToken;
        this.ToolConfiguration?.Validate();
    }

    public BetaRequestMcpServerURLDefinition()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

    public BetaRequestMcpServerURLDefinition(
        BetaRequestMcpServerURLDefinition BetaRequestMcpServerURLDefinition
    )
        : base(BetaRequestMcpServerURLDefinition) { }

    public BetaRequestMcpServerURLDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMcpServerURLDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestMcpServerURLDefinitionFromRaw.FromRawUnchecked"/>
    public static BetaRequestMcpServerURLDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRequestMcpServerURLDefinitionFromRaw : IFromRawJson<BetaRequestMcpServerURLDefinition>
{
    /// <inheritdoc/>
    public BetaRequestMcpServerURLDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestMcpServerURLDefinition.FromRawUnchecked(rawData);
}
