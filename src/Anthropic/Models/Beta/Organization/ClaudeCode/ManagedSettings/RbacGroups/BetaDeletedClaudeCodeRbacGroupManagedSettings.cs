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
        BetaDeletedClaudeCodeRbacGroupManagedSettings,
        BetaDeletedClaudeCodeRbacGroupManagedSettingsFromRaw
    >)
)]
public sealed record class BetaDeletedClaudeCodeRbacGroupManagedSettings : JsonModel
{
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
    /// Always `claude_code_rbac_group_managed_settings_deleted`.
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
        _ = this.RbacGroupID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("claude_code_rbac_group_managed_settings_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDeletedClaudeCodeRbacGroupManagedSettings()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings_deleted"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedClaudeCodeRbacGroupManagedSettings(
        BetaDeletedClaudeCodeRbacGroupManagedSettings betaDeletedClaudeCodeRbacGroupManagedSettings
    )
        : base(betaDeletedClaudeCodeRbacGroupManagedSettings) { }
#pragma warning restore CS8618

    public BetaDeletedClaudeCodeRbacGroupManagedSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_managed_settings_deleted"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedClaudeCodeRbacGroupManagedSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedClaudeCodeRbacGroupManagedSettingsFromRaw.FromRawUnchecked"/>
    public static BetaDeletedClaudeCodeRbacGroupManagedSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDeletedClaudeCodeRbacGroupManagedSettings(string rbacGroupID)
        : this()
    {
        this.RbacGroupID = rbacGroupID;
    }
}

class BetaDeletedClaudeCodeRbacGroupManagedSettingsFromRaw
    : IFromRawJson<BetaDeletedClaudeCodeRbacGroupManagedSettings>
{
    /// <inheritdoc/>
    public BetaDeletedClaudeCodeRbacGroupManagedSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDeletedClaudeCodeRbacGroupManagedSettings.FromRawUnchecked(rawData);
}
