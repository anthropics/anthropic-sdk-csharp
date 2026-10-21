using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaPluginApiActor, BetaPluginApiActorFromRaw>))]
public sealed record class BetaPluginApiActor : JsonModel
{
    /// <summary>
    /// The key's ID.
    /// </summary>
    public required string ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key_id");
        }
        init { this._rawData.Set("api_key_id", value); }
    }

    /// <summary>
    /// An Admin API key, in the same form the Compliance API activity feed uses
    /// for it.
    /// </summary>
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
        _ = this.ApiKeyID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("api_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPluginApiActor()
    {
        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginApiActor(BetaPluginApiActor betaPluginApiActor)
        : base(betaPluginApiActor) { }
#pragma warning restore CS8618

    public BetaPluginApiActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginApiActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginApiActorFromRaw.FromRawUnchecked"/>
    public static BetaPluginApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPluginApiActor(string apiKeyID)
        : this()
    {
        this.ApiKeyID = apiKeyID;
    }
}

class BetaPluginApiActorFromRaw : IFromRawJson<BetaPluginApiActor>
{
    /// <inheritdoc/>
    public BetaPluginApiActor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPluginApiActor.FromRawUnchecked(rawData);
}
