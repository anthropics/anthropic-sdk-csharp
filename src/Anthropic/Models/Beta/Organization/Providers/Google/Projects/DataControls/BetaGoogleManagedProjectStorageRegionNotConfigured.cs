using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// No bucket is set for this region.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageRegionNotConfigured,
        BetaGoogleManagedProjectStorageRegionNotConfiguredFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageRegionNotConfigured : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("not_configured")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedProjectStorageRegionNotConfigured()
    {
        this.Type = JsonSerializer.SerializeToElement("not_configured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageRegionNotConfigured(
        BetaGoogleManagedProjectStorageRegionNotConfigured betaGoogleManagedProjectStorageRegionNotConfigured
    )
        : base(betaGoogleManagedProjectStorageRegionNotConfigured) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageRegionNotConfigured(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("not_configured");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageRegionNotConfigured(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageRegionNotConfiguredFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageRegionNotConfigured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageRegionNotConfigured(
        BetaGoogleManagedProjectEffectiveBucket? effectiveBucket
    )
        : this()
    {
        this.EffectiveBucket = effectiveBucket;
    }
}

class BetaGoogleManagedProjectStorageRegionNotConfiguredFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageRegionNotConfigured>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageRegionNotConfigured FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageRegionNotConfigured.FromRawUnchecked(rawData);
}
