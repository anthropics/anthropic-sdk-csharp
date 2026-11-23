using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// An Amazon S3 bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAwsExternalStorageConfig, BetaAwsExternalStorageConfigFromRaw>)
)]
public sealed record class BetaAwsExternalStorageConfig : JsonModel
{
    /// <summary>
    /// 12-digit ID of the AWS account that owns the bucket.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The bucket's name, without `s3://`.
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
    /// The bucket's AWS region.
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
        _ = this.AccountID;
        _ = this.BucketName;
        _ = this.Region;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("aws")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAwsExternalStorageConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAwsExternalStorageConfig(BetaAwsExternalStorageConfig betaAwsExternalStorageConfig)
        : base(betaAwsExternalStorageConfig) { }
#pragma warning restore CS8618

    public BetaAwsExternalStorageConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAwsExternalStorageConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAwsExternalStorageConfigFromRaw.FromRawUnchecked"/>
    public static BetaAwsExternalStorageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAwsExternalStorageConfigFromRaw : IFromRawJson<BetaAwsExternalStorageConfig>
{
    /// <inheritdoc/>
    public BetaAwsExternalStorageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAwsExternalStorageConfig.FromRawUnchecked(rawData);
}
