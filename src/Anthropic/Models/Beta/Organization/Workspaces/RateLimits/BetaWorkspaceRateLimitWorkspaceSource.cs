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
        BetaWorkspaceRateLimitWorkspaceSource,
        BetaWorkspaceRateLimitWorkspaceSourceFromRaw
    >)
)]
public sealed record class BetaWorkspaceRateLimitWorkspaceSource : JsonModel
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

    public BetaWorkspaceRateLimitWorkspaceSource()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceRateLimitWorkspaceSource(
        BetaWorkspaceRateLimitWorkspaceSource betaWorkspaceRateLimitWorkspaceSource
    )
        : base(betaWorkspaceRateLimitWorkspaceSource) { }
#pragma warning restore CS8618

    public BetaWorkspaceRateLimitWorkspaceSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceRateLimitWorkspaceSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitWorkspaceSourceFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimitWorkspaceSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitWorkspaceSourceFromRaw
    : IFromRawJson<BetaWorkspaceRateLimitWorkspaceSource>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimitWorkspaceSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimitWorkspaceSource.FromRawUnchecked(rawData);
}
