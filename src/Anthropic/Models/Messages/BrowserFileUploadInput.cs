using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Set the value of a file-input element to one or more files. The target must be
/// an element reference; at least one of paths or document_ids is required.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserFileUploadInput, BrowserFileUploadInputFromRaw>))]
public sealed record class BrowserFileUploadInput : JsonModel
{
    /// <summary>
    /// An element on the page, identified by a reference from a prior `read_page`
    /// or `find` result. References are scoped to the tab that produced them and
    /// become stale after navigation or a major re-render.
    /// </summary>
    public required BrowserRefTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserRefTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// References to files the harness has staged, for deployments where the browser
    /// executor cannot read the caller's filesystem.
    /// </summary>
    public IReadOnlyList<string>? DocumentIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("document_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "document_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// File paths on the browser executor's filesystem.
    /// </summary>
    public IReadOnlyList<string>? Paths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("paths");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "paths",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tab to act on. Defaults to the active tab when omitted.
    /// </summary>
    public string? TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Target.Validate();
        _ = this.DocumentIds;
        _ = this.Paths;
        _ = this.TabID;
    }

    public BrowserFileUploadInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserFileUploadInput(BrowserFileUploadInput browserFileUploadInput)
        : base(browserFileUploadInput) { }
#pragma warning restore CS8618

    public BrowserFileUploadInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserFileUploadInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFileUploadInputFromRaw.FromRawUnchecked"/>
    public static BrowserFileUploadInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserFileUploadInput(BrowserRefTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserFileUploadInputFromRaw : IFromRawJson<BrowserFileUploadInput>
{
    /// <inheritdoc/>
    public BrowserFileUploadInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserFileUploadInput.FromRawUnchecked(rawData);
}
