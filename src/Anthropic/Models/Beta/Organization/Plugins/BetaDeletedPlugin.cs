using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaDeletedPlugin, BetaDeletedPluginFromRaw>))]
public sealed record class BetaDeletedPlugin : JsonModel
{
    /// <summary>
    /// The deleted Plugin's ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Always `plugin_deleted`.
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
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("plugin_deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDeletedPlugin()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedPlugin(BetaDeletedPlugin betaDeletedPlugin)
        : base(betaDeletedPlugin) { }
#pragma warning restore CS8618

    public BetaDeletedPlugin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedPlugin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedPluginFromRaw.FromRawUnchecked"/>
    public static BetaDeletedPlugin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDeletedPlugin(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDeletedPluginFromRaw : IFromRawJson<BetaDeletedPlugin>
{
    /// <inheritdoc/>
    public BetaDeletedPlugin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDeletedPlugin.FromRawUnchecked(rawData);
}
