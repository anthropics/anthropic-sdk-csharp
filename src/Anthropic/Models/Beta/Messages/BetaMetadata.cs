using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaMetadata, BetaMetadataFromRaw>))]
public sealed record class BetaMetadata : JsonModel
{
    /// <summary>
    /// An external identifier for the user who is associated with the request.
    ///
    /// <para>This should be a uuid, hash value, or other opaque identifier. Anthropic
    /// may use this id to help detect abuse. Do not include any identifying information
    /// such as name, email address, or phone number.</para>
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
    }

    public BetaMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMetadata(BetaMetadata betaMetadata)
        : base(betaMetadata) { }
#pragma warning restore CS8618

    public BetaMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMetadataFromRaw.FromRawUnchecked"/>
    public static BetaMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMetadataFromRaw : IFromRawJson<BetaMetadata>
{
    /// <inheritdoc/>
    public BetaMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMetadata.FromRawUnchecked(rawData);
}
