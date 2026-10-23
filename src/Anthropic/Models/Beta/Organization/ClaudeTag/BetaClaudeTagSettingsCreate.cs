using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The settings in a request that sets a Slack channel up. A setting left out is
/// not set. A setting sent as null is cleared.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaClaudeTagSettingsCreate, BetaClaudeTagSettingsCreateFromRaw>)
)]
public sealed record class BetaClaudeTagSettingsCreate : JsonModel
{
    /// <summary>
    /// Whether Claude is on. `true` on a channel turns Claude on in it even when
    /// its workspace stores `false`. Null clears it.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// The environment Claude's sessions run in: the identifier of an active environment
    /// of the organization, starting with `env_`. Null clears it.
    /// </summary>
    public string? EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment_id");
        }
        init { this._rawData.Set("environment_id", value); }
    }

    /// <summary>
    /// What Claude does in a channel while a Slack guest is in it. Null clears it.
    /// </summary>
    public BetaClaudeTagGuestPolicy? GuestPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaClaudeTagGuestPolicy>("guest_policy");
        }
        init { this._rawData.Set("guest_policy", value); }
    }

    /// <summary>
    /// Instructions for Claude, up to 8,192 characters after leading and trailing
    /// white space is trimmed. Null or blank text clears them.
    /// </summary>
    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// The model Claude uses: the identifier of a model, or the name of a model line,
    /// that the organization is entitled to for Claude Tag. Null clears it.
    /// </summary>
    public string? Model
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

    public BetaClaudeTagSettingsCreate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSettingsCreate(BetaClaudeTagSettingsCreate betaClaudeTagSettingsCreate)
        : base(betaClaudeTagSettingsCreate) { }
#pragma warning restore CS8618

    public BetaClaudeTagSettingsCreate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSettingsCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSettingsCreateFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSettingsCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSettingsCreateFromRaw : IFromRawJson<BetaClaudeTagSettingsCreate>
{
    /// <inheritdoc/>
    public BetaClaudeTagSettingsCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSettingsCreate.FromRawUnchecked(rawData);
}
