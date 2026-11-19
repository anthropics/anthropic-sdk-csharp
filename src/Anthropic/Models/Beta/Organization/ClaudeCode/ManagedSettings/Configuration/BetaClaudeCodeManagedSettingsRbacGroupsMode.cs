using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeCodeManagedSettingsRbacGroupsMode,
        BetaClaudeCodeManagedSettingsRbacGroupsModeFromRaw
    >)
)]
public sealed record class BetaClaudeCodeManagedSettingsRbacGroupsMode : JsonModel
{
    /// <summary>
    /// Always `rbac_groups`.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rbac_groups")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeCodeManagedSettingsRbacGroupsMode()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_groups");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeManagedSettingsRbacGroupsMode(
        BetaClaudeCodeManagedSettingsRbacGroupsMode betaClaudeCodeManagedSettingsRbacGroupsMode
    )
        : base(betaClaudeCodeManagedSettingsRbacGroupsMode) { }
#pragma warning restore CS8618

    public BetaClaudeCodeManagedSettingsRbacGroupsMode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_groups");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeManagedSettingsRbacGroupsMode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeManagedSettingsRbacGroupsModeFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeManagedSettingsRbacGroupsMode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeManagedSettingsRbacGroupsModeFromRaw
    : IFromRawJson<BetaClaudeCodeManagedSettingsRbacGroupsMode>
{
    /// <inheritdoc/>
    public BetaClaudeCodeManagedSettingsRbacGroupsMode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeManagedSettingsRbacGroupsMode.FromRawUnchecked(rawData);
}
