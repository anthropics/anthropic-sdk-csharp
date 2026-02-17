using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Information about the container used in the request (for the code execution tool)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Container, ContainerFromRaw>))]
public sealed record class Container : JsonModel
{
    /// <summary>
    /// Identifier for the container used in this request
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
    /// The time at which the container will expire.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpiresAt;
    }

    public Container() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Container(Container container)
        : base(container) { }
#pragma warning restore CS8618

    public Container(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Container(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContainerFromRaw.FromRawUnchecked"/>
    public static Container FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContainerFromRaw : IFromRawJson<Container>
{
    /// <inheritdoc/>
    public Container FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Container.FromRawUnchecked(rawData);
}
