using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaPluginTargetOrganizationMember,
        BetaPluginTargetOrganizationMemberFromRaw
    >)
)]
public sealed record class BetaPluginTargetOrganizationMember : JsonModel
{
    /// <summary>
    /// One member of the organization.
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

    /// <summary>
    /// The member's User ID.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("organization_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaPluginTargetOrganizationMember()
    {
        this.Type = JsonSerializer.SerializeToElement("organization_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginTargetOrganizationMember(
        BetaPluginTargetOrganizationMember betaPluginTargetOrganizationMember
    )
        : base(betaPluginTargetOrganizationMember) { }
#pragma warning restore CS8618

    public BetaPluginTargetOrganizationMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginTargetOrganizationMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginTargetOrganizationMemberFromRaw.FromRawUnchecked"/>
    public static BetaPluginTargetOrganizationMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPluginTargetOrganizationMember(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class BetaPluginTargetOrganizationMemberFromRaw : IFromRawJson<BetaPluginTargetOrganizationMember>
{
    /// <inheritdoc/>
    public BetaPluginTargetOrganizationMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginTargetOrganizationMember.FromRawUnchecked(rawData);
}
