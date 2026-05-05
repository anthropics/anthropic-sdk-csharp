using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Threads;

/// <summary>
/// Paginated list of threads within a `session`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThreadListPageResponse, ThreadListPageResponseFromRaw>))]
public sealed record class ThreadListPageResponse : JsonModel
{
    /// <summary>
    /// Threads in the session, primary first then children in spawn order.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsSessionThread>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsSessionThread>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionThread>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page. Null when no more results.
    /// </summary>
    public string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public ThreadListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadListPageResponse(ThreadListPageResponse threadListPageResponse)
        : base(threadListPageResponse) { }
#pragma warning restore CS8618

    public ThreadListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThreadListPageResponseFromRaw.FromRawUnchecked"/>
    public static ThreadListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThreadListPageResponseFromRaw : IFromRawJson<ThreadListPageResponse>
{
    /// <inheritdoc/>
    public ThreadListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThreadListPageResponse.FromRawUnchecked(rawData);
}
