using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// Turns the control off and removes every region's key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedCmekDisabledParams,
        BetaGoogleManagedCmekDisabledParamsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedCmekDisabledParams : JsonModel
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

    public BetaGoogleManagedCmekDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedCmekDisabledParams(
        BetaGoogleManagedCmekDisabledParams betaGoogleManagedCmekDisabledParams
    )
        : base(betaGoogleManagedCmekDisabledParams) { }
#pragma warning restore CS8618

    public BetaGoogleManagedCmekDisabledParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedCmekDisabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedCmekDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedCmekDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedCmekDisabledParamsFromRaw : IFromRawJson<BetaGoogleManagedCmekDisabledParams>
{
    /// <inheritdoc/>
    public BetaGoogleManagedCmekDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedCmekDisabledParams.FromRawUnchecked(rawData);
}
