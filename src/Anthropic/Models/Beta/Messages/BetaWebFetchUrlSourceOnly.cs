using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The tool filter variant under which only the named tools' results contribute.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaWebFetchUrlSourceOnly, BetaWebFetchUrlSourceOnlyFromRaw>)
)]
public sealed record class BetaWebFetchUrlSourceOnly : JsonModel
{
    public required IReadOnlyList<BetaWebFetchUrlSourceToolReference> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaWebFetchUrlSourceToolReference>
            >("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaWebFetchUrlSourceToolReference>>(
                "tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tools)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("only")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchUrlSourceOnly()
    {
        this.Type = JsonSerializer.SerializeToElement("only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceOnly(BetaWebFetchUrlSourceOnly betaWebFetchUrlSourceOnly)
        : base(betaWebFetchUrlSourceOnly) { }
#pragma warning restore CS8618

    public BetaWebFetchUrlSourceOnly(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchUrlSourceOnly(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchUrlSourceOnlyFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchUrlSourceOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceOnly(IReadOnlyList<BetaWebFetchUrlSourceToolReference> tools)
        : this()
    {
        this.Tools = tools;
    }
}

class BetaWebFetchUrlSourceOnlyFromRaw : IFromRawJson<BetaWebFetchUrlSourceOnly>
{
    /// <inheritdoc/>
    public BetaWebFetchUrlSourceOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchUrlSourceOnly.FromRawUnchecked(rawData);
}
