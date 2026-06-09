using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A file mounted into each session's container.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileResourceConfig,
        BetaManagedAgentsFileResourceConfigFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileResourceConfig : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsFileResourceConfigType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileResourceConfigType>
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

    public BetaManagedAgentsFileResourceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileResourceConfig(
        BetaManagedAgentsFileResourceConfig betaManagedAgentsFileResourceConfig
    )
        : base(betaManagedAgentsFileResourceConfig) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileResourceConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileResourceConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileResourceConfigFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileResourceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileResourceConfigFromRaw : IFromRawJson<BetaManagedAgentsFileResourceConfig>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileResourceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileResourceConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileResourceConfigTypeConverter))]
public enum BetaManagedAgentsFileResourceConfigType
{
    File,
}

sealed class BetaManagedAgentsFileResourceConfigTypeConverter
    : JsonConverter<BetaManagedAgentsFileResourceConfigType>
{
    public override BetaManagedAgentsFileResourceConfigType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => BetaManagedAgentsFileResourceConfigType.File,
            _ => (BetaManagedAgentsFileResourceConfigType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileResourceConfigType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileResourceConfigType.File => "file",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
