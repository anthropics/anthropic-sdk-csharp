using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Names one tool in an only or except list.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSourceToolReference,
        BetaManagedAgentsWebFetchUrlSourceToolReferenceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSourceToolReference : JsonModel
{
    /// <summary>
    /// Name of the tool. Compared exactly, so upper and lower case letters are different.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Must be "tool_reference".
    /// </summary>
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

    public BetaManagedAgentsWebFetchUrlSourceToolReference()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceToolReference(
        BetaManagedAgentsWebFetchUrlSourceToolReference betaManagedAgentsWebFetchUrlSourceToolReference
    )
        : base(betaManagedAgentsWebFetchUrlSourceToolReference) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSourceToolReference(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSourceToolReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourceToolReferenceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSourceToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceToolReference(string name)
        : this()
    {
        this.Name = name;
    }
}

class BetaManagedAgentsWebFetchUrlSourceToolReferenceFromRaw
    : IFromRawJson<BetaManagedAgentsWebFetchUrlSourceToolReference>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSourceToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSourceToolReference.FromRawUnchecked(rawData);
}
