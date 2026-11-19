using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeCodeManagedSettingsConfiguration,
        BetaClaudeCodeManagedSettingsConfigurationFromRaw
    >)
)]
public sealed record class BetaClaudeCodeManagedSettingsConfiguration : JsonModel
{
    /// <summary>
    /// How the organization serves managed settings. In `organization` mode every
    /// member receives the organization settings, which are set in claude.ai. In
    /// `rbac_groups` mode each member receives the settings of the first RBAC Group
    /// in `rbac_group_order` that they belong to. A member in none of them receives
    /// the default settings, or no settings if no default is set.
    /// </summary>
    public required BetaClaudeCodeManagedSettingsMode Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeCodeManagedSettingsMode>("mode");
        }
        init { this._rawData.Set("mode", value); }
    }

    /// <summary>
    /// When the mode last changed, in RFC 3339 format, or `null` if it never has.
    /// </summary>
    public required DateTimeOffset? ModeUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("mode_updated_at");
        }
        init { this._rawData.Set("mode_updated_at", value); }
    }

    /// <summary>
    /// The ID of every RBAC Group with settings, deleted groups included, highest
    /// precedence first.
    /// </summary>
    public required IReadOnlyList<string> RbacGroupOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("rbac_group_order");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "rbac_group_order",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An opaque version of `rbac_group_order`, which changes whenever the order
    /// does. Send it back with a new order.
    /// </summary>
    public required string RbacGroupOrderVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rbac_group_order_version");
        }
        init { this._rawData.Set("rbac_group_order_version", value); }
    }

    /// <summary>
    /// Always `claude_code_managed_settings_configuration`.
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
        this.Mode.Validate();
        _ = this.ModeUpdatedAt;
        _ = this.RbacGroupOrder;
        _ = this.RbacGroupOrderVersion;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("claude_code_managed_settings_configuration")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeCodeManagedSettingsConfiguration()
    {
        this.Type = JsonSerializer.SerializeToElement("claude_code_managed_settings_configuration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeManagedSettingsConfiguration(
        BetaClaudeCodeManagedSettingsConfiguration betaClaudeCodeManagedSettingsConfiguration
    )
        : base(betaClaudeCodeManagedSettingsConfiguration) { }
#pragma warning restore CS8618

    public BetaClaudeCodeManagedSettingsConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("claude_code_managed_settings_configuration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeManagedSettingsConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeManagedSettingsConfigurationFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeManagedSettingsConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeManagedSettingsConfigurationFromRaw
    : IFromRawJson<BetaClaudeCodeManagedSettingsConfiguration>
{
    /// <inheritdoc/>
    public BetaClaudeCodeManagedSettingsConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeManagedSettingsConfiguration.FromRawUnchecked(rawData);
}
