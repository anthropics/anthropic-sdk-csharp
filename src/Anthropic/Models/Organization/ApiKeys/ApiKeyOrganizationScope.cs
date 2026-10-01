using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyOrganizationScope, ApiKeyOrganizationScopeFromRaw>))]
public sealed record class ApiKeyOrganizationScope : JsonModel
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

    public ApiKeyOrganizationScope()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyOrganizationScope(ApiKeyOrganizationScope apiKeyOrganizationScope)
        : base(apiKeyOrganizationScope) { }
#pragma warning restore CS8618

    public ApiKeyOrganizationScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyOrganizationScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyOrganizationScopeFromRaw.FromRawUnchecked"/>
    public static ApiKeyOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyOrganizationScopeFromRaw : IFromRawJson<ApiKeyOrganizationScope>
{
    /// <inheritdoc/>
    public ApiKeyOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiKeyOrganizationScope.FromRawUnchecked(rawData);
}
