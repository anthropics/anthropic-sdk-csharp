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
        BetaOrganizationRateLimitFilesGroup,
        BetaOrganizationRateLimitFilesGroupFromRaw
    >)
)]
public sealed record class BetaOrganizationRateLimitFilesGroup : JsonModel
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
    /// Always `files`: the Files API.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("files")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationRateLimitFilesGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("files");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimitFilesGroup(
        BetaOrganizationRateLimitFilesGroup betaOrganizationRateLimitFilesGroup
    )
        : base(betaOrganizationRateLimitFilesGroup) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimitFilesGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("files");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimitFilesGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitFilesGroupFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimitFilesGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOrganizationRateLimitFilesGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaOrganizationRateLimitFilesGroupFromRaw : IFromRawJson<BetaOrganizationRateLimitFilesGroup>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimitFilesGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimitFilesGroup.FromRawUnchecked(rawData);
}
