using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// For each setting, the settings level its value in `settings` comes from. Without
/// `include_inherited`, a setting the channel or workspace stores has a source that
/// names the channel or workspace itself, and one it does not store has null, or
/// an empty list for `instructions`. With `include_inherited=true` no member is
/// null: a value that no settings level sets has the source `default`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaClaudeTagSettingSources, BetaClaudeTagSettingSourcesFromRaw>)
)]
public sealed record class BetaClaudeTagSettingSources : JsonModel
{
    /// <summary>
    /// The settings level `enabled` comes from.
    /// </summary>
    public required BetaClaudeTagSettingSource? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaClaudeTagSettingSource>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// The settings level `environment_id` comes from.
    /// </summary>
    public required BetaClaudeTagSettingSource? EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaClaudeTagSettingSource>("environment_id");
        }
        init { this._rawData.Set("environment_id", value); }
    }

    /// <summary>
    /// The settings level `guest_policy` comes from.
    /// </summary>
    public required BetaClaudeTagSettingSource? GuestPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaClaudeTagSettingSource>("guest_policy");
        }
        init { this._rawData.Set("guest_policy", value); }
    }

    /// <summary>
    /// Every settings level that contributes text to `instructions`, broadest first,
    /// in the order their text is joined. Empty when none does.
    /// </summary>
    public required IReadOnlyList<BetaClaudeTagSettingSource> Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaClaudeTagSettingSource>>(
                "instructions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaClaudeTagSettingSource>>(
                "instructions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The settings level `model` comes from.
    /// </summary>
    public required BetaClaudeTagSettingSource? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaClaudeTagSettingSource>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Enabled?.Validate();
        this.EnvironmentID?.Validate();
        this.GuestPolicy?.Validate();
        foreach (var item in this.Instructions)
        {
            item.Validate();
        }
        this.Model?.Validate();
    }

    public BetaClaudeTagSettingSources() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSettingSources(BetaClaudeTagSettingSources betaClaudeTagSettingSources)
        : base(betaClaudeTagSettingSources) { }
#pragma warning restore CS8618

    public BetaClaudeTagSettingSources(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSettingSources(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSettingSourcesFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSettingSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSettingSourcesFromRaw : IFromRawJson<BetaClaudeTagSettingSources>
{
    /// <inheritdoc/>
    public BetaClaudeTagSettingSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSettingSources.FromRawUnchecked(rawData);
}
