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
/// The control is off and has no buckets.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageDisabled,
        BetaGoogleManagedProjectStorageDisabledFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageDisabled : JsonModel
{
    /// <summary>
    /// Buckets that a region has retired, earliest `expires_at` first.
    /// </summary>
    public required IReadOnlyList<BetaGoogleManagedProjectRetiredBucket> RetiredBuckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaGoogleManagedProjectRetiredBucket>
            >("retired_buckets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaGoogleManagedProjectRetiredBucket>>(
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

    public BetaGoogleManagedProjectStorageDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageDisabled(
        BetaGoogleManagedProjectStorageDisabled betaGoogleManagedProjectStorageDisabled
    )
        : base(betaGoogleManagedProjectStorageDisabled) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageDisabledFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageDisabled(
        IReadOnlyList<BetaGoogleManagedProjectRetiredBucket> retiredBuckets
    )
        : this()
    {
        this.RetiredBuckets = retiredBuckets;
    }
}

class BetaGoogleManagedProjectStorageDisabledFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageDisabled>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageDisabled.FromRawUnchecked(rawData);
}
