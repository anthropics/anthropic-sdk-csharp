using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BetaManagedAgentsDeleteSessionResource() { }

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
}

class BetaManagedAgentsDeleteSessionResourceFromRaw
    : IFromRawJson<BetaManagedAgentsDeleteSessionResource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeleteSessionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeleteSessionResource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeleteSessionResourceTypeConverter))]
public enum BetaManagedAgentsDeleteSessionResourceType
{
    SessionResourceDeleted,
}

sealed class BetaManagedAgentsDeleteSessionResourceTypeConverter
    : JsonConverter<BetaManagedAgentsDeleteSessionResourceType>
{
    public override BetaManagedAgentsDeleteSessionResourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_resource_deleted" =>
                BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted,
            _ => (BetaManagedAgentsDeleteSessionResourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeleteSessionResourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted =>
                    "session_resource_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
