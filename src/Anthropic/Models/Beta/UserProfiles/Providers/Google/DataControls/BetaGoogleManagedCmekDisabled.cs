using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// The control is off and has no keys.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaGoogleManagedCmekDisabled, BetaGoogleManagedCmekDisabledFromRaw>)
)]
public sealed record class BetaGoogleManagedCmekDisabled : JsonModel
{
    /// <summary>
    /// Keys that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedRetiredKey> RetiredKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaGoogleManagedRetiredKey>>(
                "retired_keys"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedRetiredKey>>(
                "retired_keys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
        foreach (var item in this.RetiredKeys)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedCmekDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedCmekDisabled(
        BetaGoogleManagedCmekDisabled betaGoogleManagedCmekDisabled
    )
        : base(betaGoogleManagedCmekDisabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedCmekDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedCmekDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedCmekDisabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedCmekDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedCmekDisabled(IReadOnlyList<BetaGoogleManagedRetiredKey> retiredKeys)
        : this()
    {
        this.RetiredKeys = retiredKeys;
    }
}

class BetaGoogleManagedCmekDisabledFromRaw : IFromRawJson<BetaGoogleManagedCmekDisabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedCmekDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedCmekDisabled.FromRawUnchecked(rawData);
}
