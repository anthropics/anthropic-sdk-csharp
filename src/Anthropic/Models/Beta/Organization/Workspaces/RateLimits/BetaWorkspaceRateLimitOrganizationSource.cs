using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWorkspaceRateLimitOrganizationSource,
        BetaWorkspaceRateLimitOrganizationSourceFromRaw
    >)
)]
public sealed record class BetaWorkspaceRateLimitOrganizationSource : JsonModel
{
    /// <summary>
    /// Always `organization`: no workspace-level override is stored, so the organization's
    /// value applies.
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

    public BetaWorkspaceRateLimitOrganizationSource()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceRateLimitOrganizationSource(
        BetaWorkspaceRateLimitOrganizationSource betaWorkspaceRateLimitOrganizationSource
    )
        : base(betaWorkspaceRateLimitOrganizationSource) { }
#pragma warning restore CS8618

    public BetaWorkspaceRateLimitOrganizationSource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceRateLimitOrganizationSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitOrganizationSourceFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimitOrganizationSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitOrganizationSourceFromRaw
    : IFromRawJson<BetaWorkspaceRateLimitOrganizationSource>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimitOrganizationSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimitOrganizationSource.FromRawUnchecked(rawData);
}
