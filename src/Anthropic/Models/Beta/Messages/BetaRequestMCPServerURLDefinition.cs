using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaRequestMCPServerURLDefinition,
        BetaRequestMCPServerURLDefinitionFromRaw
    >)
)]
public sealed record class BetaRequestMCPServerURLDefinition : ModelBase
{
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    public string? AuthorizationToken
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "authorization_token"); }
        init { ModelBase.Set(this._rawData, "authorization_token", value); }
    }

    public BetaRequestMCPServerToolConfiguration? ToolConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<BetaRequestMCPServerToolConfiguration>(
                this.RawData,
                "tool_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "tool_configuration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"url\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.URL;
        _ = this.AuthorizationToken;
        this.ToolConfiguration?.Validate();
    }

    public BetaRequestMCPServerURLDefinition()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

    public BetaRequestMCPServerURLDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMCPServerURLDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestMCPServerURLDefinitionFromRaw.FromRawUnchecked"/>
    public static BetaRequestMCPServerURLDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRequestMCPServerURLDefinitionFromRaw : IFromRaw<BetaRequestMCPServerURLDefinition>
{
    /// <inheritdoc/>
    public BetaRequestMCPServerURLDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestMCPServerURLDefinition.FromRawUnchecked(rawData);
}
