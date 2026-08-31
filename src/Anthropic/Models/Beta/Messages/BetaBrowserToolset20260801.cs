using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The browser toolset: a single ``tools[]`` entry (carrying no ``name``) that declares
/// the browser tool family. The model is served the family's tool with any members
/// disabled via ``configs`` removed from its schema.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserToolset20260801, BetaBrowserToolset20260801FromRaw>)
)]
public sealed record class BetaBrowserToolset20260801 : JsonModel
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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Per-member configuration for ``browser_toolset_20260801``: one optional field
    /// per member tool, keyed by the member name — the same name the member's ``tool_use``
    /// blocks carry. Every member is an accepted key, and a member's defaults apply
    /// wherever its key is absent. Unknown keys are rejected: the field set is this
    /// toolset version's complete member set.
    /// </summary>
    public BetaBrowserToolsetConfigs? Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserToolsetConfigs>("configs");
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

    public BetaBrowserToolset20260801()
    {
        this.Type = JsonSerializer.SerializeToElement("browser_toolset_20260801");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserToolset20260801(BetaBrowserToolset20260801 betaBrowserToolset20260801)
        : base(betaBrowserToolset20260801) { }
#pragma warning restore CS8618

    public BetaBrowserToolset20260801(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("browser_toolset_20260801");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserToolset20260801(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserToolset20260801FromRaw.FromRawUnchecked"/>
    public static BetaBrowserToolset20260801 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserToolset20260801FromRaw : IFromRawJson<BetaBrowserToolset20260801>
{
    /// <inheritdoc/>
    public BetaBrowserToolset20260801 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserToolset20260801.FromRawUnchecked(rawData);
}
