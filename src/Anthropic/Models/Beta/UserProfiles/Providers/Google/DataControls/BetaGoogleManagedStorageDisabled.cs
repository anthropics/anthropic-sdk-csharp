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
/// The control is off and has no buckets.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageDisabled,
        BetaGoogleManagedStorageDisabledFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageDisabled : JsonModel
{
    /// <summary>
    /// Buckets that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedRetiredBucket> RetiredBuckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaGoogleManagedRetiredBucket>>(
                "retired_buckets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedRetiredBucket>>(
                "retired_buckets",
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
        foreach (var item in this.RetiredBuckets)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedStorageDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageDisabled(
        BetaGoogleManagedStorageDisabled betaGoogleManagedStorageDisabled
    )
        : base(betaGoogleManagedStorageDisabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageDisabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedStorageDisabled(
        IReadOnlyList<BetaGoogleManagedRetiredBucket> retiredBuckets
    )
        : this()
    {
        this.RetiredBuckets = retiredBuckets;
    }
}

class BetaGoogleManagedStorageDisabledFromRaw : IFromRawJson<BetaGoogleManagedStorageDisabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageDisabled.FromRawUnchecked(rawData);
}
