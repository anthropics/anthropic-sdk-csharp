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
        WorkspaceRateLimitWorkspaceSource,
        WorkspaceRateLimitWorkspaceSourceFromRaw
    >)
)]
public sealed record class WorkspaceRateLimitWorkspaceSource : JsonModel
{
    /// <summary>
    /// Always `workspace`: a workspace-level override is stored.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("workspace")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WorkspaceRateLimitWorkspaceSource()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceRateLimitWorkspaceSource(
        WorkspaceRateLimitWorkspaceSource workspaceRateLimitWorkspaceSource
    )
        : base(workspaceRateLimitWorkspaceSource) { }
#pragma warning restore CS8618

    public WorkspaceRateLimitWorkspaceSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceRateLimitWorkspaceSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceRateLimitWorkspaceSourceFromRaw.FromRawUnchecked"/>
    public static WorkspaceRateLimitWorkspaceSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceRateLimitWorkspaceSourceFromRaw : IFromRawJson<WorkspaceRateLimitWorkspaceSource>
{
    /// <inheritdoc/>
    public WorkspaceRateLimitWorkspaceSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceRateLimitWorkspaceSource.FromRawUnchecked(rawData);
}
