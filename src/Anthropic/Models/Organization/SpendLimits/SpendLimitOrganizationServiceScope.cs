using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        SpendLimitOrganizationServiceScope,
        SpendLimitOrganizationServiceScopeFromRaw
    >)
)]
public sealed record class SpendLimitOrganizationServiceScope : JsonModel
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

    public SpendLimitOrganizationServiceScope()
    {
        this.Type = JsonSerializer.SerializeToElement("organization_service");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitOrganizationServiceScope(
        SpendLimitOrganizationServiceScope spendLimitOrganizationServiceScope
    )
        : base(spendLimitOrganizationServiceScope) { }
#pragma warning restore CS8618

    public SpendLimitOrganizationServiceScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization_service");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitOrganizationServiceScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitOrganizationServiceScopeFromRaw.FromRawUnchecked"/>
    public static SpendLimitOrganizationServiceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendLimitOrganizationServiceScope(string service)
        : this()
    {
        this.Service = service;
    }
}

class SpendLimitOrganizationServiceScopeFromRaw : IFromRawJson<SpendLimitOrganizationServiceScope>
{
    /// <inheritdoc/>
    public SpendLimitOrganizationServiceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitOrganizationServiceScope.FromRawUnchecked(rawData);
}
