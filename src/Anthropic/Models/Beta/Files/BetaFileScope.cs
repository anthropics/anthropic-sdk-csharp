using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Files;

[JsonConverter(typeof(JsonModelConverter<BetaFileScope, BetaFileScopeFromRaw>))]
public sealed record class BetaFileScope : JsonModel
{
    /// <summary>
    /// The ID of the scoping resource (e.g., the session ID).
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
    /// The type of scope (e.g., `"session"`).
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

    public BetaFileScope()
    {
        this.Type = JsonSerializer.SerializeToElement("session");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFileScope(BetaFileScope betaFileScope)
        : base(betaFileScope) { }
#pragma warning restore CS8618

    public BetaFileScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFileScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFileScopeFromRaw.FromRawUnchecked"/>
    public static BetaFileScope FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFileScope(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaFileScopeFromRaw : IFromRawJson<BetaFileScope>
{
    /// <inheritdoc/>
    public BetaFileScope FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFileScope.FromRawUnchecked(rawData);
}
