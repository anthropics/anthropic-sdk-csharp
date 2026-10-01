using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationRateLimitWebSearchGroup,
        BetaOrganizationRateLimitWebSearchGroupFromRaw
    >)
)]
public sealed record class BetaOrganizationRateLimitWebSearchGroup : JsonModel
{
    /// <summary>
    /// Opaque identifier of the rate-limit group (for example, `rlg_01VPTCmyiu5ZLsWkcxYG2pY8`).
    /// It is the same in every organization and never changes, unlike the entry's
    /// own identifier, which differs per organization.
    /// </summary>
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
    /// Always `web_search`: the Messages API web search tool.
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
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("web_search")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationRateLimitWebSearchGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimitWebSearchGroup(
        BetaOrganizationRateLimitWebSearchGroup betaOrganizationRateLimitWebSearchGroup
    )
        : base(betaOrganizationRateLimitWebSearchGroup) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimitWebSearchGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimitWebSearchGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitWebSearchGroupFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimitWebSearchGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOrganizationRateLimitWebSearchGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaOrganizationRateLimitWebSearchGroupFromRaw
    : IFromRawJson<BetaOrganizationRateLimitWebSearchGroup>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimitWebSearchGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimitWebSearchGroup.FromRawUnchecked(rawData);
}
