using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Claude Tag settings. Without `include_inherited`, a setting that is null is not
/// set on the settings level and is inherited. With it, `enabled` and `guest_policy`
/// are never null, and `instructions`, `model` and `environment_id` are null when
/// no settings level sets them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaClaudeTagSettings, BetaClaudeTagSettingsFromRaw>))]
public sealed record class BetaClaudeTagSettings : JsonModel
{
    /// <summary>
    /// Whether Claude is on. The nearest settings level that sets it decides.
    /// </summary>
    public required bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// The environment Claude's sessions run in, starting with `env_`, or the identifier
    /// of a self-hosted runner pool, starting with `ccpool_`. The nearest settings
    /// level that sets it decides.
    /// </summary>
    public required string? EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment_id");
        }
        init { this._rawData.Set("environment_id", value); }
    }

    /// <summary>
    /// What Claude does in a channel while a Slack guest is in it. The nearest settings
    /// level that sets it decides.
    /// </summary>
    public required BetaClaudeTagGuestPolicy? GuestPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaClaudeTagGuestPolicy>("guest_policy");
        }
        init { this._rawData.Set("guest_policy", value); }
    }

    /// <summary>
    /// Instructions for Claude. Instructions add up: the text of every settings level
    /// that sets it is joined, broadest first.
    /// </summary>
    public required string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// The model Claude uses: a model identifier or the name of a model line. The
    /// nearest settings level that sets it decides. When none does, Claude uses the
    /// product's default model.
    /// </summary>
    public required string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.EnvironmentID;
        this.GuestPolicy?.Validate();
        _ = this.Instructions;
        _ = this.Model;
    }

    public BetaClaudeTagSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSettings(BetaClaudeTagSettings betaClaudeTagSettings)
        : base(betaClaudeTagSettings) { }
#pragma warning restore CS8618

    public BetaClaudeTagSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSettingsFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSettingsFromRaw : IFromRawJson<BetaClaudeTagSettings>
{
    /// <inheritdoc/>
    public BetaClaudeTagSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSettings.FromRawUnchecked(rawData);
}
