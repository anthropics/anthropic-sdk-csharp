using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

[JsonConverter(typeof(JsonModelConverter<GcpExternalKeyConfig, GcpExternalKeyConfigFromRaw>))]
public sealed record class GcpExternalKeyConfig : JsonModel
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

    public GcpExternalKeyConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GcpExternalKeyConfig(GcpExternalKeyConfig gcpExternalKeyConfig)
        : base(gcpExternalKeyConfig) { }
#pragma warning restore CS8618

    public GcpExternalKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GcpExternalKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GcpExternalKeyConfigFromRaw.FromRawUnchecked"/>
    public static GcpExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GcpExternalKeyConfig(string keyName)
        : this()
    {
        this.KeyName = keyName;
    }
}

class GcpExternalKeyConfigFromRaw : IFromRawJson<GcpExternalKeyConfig>
{
    /// <inheritdoc/>
    public GcpExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GcpExternalKeyConfig.FromRawUnchecked(rawData);
}
