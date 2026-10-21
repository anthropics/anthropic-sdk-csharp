using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// A precondition that applies an update only if the memory's current content has
/// the hash in `content_sha256`.
///
/// <para>If the hashes differ, the request fails with HTTP status 409. Retrieve
/// the memory and retry. If the memory already has exactly the requested `content`
/// and `path`, the request succeeds even though the hashes differ.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsContentSha256Precondition,
        BetaManagedAgentsContentSha256PreconditionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsContentSha256Precondition : JsonModel
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

    /// <summary>
    /// Expected `content_sha256` of the stored memory (64 lowercase hexadecimal characters).
    /// Typically the `content_sha256` returned by a prior read or list call. Because
    /// the server applies no content normalization, clients can also compute this
    /// locally as the SHA-256 of the UTF-8 content bytes.
    /// </summary>
    public string? ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_sha256");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("content_sha256");
                return;
            }

            this._rawData.Set("content_sha256", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("content_sha256")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ContentSha256;
    }

    public BetaManagedAgentsContentSha256Precondition()
    {
        this.Type = JsonSerializer.SerializeToElement("content_sha256");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsContentSha256Precondition(
        BetaManagedAgentsContentSha256Precondition betaManagedAgentsContentSha256Precondition
    )
        : base(betaManagedAgentsContentSha256Precondition) { }
#pragma warning restore CS8618

    public BetaManagedAgentsContentSha256Precondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content_sha256");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsContentSha256Precondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsContentSha256PreconditionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsContentSha256Precondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsContentSha256PreconditionFromRaw
    : IFromRawJson<BetaManagedAgentsContentSha256Precondition>
{
    /// <inheritdoc/>
    public BetaManagedAgentsContentSha256Precondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsContentSha256Precondition.FromRawUnchecked(rawData);
}
