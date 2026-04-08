using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType>
            >("type");
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
        this.Type.Validate();
        _ = this.Url;
    }

    public BetaManagedAgentsMcpServerUrlDefinition() { }

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

[JsonConverter(typeof(BetaManagedAgentsMcpServerUrlDefinitionTypeConverter))]
public enum BetaManagedAgentsMcpServerUrlDefinitionType
{
    Url,
}

sealed class BetaManagedAgentsMcpServerUrlDefinitionTypeConverter
    : JsonConverter<BetaManagedAgentsMcpServerUrlDefinitionType>
{
    public override BetaManagedAgentsMcpServerUrlDefinitionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "url" => BetaManagedAgentsMcpServerUrlDefinitionType.Url,
            _ => (BetaManagedAgentsMcpServerUrlDefinitionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpServerUrlDefinitionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpServerUrlDefinitionType.Url => "url",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
