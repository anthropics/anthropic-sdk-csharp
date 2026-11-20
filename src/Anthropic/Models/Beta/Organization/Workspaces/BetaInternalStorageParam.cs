using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// No External Storage for this purpose.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaInternalStorageParam, BetaInternalStorageParamFromRaw>)
)]
public sealed record class BetaInternalStorageParam : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("internal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaInternalStorageParam()
    {
        this.Type = JsonSerializer.SerializeToElement("internal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInternalStorageParam(BetaInternalStorageParam betaInternalStorageParam)
        : base(betaInternalStorageParam) { }
#pragma warning restore CS8618

    public BetaInternalStorageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("internal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInternalStorageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInternalStorageParamFromRaw.FromRawUnchecked"/>
    public static BetaInternalStorageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInternalStorageParamFromRaw : IFromRawJson<BetaInternalStorageParam>
{
    /// <inheritdoc/>
    public BetaInternalStorageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInternalStorageParam.FromRawUnchecked(rawData);
}
