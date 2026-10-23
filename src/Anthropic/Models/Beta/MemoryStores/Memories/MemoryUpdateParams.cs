using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.MemoryStores;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// Update a Memory
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string MemoryStoreID { get; init; }

    public string? MemoryID { get; init; }

    /// <summary>
    /// Whether a `memory` or `memory_version` in the response includes its `content`.
    /// Defaults to `full` on retrieve operations and to `basic` on list, create,
    /// and update operations.
    ///
    /// <para>With `full`, list operations return at most 20 items per page.</para>
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsMemoryView>? View
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsMemoryView>
            >("view");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("view");
                return;
            }

            this._rawQueryData.Set("view", value);
        }
    }

    /// <summary>
    /// New UTF-8 text content for the memory. Maximum 100 kB (102,400 bytes). Omit
    /// to leave the content unchanged (e.g., for a rename-only update).
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("content");
        }
        init { this._rawBodyData.Set("content", value); }
    }

    /// <summary>
    /// The new path of the memory, which renames it. Omit it to keep the current path.
    ///
    /// <para>The memory keeps its `id`. A path starts with `/` and has 1 to 20 segments.
    /// A segment can't be empty and can't be `.` or `..`. A path can't contain control
    /// characters, format characters, or the line and paragraph separators U+2028
    /// and U+2029. It must be in Unicode Normalization Form C and at most 1,024
    /// bytes long. Paths are case-sensitive.</para>
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("path");
        }
        init { this._rawBodyData.Set("path", value); }
    }

    /// <summary>
    /// The condition that the memory must meet for the update to apply. Omit it
    /// to update unconditionally.
    ///
    /// <para>If the condition fails, the request fails with HTTP status 409.</para>
    /// </summary>
    public BetaManagedAgentsPrecondition? Precondition
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaManagedAgentsPrecondition>(
                "precondition"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("precondition");
                return;
            }

            this._rawBodyData.Set("precondition", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `agent-memory-2026-07-22` or
    /// `managed-agents-2026-04-01` in this header.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional header to select the Workspace for this request. The value is a Workspace
    /// ID (for example, `wrkspc_011CZkZaBF1tNoB5wlCeusgy`).
    ///
    /// <para>Only needed for credentials that can act on more than one Workspace.
    /// A credential that belongs to a specific Workspace may omit it; if sent, it
    /// must match that Workspace.</para>
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("anthropic-workspace-id");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-workspace-id");
                return;
            }

            this._rawHeaderData.Set("anthropic-workspace-id", value);
        }
    }

    public MemoryUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryUpdateParams(MemoryUpdateParams memoryUpdateParams)
        : base(memoryUpdateParams)
    {
        this.MemoryStoreID = memoryUpdateParams.MemoryStoreID;
        this.MemoryID = memoryUpdateParams.MemoryID;

        this._rawBodyData = new(memoryUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MemoryUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string memoryStoreID,
        string memoryID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.MemoryStoreID = memoryStoreID;
        this.MemoryID = memoryID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MemoryUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string memoryStoreID,
        string memoryID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            memoryStoreID,
            memoryID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MemoryStoreID"] = JsonSerializer.SerializeToElement(this.MemoryStoreID),
                    ["MemoryID"] = JsonSerializer.SerializeToElement(this.MemoryID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MemoryUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MemoryStoreID.Equals(other.MemoryStoreID)
            && (this.MemoryID?.Equals(other.MemoryID) ?? other.MemoryID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/memory_stores/{0}/memories/{1}",
                    ParamsBase.EncodePathSegment(this.MemoryStoreID, nameof(this.MemoryStoreID)),
                    ParamsBase.EncodePathSegment(this.MemoryID, nameof(this.MemoryID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/memory_stores/{memory_store_id}/memories/{memory_id}";

    internal override IReadOnlyList<string> QueryParams => ["view"];

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        MemoryService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
