using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// Turns the control off and removes every region's key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekDisabledParams,
        BetaGoogleManagedProjectCmekDisabledParamsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekDisabledParams : JsonModel
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

    public BetaGoogleManagedProjectCmekDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekDisabledParams(
        BetaGoogleManagedProjectCmekDisabledParams betaGoogleManagedProjectCmekDisabledParams
    )
        : base(betaGoogleManagedProjectCmekDisabledParams) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekDisabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekDisabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectCmekDisabledParamsFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekDisabledParams>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekDisabledParams.FromRawUnchecked(rawData);
}
