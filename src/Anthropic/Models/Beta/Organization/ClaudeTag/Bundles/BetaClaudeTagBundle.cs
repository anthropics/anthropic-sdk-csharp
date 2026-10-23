using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles;

/// <summary>
/// A named set of access that Claude can use in a Slack channel or a Slack workspace:
/// connectors, repositories and credentials. Created and edited in claude.ai.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaClaudeTagBundle, BetaClaudeTagBundleFromRaw>))]
public sealed record class BetaClaudeTagBundle : JsonModel
{
    /// <summary>
    /// The Bundle's identifier. Starts with `capp_`.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Time the Bundle was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// What the Bundle is for. Null when it has none. Read-only.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The Bundle's name. Always set. Read-only.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

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
    /// Time of the last change to the Bundle.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("bundle")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaClaudeTagBundle()
    {
        this.Type = JsonSerializer.SerializeToElement("bundle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagBundle(BetaClaudeTagBundle betaClaudeTagBundle)
        : base(betaClaudeTagBundle) { }
#pragma warning restore CS8618

    public BetaClaudeTagBundle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bundle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagBundle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagBundleFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagBundleFromRaw : IFromRawJson<BetaClaudeTagBundle>
{
    /// <inheritdoc/>
    public BetaClaudeTagBundle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaClaudeTagBundle.FromRawUnchecked(rawData);
}
