using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Request to update work item metadata.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSelfHostedWorkUpdateRequest,
        BetaSelfHostedWorkUpdateRequestFromRaw
    >)
)]
public sealed record class BetaSelfHostedWorkUpdateRequest : JsonModel
{
    /// <summary>
    /// Metadata patch. Set a key to a string to upsert it, or to null to delete
    /// it. Omit the field to preserve existing metadata.
    /// </summary>
    public required IReadOnlyDictionary<string, string?> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Metadata;
    }

    public BetaSelfHostedWorkUpdateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedWorkUpdateRequest(
        BetaSelfHostedWorkUpdateRequest betaSelfHostedWorkUpdateRequest
    )
        : base(betaSelfHostedWorkUpdateRequest) { }
#pragma warning restore CS8618

    public BetaSelfHostedWorkUpdateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedWorkUpdateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedWorkUpdateRequestFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedWorkUpdateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSelfHostedWorkUpdateRequest(IReadOnlyDictionary<string, string?> metadata)
        : this()
    {
        this.Metadata = metadata;
    }
}

class BetaSelfHostedWorkUpdateRequestFromRaw : IFromRawJson<BetaSelfHostedWorkUpdateRequest>
{
    /// <inheritdoc/>
    public BetaSelfHostedWorkUpdateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedWorkUpdateRequest.FromRawUnchecked(rawData);
}
