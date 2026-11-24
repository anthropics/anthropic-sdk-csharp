using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// Anthropic has withdrawn or paused its approval of customer-owned storage for this
/// project, so the region does not apply the control.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageRegionSuspended,
        BetaGoogleManagedProjectStorageRegionSuspendedFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageRegionSuspended : JsonModel
{
    /// <summary>
    /// The bucket that the region applies now. While a replacement bucket is `pending`
    /// or `failed`, this is the previous bucket. `null` when the region applies no bucket.
    /// </summary>
    public required BetaGoogleManagedProjectEffectiveBucket? EffectiveBucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaGoogleManagedProjectEffectiveBucket>(
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("suspended")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedProjectStorageRegionSuspended()
    {
        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageRegionSuspended(
        BetaGoogleManagedProjectStorageRegionSuspended betaGoogleManagedProjectStorageRegionSuspended
    )
        : base(betaGoogleManagedProjectStorageRegionSuspended) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageRegionSuspended(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("suspended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageRegionSuspended(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageRegionSuspendedFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageRegionSuspended(
        BetaGoogleManagedProjectEffectiveBucket? effectiveBucket
    )
        : this()
    {
        this.EffectiveBucket = effectiveBucket;
    }
}

class BetaGoogleManagedProjectStorageRegionSuspendedFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageRegionSuspended>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageRegionSuspended FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageRegionSuspended.FromRawUnchecked(rawData);
}
