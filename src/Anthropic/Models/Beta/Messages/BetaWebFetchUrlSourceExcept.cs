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
/// The tool filter variant under which every result but the named tools' contributes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaWebFetchUrlSourceExcept, BetaWebFetchUrlSourceExceptFromRaw>)
)]
public sealed record class BetaWebFetchUrlSourceExcept : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("except")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchUrlSourceExcept()
    {
        this.Type = JsonSerializer.SerializeToElement("except");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceExcept(BetaWebFetchUrlSourceExcept betaWebFetchUrlSourceExcept)
        : base(betaWebFetchUrlSourceExcept) { }
#pragma warning restore CS8618

    public BetaWebFetchUrlSourceExcept(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("except");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchUrlSourceExcept(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchUrlSourceExceptFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchUrlSourceExcept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceExcept(IReadOnlyList<BetaWebFetchUrlSourceToolReference> tools)
        : this()
    {
        this.Tools = tools;
    }
}

class BetaWebFetchUrlSourceExceptFromRaw : IFromRawJson<BetaWebFetchUrlSourceExcept>
{
    /// <inheritdoc/>
    public BetaWebFetchUrlSourceExcept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchUrlSourceExcept.FromRawUnchecked(rawData);
}
