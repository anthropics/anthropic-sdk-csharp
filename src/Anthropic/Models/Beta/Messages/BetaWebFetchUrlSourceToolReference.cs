using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// One entry of a tool filter's ``tools``: it must name a tool declared in this request's ``tools[]``.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaWebFetchUrlSourceToolReference,
        BetaWebFetchUrlSourceToolReferenceFromRaw
    >)
)]
public sealed record class BetaWebFetchUrlSourceToolReference : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_reference")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchUrlSourceToolReference()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceToolReference(
        BetaWebFetchUrlSourceToolReference betaWebFetchUrlSourceToolReference
    )
        : base(betaWebFetchUrlSourceToolReference) { }
#pragma warning restore CS8618

    public BetaWebFetchUrlSourceToolReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchUrlSourceToolReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchUrlSourceToolReferenceFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchUrlSourceToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceToolReference(string name)
        : this()
    {
        this.Name = name;
    }
}

class BetaWebFetchUrlSourceToolReferenceFromRaw : IFromRawJson<BetaWebFetchUrlSourceToolReference>
{
    /// <inheritdoc/>
    public BetaWebFetchUrlSourceToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchUrlSourceToolReference.FromRawUnchecked(rawData);
}
