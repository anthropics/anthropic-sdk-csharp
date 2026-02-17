using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DirectCaller, DirectCallerFromRaw>))]
public sealed record class DirectCaller : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("direct")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public DirectCaller()
    {
        this.Type = JsonSerializer.SerializeToElement("direct");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirectCaller(DirectCaller directCaller)
        : base(directCaller) { }
#pragma warning restore CS8618

    public DirectCaller(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("direct");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DirectCaller(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DirectCallerFromRaw.FromRawUnchecked"/>
    public static DirectCaller FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DirectCallerFromRaw : IFromRawJson<DirectCaller>
{
    /// <inheritdoc/>
    public DirectCaller FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DirectCaller.FromRawUnchecked(rawData);
}
