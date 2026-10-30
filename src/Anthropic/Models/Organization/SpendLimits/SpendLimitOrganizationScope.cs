using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<SpendLimitOrganizationScope, SpendLimitOrganizationScopeFromRaw>)
)]
public sealed record class SpendLimitOrganizationScope : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SpendLimitOrganizationScope()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitOrganizationScope(SpendLimitOrganizationScope spendLimitOrganizationScope)
        : base(spendLimitOrganizationScope) { }
#pragma warning restore CS8618

    public SpendLimitOrganizationScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitOrganizationScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitOrganizationScopeFromRaw.FromRawUnchecked"/>
    public static SpendLimitOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendLimitOrganizationScopeFromRaw : IFromRawJson<SpendLimitOrganizationScope>
{
    /// <inheritdoc/>
    public SpendLimitOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitOrganizationScope.FromRawUnchecked(rawData);
}
