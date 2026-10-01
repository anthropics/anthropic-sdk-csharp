using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(
    typeof(JsonModelConverter<BetaPluginTargetOrganization, BetaPluginTargetOrganizationFromRaw>)
)]
public sealed record class BetaPluginTargetOrganization : JsonModel
{
    /// <summary>
    /// Every member of the organization.
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

    public BetaPluginTargetOrganization()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginTargetOrganization(BetaPluginTargetOrganization betaPluginTargetOrganization)
        : base(betaPluginTargetOrganization) { }
#pragma warning restore CS8618

    public BetaPluginTargetOrganization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginTargetOrganization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginTargetOrganizationFromRaw.FromRawUnchecked"/>
    public static BetaPluginTargetOrganization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginTargetOrganizationFromRaw : IFromRawJson<BetaPluginTargetOrganization>
{
    /// <inheritdoc/>
    public BetaPluginTargetOrganization FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginTargetOrganization.FromRawUnchecked(rawData);
}
