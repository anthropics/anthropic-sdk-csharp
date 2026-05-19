using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Work data for session work items.
///
/// <para>This resource type is used when work represents a session that needs to
/// be executed in a self-hosted environment.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSessionWorkData, BetaSessionWorkDataFromRaw>))]
public sealed record class BetaSessionWorkData : JsonModel
{
    /// <summary>
    /// Session identifier (e.g., 'session_...')
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
    /// Type of work data
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
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("session")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSessionWorkData()
    {
        this.Type = JsonSerializer.SerializeToElement("session");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSessionWorkData(BetaSessionWorkData betaSessionWorkData)
        : base(betaSessionWorkData) { }
#pragma warning restore CS8618

    public BetaSessionWorkData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSessionWorkData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSessionWorkDataFromRaw.FromRawUnchecked"/>
    public static BetaSessionWorkData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSessionWorkData(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaSessionWorkDataFromRaw : IFromRawJson<BetaSessionWorkData>
{
    /// <inheritdoc/>
    public BetaSessionWorkData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSessionWorkData.FromRawUnchecked(rawData);
}
