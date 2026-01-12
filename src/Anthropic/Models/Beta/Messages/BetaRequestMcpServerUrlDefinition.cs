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
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMcpServerURLDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
