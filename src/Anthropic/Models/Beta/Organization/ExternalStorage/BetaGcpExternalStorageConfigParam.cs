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
    typeof(JsonModelConverter<
        BetaGcpExternalStorageConfigParam,
        BetaGcpExternalStorageConfigParamFromRaw
    >)
)]
public sealed record class BetaGcpExternalStorageConfigParam : JsonModel
{
    /// <summary>
    /// The bucket's name, without `gs://`: 3 to 63 lower-case letters, digits and
    /// hyphens, starting and ending with a letter or digit. It can't start with `goog`
    /// or contain `google`.
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
    /// Project number, not project ID, of the Google Cloud project that holds the bucket.
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
    /// The bucket's Google Cloud region, such as `us-east5`: one of the single regions
    /// that the setup guide lists. Dual-regions and multi-regions aren't supported.
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

    public BetaGcpExternalStorageConfigParam()
    {
        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGcpExternalStorageConfigParam(
        BetaGcpExternalStorageConfigParam betaGcpExternalStorageConfigParam
    )
        : base(betaGcpExternalStorageConfigParam) { }
#pragma warning restore CS8618

    public BetaGcpExternalStorageConfigParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGcpExternalStorageConfigParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGcpExternalStorageConfigParamFromRaw.FromRawUnchecked"/>
    public static BetaGcpExternalStorageConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGcpExternalStorageConfigParamFromRaw : IFromRawJson<BetaGcpExternalStorageConfigParam>
{
    /// <inheritdoc/>
    public BetaGcpExternalStorageConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGcpExternalStorageConfigParam.FromRawUnchecked(rawData);
}
