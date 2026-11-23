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
[JsonConverter(typeof(JsonModelConverter<BetaInternalStorage, BetaInternalStorageFromRaw>))]
public sealed record class BetaInternalStorage : JsonModel
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

    public BetaInternalStorage()
    {
        this.Type = JsonSerializer.SerializeToElement("internal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInternalStorage(BetaInternalStorage betaInternalStorage)
        : base(betaInternalStorage) { }
#pragma warning restore CS8618

    public BetaInternalStorage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("internal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInternalStorage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInternalStorageFromRaw.FromRawUnchecked"/>
    public static BetaInternalStorage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInternalStorageFromRaw : IFromRawJson<BetaInternalStorage>
{
    /// <inheritdoc/>
    public BetaInternalStorage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaInternalStorage.FromRawUnchecked(rawData);
}
