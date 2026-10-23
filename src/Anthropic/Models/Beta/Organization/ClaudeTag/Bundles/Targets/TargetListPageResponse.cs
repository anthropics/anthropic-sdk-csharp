using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

[JsonConverter(typeof(JsonModelConverter<TargetListPageResponse, TargetListPageResponseFromRaw>))]
public sealed record class TargetListPageResponse : JsonModel
{
    /// <summary>
    /// Bundle Targets on this page, newest first.
    /// </summary>
    public required IReadOnlyList<BetaClaudeTagBundleTarget> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaClaudeTagBundleTarget>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaClaudeTagBundleTarget>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page. Null on the last page.
    /// </summary>
    public required string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public TargetListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetListPageResponse(TargetListPageResponse targetListPageResponse)
        : base(targetListPageResponse) { }
#pragma warning restore CS8618

    public TargetListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetListPageResponseFromRaw.FromRawUnchecked"/>
    public static TargetListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetListPageResponseFromRaw : IFromRawJson<TargetListPageResponse>
{
    /// <inheritdoc/>
    public TargetListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TargetListPageResponse.FromRawUnchecked(rawData);
}
