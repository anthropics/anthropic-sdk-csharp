using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ApiKeys;

[JsonConverter(
    typeof(JsonModelConverter<BetaApiKeyOrganizationScope, BetaApiKeyOrganizationScopeFromRaw>)
)]
public sealed record class BetaApiKeyOrganizationScope : JsonModel
{
    /// <summary>
    /// Scope type. Always `"organization"`: the API key has no Workspace. Only a
    /// principal-bound API key can have this scope.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaApiKeyOrganizationScope()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaApiKeyOrganizationScope(BetaApiKeyOrganizationScope betaApiKeyOrganizationScope)
        : base(betaApiKeyOrganizationScope) { }
#pragma warning restore CS8618

    public BetaApiKeyOrganizationScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaApiKeyOrganizationScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApiKeyOrganizationScopeFromRaw.FromRawUnchecked"/>
    public static BetaApiKeyOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaApiKeyOrganizationScopeFromRaw : IFromRawJson<BetaApiKeyOrganizationScope>
{
    /// <inheritdoc/>
    public BetaApiKeyOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaApiKeyOrganizationScope.FromRawUnchecked(rawData);
}
