using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// No bucket is set for this region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageRegionNotConfigured,
        BetaGoogleManagedStorageRegionNotConfiguredFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageRegionNotConfigured : JsonModel
{
    /// <summary>
    /// The bucket that the region applies now. While a replacement bucket is `pending`
    /// or `failed`, this is the previous bucket. `null` when the region applies no bucket.
    /// </summary>
    public required BetaGoogleManagedBucketReference? EffectiveBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaGoogleManagedBucketReference>(
                "effective_bucket"
            );
        }
        init { this._rawData.Set("effective_bucket", value); }
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
        this.EffectiveBucket?.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("not_configured")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedStorageRegionNotConfigured()
    {
        this.Type = JsonSerializer.SerializeToElement("not_configured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageRegionNotConfigured(
        BetaGoogleManagedStorageRegionNotConfigured betaGoogleManagedStorageRegionNotConfigured
    )
        : base(betaGoogleManagedStorageRegionNotConfigured) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageRegionNotConfigured(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("not_configured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageRegionNotConfigured(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageRegionNotConfiguredFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageRegionNotConfigured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedStorageRegionNotConfigured(
        BetaGoogleManagedBucketReference? effectiveBucket
    )
        : this()
    {
        this.EffectiveBucket = effectiveBucket;
    }
}

class BetaGoogleManagedStorageRegionNotConfiguredFromRaw
    : IFromRawJson<BetaGoogleManagedStorageRegionNotConfigured>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageRegionNotConfigured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageRegionNotConfigured.FromRawUnchecked(rawData);
}
