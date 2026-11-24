using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// Turns the control off and removes every region's bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageDisabledParams,
        BetaGoogleManagedStorageDisabledParamsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageDisabledParams : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGoogleManagedStorageDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageDisabledParams(
        BetaGoogleManagedStorageDisabledParams betaGoogleManagedStorageDisabledParams
    )
        : base(betaGoogleManagedStorageDisabledParams) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageDisabledParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageDisabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageDisabledParamsFromRaw
    : IFromRawJson<BetaGoogleManagedStorageDisabledParams>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageDisabledParams.FromRawUnchecked(rawData);
}
