using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeCodeRbacGroupManagedSettingsSummary,
        BetaClaudeCodeRbacGroupManagedSettingsSummaryFromRaw
    >)
)]
public sealed record class BetaClaudeCodeRbacGroupManagedSettingsSummary : JsonModel
{
    /// <summary>
    /// When the settings document this group uses was first stored, in RFC 3339 format.
    /// This can be earlier than when the group got its settings, and it changes
    /// if the group gets a different document.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The RBAC Group's ID, prefixed `rbac_group_`.
    /// </summary>
    public required string RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// Whether the group is still one of the organization's RBAC Groups. Its `type`
    /// is `active` if it is, `deleted` if it is not, and `unknown` if that cannot
    /// be checked right now. A deleted group's settings stay in `rbac_group_order`
    /// but match no member.
    /// </summary>
    public required BetaClaudeCodeRbacGroupStatus RbacGroupStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeCodeRbacGroupStatus>(
                "rbac_group_status"
            );
        }
        init { this._rawData.Set("rbac_group_status", value); }
    }

    /// <summary>
    /// Always `claude_code_rbac_group_managed_settings_summary`.
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
    /// When this group's settings or its position in the order last changed, in RFC
    /// 3339 format. Its position changes whenever the number of groups ahead of
    /// it changes.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.RbacGroupID;
        this.RbacGroupStatus.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("claude_code_rbac_group_managed_settings_summary")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaClaudeCodeRbacGroupManagedSettingsSummary()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings_summary"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeRbacGroupManagedSettingsSummary(
        BetaClaudeCodeRbacGroupManagedSettingsSummary betaClaudeCodeRbacGroupManagedSettingsSummary
    )
        : base(betaClaudeCodeRbacGroupManagedSettingsSummary) { }
#pragma warning restore CS8618

    public BetaClaudeCodeRbacGroupManagedSettingsSummary(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings_summary"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeRbacGroupManagedSettingsSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeRbacGroupManagedSettingsSummaryFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeRbacGroupManagedSettingsSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeRbacGroupManagedSettingsSummaryFromRaw
    : IFromRawJson<BetaClaudeCodeRbacGroupManagedSettingsSummary>
{
    /// <inheritdoc/>
    public BetaClaudeCodeRbacGroupManagedSettingsSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeRbacGroupManagedSettingsSummary.FromRawUnchecked(rawData);
}
