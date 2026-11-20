using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// A Google Cloud Storage bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaGcpExternalStorageConfig, BetaGcpExternalStorageConfigFromRaw>)
)]
public sealed record class BetaGcpExternalStorageConfig : JsonModel
{
    /// <summary>
    /// The bucket's name, without `gs://`.
    /// </summary>
    public required string BucketName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket_name");
        }
        init { this._rawData.Set("bucket_name", value); }
    }

    /// <summary>
    /// Number of the Google Cloud project that holds the bucket.
    /// </summary>
    public required string ProjectNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_number");
        }
        init { this._rawData.Set("project_number", value); }
    }

    /// <summary>
    /// The bucket's Google Cloud region.
    /// </summary>
    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
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
        _ = this.BucketName;
        _ = this.ProjectNumber;
        _ = this.Region;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("gcp")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGcpExternalStorageConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGcpExternalStorageConfig(BetaGcpExternalStorageConfig betaGcpExternalStorageConfig)
        : base(betaGcpExternalStorageConfig) { }
#pragma warning restore CS8618

    public BetaGcpExternalStorageConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGcpExternalStorageConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGcpExternalStorageConfigFromRaw.FromRawUnchecked"/>
    public static BetaGcpExternalStorageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGcpExternalStorageConfigFromRaw : IFromRawJson<BetaGcpExternalStorageConfig>
{
    /// <inheritdoc/>
    public BetaGcpExternalStorageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGcpExternalStorageConfig.FromRawUnchecked(rawData);
}
