using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaSpendLimitOrganizationServiceScope,
        BetaSpendLimitOrganizationServiceScopeFromRaw
    >)
)]
public sealed record class BetaSpendLimitOrganizationServiceScope : JsonModel
{
    public required string Service
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service");
        }
        init { this._rawData.Set("service", value); }
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
        _ = this.Service;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("organization_service")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSpendLimitOrganizationServiceScope()
    {
        this.Type = JsonSerializer.SerializeToElement("organization_service");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitOrganizationServiceScope(
        BetaSpendLimitOrganizationServiceScope betaSpendLimitOrganizationServiceScope
    )
        : base(betaSpendLimitOrganizationServiceScope) { }
#pragma warning restore CS8618

    public BetaSpendLimitOrganizationServiceScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization_service");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitOrganizationServiceScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitOrganizationServiceScopeFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitOrganizationServiceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSpendLimitOrganizationServiceScope(string service)
        : this()
    {
        this.Service = service;
    }
}

class BetaSpendLimitOrganizationServiceScopeFromRaw
    : IFromRawJson<BetaSpendLimitOrganizationServiceScope>
{
    /// <inheritdoc/>
    public BetaSpendLimitOrganizationServiceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitOrganizationServiceScope.FromRawUnchecked(rawData);
}
