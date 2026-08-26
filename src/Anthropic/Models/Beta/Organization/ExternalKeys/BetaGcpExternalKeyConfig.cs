using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

[JsonConverter(
    typeof(JsonModelConverter<BetaGcpExternalKeyConfig, BetaGcpExternalKeyConfigFromRaw>)
)]
public sealed record class BetaGcpExternalKeyConfig : JsonModel
{
    /// <summary>
    /// Full resource name of the Cloud KMS key.
    /// </summary>
    public required string KeyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key_name");
        }
        init { this._rawData.Set("key_name", value); }
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
        _ = this.KeyName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("gcp")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGcpExternalKeyConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGcpExternalKeyConfig(BetaGcpExternalKeyConfig betaGcpExternalKeyConfig)
        : base(betaGcpExternalKeyConfig) { }
#pragma warning restore CS8618

    public BetaGcpExternalKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGcpExternalKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGcpExternalKeyConfigFromRaw.FromRawUnchecked"/>
    public static BetaGcpExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGcpExternalKeyConfig(string keyName)
        : this()
    {
        this.KeyName = keyName;
    }
}

class BetaGcpExternalKeyConfigFromRaw : IFromRawJson<BetaGcpExternalKeyConfig>
{
    /// <inheritdoc/>
    public BetaGcpExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGcpExternalKeyConfig.FromRawUnchecked(rawData);
}
