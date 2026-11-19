using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeCodeRbacGroupDefaultManagedSettings,
        BetaClaudeCodeRbacGroupDefaultManagedSettingsFromRaw
    >)
)]
public sealed record class BetaClaudeCodeRbacGroupDefaultManagedSettings : JsonModel
{
    /// <summary>
    /// The default settings document, or `null` if none are set or the stored document
    /// is damaged and can no longer be read. To tell these apart, `updated_at` is
    /// `null` only when none are set. Replacing a damaged document fixes this.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "settings"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Always `claude_code_rbac_group_default_managed_settings`.
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
    /// When the default settings last changed, in RFC 3339 format, or `null` if none
    /// are set.
    /// </summary>
    public required DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Settings;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("claude_code_rbac_group_default_managed_settings")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaClaudeCodeRbacGroupDefaultManagedSettings()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_default_managed_settings"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeRbacGroupDefaultManagedSettings(
        BetaClaudeCodeRbacGroupDefaultManagedSettings betaClaudeCodeRbacGroupDefaultManagedSettings
    )
        : base(betaClaudeCodeRbacGroupDefaultManagedSettings) { }
#pragma warning restore CS8618

    public BetaClaudeCodeRbacGroupDefaultManagedSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "claude_code_rbac_group_default_managed_settings"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeRbacGroupDefaultManagedSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeRbacGroupDefaultManagedSettingsFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeRbacGroupDefaultManagedSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeRbacGroupDefaultManagedSettingsFromRaw
    : IFromRawJson<BetaClaudeCodeRbacGroupDefaultManagedSettings>
{
    /// <inheritdoc/>
    public BetaClaudeCodeRbacGroupDefaultManagedSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeRbacGroupDefaultManagedSettings.FromRawUnchecked(rawData);
}
