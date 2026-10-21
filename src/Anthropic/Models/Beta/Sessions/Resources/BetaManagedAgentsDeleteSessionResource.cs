using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Resources;

/// <summary>
/// Confirmation of resource deletion.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeleteSessionResource,
        BetaManagedAgentsDeleteSessionResourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeleteSessionResource : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("session_resource_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeleteSessionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("session_resource_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeleteSessionResource(
        BetaManagedAgentsDeleteSessionResource betaManagedAgentsDeleteSessionResource
    )
        : base(betaManagedAgentsDeleteSessionResource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeleteSessionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_resource_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeleteSessionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeleteSessionResourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeleteSessionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsDeleteSessionResource(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsDeleteSessionResourceFromRaw
    : IFromRawJson<BetaManagedAgentsDeleteSessionResource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeleteSessionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeleteSessionResource.FromRawUnchecked(rawData);
}
