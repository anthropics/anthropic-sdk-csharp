using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        WorkspaceRateLimitOrganizationSource,
        WorkspaceRateLimitOrganizationSourceFromRaw
    >)
)]
public sealed record class WorkspaceRateLimitOrganizationSource : JsonModel
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

    public WorkspaceRateLimitOrganizationSource()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceRateLimitOrganizationSource(
        WorkspaceRateLimitOrganizationSource workspaceRateLimitOrganizationSource
    )
        : base(workspaceRateLimitOrganizationSource) { }
#pragma warning restore CS8618

    public WorkspaceRateLimitOrganizationSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceRateLimitOrganizationSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceRateLimitOrganizationSourceFromRaw.FromRawUnchecked"/>
    public static WorkspaceRateLimitOrganizationSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceRateLimitOrganizationSourceFromRaw
    : IFromRawJson<WorkspaceRateLimitOrganizationSource>
{
    /// <inheritdoc/>
    public WorkspaceRateLimitOrganizationSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceRateLimitOrganizationSource.FromRawUnchecked(rawData);
}
