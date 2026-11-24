using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The control is off and has no keys.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekDisabled,
        BetaGoogleManagedProjectCmekDisabledFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekDisabled : JsonModel
{
    /// <summary>
    /// Keys that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedProjectRetiredKey> RetiredKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaGoogleManagedProjectRetiredKey>
            >("retired_keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedProjectRetiredKey>>(
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

    public BetaGoogleManagedProjectCmekDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekDisabled(
        BetaGoogleManagedProjectCmekDisabled betaGoogleManagedProjectCmekDisabled
    )
        : base(betaGoogleManagedProjectCmekDisabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekDisabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekDisabled(
        IReadOnlyList<BetaGoogleManagedProjectRetiredKey> retiredKeys
    )
        : this()
    {
        this.RetiredKeys = retiredKeys;
    }
}

class BetaGoogleManagedProjectCmekDisabledFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekDisabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekDisabled.FromRawUnchecked(rawData);
}
