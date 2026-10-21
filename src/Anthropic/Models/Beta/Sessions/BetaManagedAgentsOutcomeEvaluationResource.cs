using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Evaluation state for a single outcome defined via a `define_outcome` event.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsOutcomeEvaluationResource,
        BetaManagedAgentsOutcomeEvaluationResourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsOutcomeEvaluationResource : JsonModel
{
    /// <summary>
    /// When the outcome reached a terminal result. Null while `pending`/`running`/`evaluating`.
    /// </summary>
    public required DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completed_at");
        }
        init { this._rawData.Set("completed_at", value); }
    }

    /// <summary>
    /// What the agent should produce.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Grader's verdict text from the most recent evaluation. For `satisfied`, explains
    /// why criteria are met; for `needs_revision` (intermediate), what's missing;
    /// for `failed`, why unrecoverable.
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// 0-indexed revision cycle the outcome is currently on.
    /// </summary>
    public required int Iteration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("iteration");
        }
        init { this._rawData.Set("iteration", value); }
    }

    /// <summary>
    /// Server-generated outc_ ID for this outcome.
    /// </summary>
    public required string OutcomeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outcome_id");
        }
        init { this._rawData.Set("outcome_id", value); }
    }

    /// <summary>
    /// Current evaluation state. `pending` before the agent begins work; `running`
    /// while producing or revising; `evaluating` while the grader scores; `satisfied`/`max_iterations_reached`/`failed`/`interrupted`
    /// are terminal.
    /// </summary>
    public required string Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
    }

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
        _ = this.CompletedAt;
        _ = this.Description;
        _ = this.Explanation;
        _ = this.Iteration;
        _ = this.OutcomeID;
        _ = this.Result;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("outcome_evaluation")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsOutcomeEvaluationResource()
    {
        this.Type = JsonSerializer.SerializeToElement("outcome_evaluation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsOutcomeEvaluationResource(
        BetaManagedAgentsOutcomeEvaluationResource betaManagedAgentsOutcomeEvaluationResource
    )
        : base(betaManagedAgentsOutcomeEvaluationResource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsOutcomeEvaluationResource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("outcome_evaluation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsOutcomeEvaluationResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsOutcomeEvaluationResourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsOutcomeEvaluationResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsOutcomeEvaluationResourceFromRaw
    : IFromRawJson<BetaManagedAgentsOutcomeEvaluationResource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsOutcomeEvaluationResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsOutcomeEvaluationResource.FromRawUnchecked(rawData);
}
