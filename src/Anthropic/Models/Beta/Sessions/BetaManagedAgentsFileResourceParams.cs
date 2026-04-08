using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Mount a file uploaded via the Files API into the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileResourceParams,
        BetaManagedAgentsFileResourceParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileResourceParams : JsonModel
{
    /// <summary>
    /// ID of a previously uploaded file.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsFileResourceParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileResourceParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Mount path in the container. Defaults to `/mnt/session/uploads/&lt;file_id&gt;`.
    /// </summary>
    public string? MountPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mount_path");
        }
        init { this._rawData.Set("mount_path", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        this.Type.Validate();
        _ = this.MountPath;
    }

    public BetaManagedAgentsFileResourceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileResourceParams(
        BetaManagedAgentsFileResourceParams betaManagedAgentsFileResourceParams
    )
        : base(betaManagedAgentsFileResourceParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileResourceParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileResourceParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileResourceParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileResourceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileResourceParamsFromRaw : IFromRawJson<BetaManagedAgentsFileResourceParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileResourceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileResourceParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileResourceParamsTypeConverter))]
public enum BetaManagedAgentsFileResourceParamsType
{
    File,
}

sealed class BetaManagedAgentsFileResourceParamsTypeConverter
    : JsonConverter<BetaManagedAgentsFileResourceParamsType>
{
    public override BetaManagedAgentsFileResourceParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => BetaManagedAgentsFileResourceParamsType.File,
            _ => (BetaManagedAgentsFileResourceParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileResourceParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileResourceParamsType.File => "file",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
