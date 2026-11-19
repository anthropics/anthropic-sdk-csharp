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
        BetaClaudeCodeManagedSettingsRbacGroupsModeParam,
        BetaClaudeCodeManagedSettingsRbacGroupsModeParamFromRaw
    >)
)]
public sealed record class BetaClaudeCodeManagedSettingsRbacGroupsModeParam : JsonModel
{
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

    public BetaClaudeCodeManagedSettingsRbacGroupsModeParam()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_groups");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeManagedSettingsRbacGroupsModeParam(
        BetaClaudeCodeManagedSettingsRbacGroupsModeParam betaClaudeCodeManagedSettingsRbacGroupsModeParam
    )
        : base(betaClaudeCodeManagedSettingsRbacGroupsModeParam) { }
#pragma warning restore CS8618

    public BetaClaudeCodeManagedSettingsRbacGroupsModeParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_groups");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeManagedSettingsRbacGroupsModeParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeManagedSettingsRbacGroupsModeParamFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeManagedSettingsRbacGroupsModeParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeManagedSettingsRbacGroupsModeParamFromRaw
    : IFromRawJson<BetaClaudeCodeManagedSettingsRbacGroupsModeParam>
{
    /// <inheritdoc/>
    public BetaClaudeCodeManagedSettingsRbacGroupsModeParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeManagedSettingsRbacGroupsModeParam.FromRawUnchecked(rawData);
}
