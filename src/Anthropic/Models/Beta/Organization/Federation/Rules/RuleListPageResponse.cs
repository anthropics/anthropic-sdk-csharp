using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Rules;

[JsonConverter(typeof(JsonModelConverter<RuleListPageResponse, RuleListPageResponseFromRaw>))]
public sealed record class RuleListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaFederationRule> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaFederationRule>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaFederationRule>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results.
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

    public RuleListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleListPageResponse(RuleListPageResponse ruleListPageResponse)
        : base(ruleListPageResponse) { }
#pragma warning restore CS8618

    public RuleListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleListPageResponseFromRaw.FromRawUnchecked"/>
    public static RuleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleListPageResponseFromRaw : IFromRawJson<RuleListPageResponse>
{
    /// <inheritdoc/>
    public RuleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RuleListPageResponse.FromRawUnchecked(rawData);
}
