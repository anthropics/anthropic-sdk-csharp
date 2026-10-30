using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

[JsonConverter(
    typeof(JsonModelConverter<
        IncreaseRequestApproveResponse,
        IncreaseRequestApproveResponseFromRaw
    >)
)]
public sealed record class IncreaseRequestApproveResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Who submitted the increase request.
    /// </summary>
    public required BetaSpendLimitIncreaseRequestActor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaSpendLimitIncreaseRequestActor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, BetaSpendLimitPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaSpendLimitPeriod>>("period");
        }
        init { this._rawData.Set("period", value); }
    }

    public required DateTimeOffset? ResolvedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("resolved_at");
        }
        init { this._rawData.Set("resolved_at", value); }
    }

    /// <summary>
    /// Who approved or denied the increase request.
    /// </summary>
    public required BetaSpendLimitIncreaseRequestResolvedBy? ResolvedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaSpendLimitIncreaseRequestResolvedBy>(
                "resolved_by"
            );
        }
        init { this._rawData.Set("resolved_by", value); }
    }

    /// <summary>
    /// A configured spend limit: a cap on metered spend for one scope and period.
    /// </summary>
    public required BetaSpendLimit? SpendLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaSpendLimit>("spend_limit");
        }
        init { this._rawData.Set("spend_limit", value); }
    }

    /// <summary>
    /// Per-member effective-limit report row (`GET /spend_limits/effective`).
    /// </summary>
    public required BetaSpendSummary? SpendSummary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaSpendSummary>("spend_summary");
        }
        init { this._rawData.Set("spend_summary", value); }
    }

    public required ApiEnum<string, BetaSpendLimitIncreaseRequestStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
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
        _ = this.ID;
        this.Actor.Validate();
        _ = this.CreatedAt;
        this.Period.Validate();
        _ = this.ResolvedAt;
        this.ResolvedBy?.Validate();
        this.SpendLimit?.Validate();
        this.SpendSummary?.Validate();
        this.Status.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("spend_limit_increase_request")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public IncreaseRequestApproveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("spend_limit_increase_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncreaseRequestApproveResponse(
        IncreaseRequestApproveResponse increaseRequestApproveResponse
    )
        : base(increaseRequestApproveResponse) { }
#pragma warning restore CS8618

    public IncreaseRequestApproveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("spend_limit_increase_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncreaseRequestApproveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IncreaseRequestApproveResponseFromRaw.FromRawUnchecked"/>
    public static IncreaseRequestApproveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IncreaseRequestApproveResponseFromRaw : IFromRawJson<IncreaseRequestApproveResponse>
{
    /// <inheritdoc/>
    public IncreaseRequestApproveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IncreaseRequestApproveResponse.FromRawUnchecked(rawData);
}
