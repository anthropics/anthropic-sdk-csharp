using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(
    typeof(JsonModelConverter<BetaPluginOwnerOrganization, BetaPluginOwnerOrganizationFromRaw>)
)]
public sealed record class BetaPluginOwnerOrganization : JsonModel
{
    /// <summary>
    /// The Plugin lives in a plugin marketplace the organization owns.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPluginOwnerOrganization()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginOwnerOrganization(BetaPluginOwnerOrganization betaPluginOwnerOrganization)
        : base(betaPluginOwnerOrganization) { }
#pragma warning restore CS8618

    public BetaPluginOwnerOrganization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginOwnerOrganization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginOwnerOrganizationFromRaw.FromRawUnchecked"/>
    public static BetaPluginOwnerOrganization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginOwnerOrganizationFromRaw : IFromRawJson<BetaPluginOwnerOrganization>
{
    /// <inheritdoc/>
    public BetaPluginOwnerOrganization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginOwnerOrganization.FromRawUnchecked(rawData);
}
