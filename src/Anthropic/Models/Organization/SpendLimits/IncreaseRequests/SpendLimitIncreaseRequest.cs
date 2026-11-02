using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

[JsonConverter(
    typeof(JsonModelConverter<SpendLimitIncreaseRequest, SpendLimitIncreaseRequestFromRaw>)
)]
public sealed record class SpendLimitIncreaseRequest : JsonModel
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
    public required SpendLimitIncreaseRequestActor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SpendLimitIncreaseRequestActor>("actor");
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

    public required ApiEnum<string, SpendLimitPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SpendLimitPeriod>>("period");
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
    public required SpendLimitIncreaseRequestResolvedBy? ResolvedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SpendLimitIncreaseRequestResolvedBy>(
                "resolved_by"
            );
        }
        init { this._rawData.Set("resolved_by", value); }
    }

    /// <summary>
    /// Per-member effective-limit report row (`GET /spend_limits/effective`).
    /// </summary>
    public required SpendSummary? SpendSummary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SpendSummary>("spend_summary");
        }
        init { this._rawData.Set("spend_summary", value); }
    }

    public required ApiEnum<string, SpendLimitIncreaseRequestStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SpendLimitIncreaseRequestStatus>>(
                "status"
            );
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

    public SpendLimitIncreaseRequest()
    {
        this.Type = JsonSerializer.SerializeToElement("spend_limit_increase_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitIncreaseRequest(SpendLimitIncreaseRequest spendLimitIncreaseRequest)
        : base(spendLimitIncreaseRequest) { }
#pragma warning restore CS8618

    public SpendLimitIncreaseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("spend_limit_increase_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitIncreaseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitIncreaseRequestFromRaw.FromRawUnchecked"/>
    public static SpendLimitIncreaseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendLimitIncreaseRequestFromRaw : IFromRawJson<SpendLimitIncreaseRequest>
{
    /// <inheritdoc/>
    public SpendLimitIncreaseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitIncreaseRequest.FromRawUnchecked(rawData);
}
