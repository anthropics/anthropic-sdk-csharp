using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Resources;

[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsFileResource, BetaManagedAgentsFileResourceFromRaw>)
)]
public sealed record class BetaManagedAgentsFileResource : JsonModel
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

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string MountPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mount_path");
        }
        init { this._rawData.Set("mount_path", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsFileResourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileResourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FileID;
        _ = this.MountPath;
        this.Type.Validate();
        _ = this.UpdatedAt;
    }

    public BetaManagedAgentsFileResource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileResource(
        BetaManagedAgentsFileResource betaManagedAgentsFileResource
    )
        : base(betaManagedAgentsFileResource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileResourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileResourceFromRaw : IFromRawJson<BetaManagedAgentsFileResource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileResource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileResourceTypeConverter))]
public enum BetaManagedAgentsFileResourceType
{
    File,
}

sealed class BetaManagedAgentsFileResourceTypeConverter
    : JsonConverter<BetaManagedAgentsFileResourceType>
{
    public override BetaManagedAgentsFileResourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => BetaManagedAgentsFileResourceType.File,
            _ => (BetaManagedAgentsFileResourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileResourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileResourceType.File => "file",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
