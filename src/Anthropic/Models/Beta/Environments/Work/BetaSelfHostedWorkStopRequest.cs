using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Request to stop a work item.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaSelfHostedWorkStopRequest, BetaSelfHostedWorkStopRequestFromRaw>)
)]
public sealed record class BetaSelfHostedWorkStopRequest : JsonModel
{
    /// <summary>
    /// If true, immediately stop work without graceful shutdown
    /// </summary>
    public bool? Force
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("force");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("force", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Force;
    }

    public BetaSelfHostedWorkStopRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedWorkStopRequest(
        BetaSelfHostedWorkStopRequest betaSelfHostedWorkStopRequest
    )
        : base(betaSelfHostedWorkStopRequest) { }
#pragma warning restore CS8618

    public BetaSelfHostedWorkStopRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedWorkStopRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedWorkStopRequestFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedWorkStopRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedWorkStopRequestFromRaw : IFromRawJson<BetaSelfHostedWorkStopRequest>
{
    /// <inheritdoc/>
    public BetaSelfHostedWorkStopRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedWorkStopRequest.FromRawUnchecked(rawData);
}
