using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The browser toolset: a single ``tools[]`` entry (carrying no ``name``) that declares
/// the browser tool family. The model is served the family's tool with any members
/// disabled via ``configs`` removed from its schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserToolset20260801, BrowserToolset20260801FromRaw>))]
public sealed record class BrowserToolset20260801 : JsonModel
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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Sparse per-member overrides, keyed by member name. Absent, null, and {} are
    /// equivalent; a member's defaults apply wherever its key is absent.
    /// </summary>
    public BrowserToolsetConfigs? Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserToolsetConfigs>("configs");
        }
        init { this._rawData.Set("configs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("browser_toolset_20260801")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Configs?.Validate();
    }

    public BrowserToolset20260801()
    {
        this.Type = JsonSerializer.SerializeToElement("browser_toolset_20260801");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserToolset20260801(BrowserToolset20260801 browserToolset20260801)
        : base(browserToolset20260801) { }
#pragma warning restore CS8618

    public BrowserToolset20260801(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("browser_toolset_20260801");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserToolset20260801(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserToolset20260801FromRaw.FromRawUnchecked"/>
    public static BrowserToolset20260801 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserToolset20260801FromRaw : IFromRawJson<BrowserToolset20260801>
{
    /// <inheritdoc/>
    public BrowserToolset20260801 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserToolset20260801.FromRawUnchecked(rawData);
}
