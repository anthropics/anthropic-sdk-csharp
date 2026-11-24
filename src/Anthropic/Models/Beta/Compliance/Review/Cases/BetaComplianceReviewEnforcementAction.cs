using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// An action that Anthropic took on the flagged traffic.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewEnforcementAction,
        BetaComplianceReviewEnforcementActionFromRaw
    >)
)]
public sealed record class BetaComplianceReviewEnforcementAction : JsonModel
{
    /// <summary>
    /// The kind of action. New values can appear, so accept a value that you don't know.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
    }

    public BetaComplianceReviewEnforcementAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewEnforcementAction(
        BetaComplianceReviewEnforcementAction betaComplianceReviewEnforcementAction
    )
        : base(betaComplianceReviewEnforcementAction) { }
#pragma warning restore CS8618

    public BetaComplianceReviewEnforcementAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewEnforcementAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewEnforcementActionFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewEnforcementAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceReviewEnforcementAction(string type)
        : this()
    {
        this.Type = type;
    }
}

class BetaComplianceReviewEnforcementActionFromRaw
    : IFromRawJson<BetaComplianceReviewEnforcementAction>
{
    /// <inheritdoc/>
    public BetaComplianceReviewEnforcementAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewEnforcementAction.FromRawUnchecked(rawData);
}
