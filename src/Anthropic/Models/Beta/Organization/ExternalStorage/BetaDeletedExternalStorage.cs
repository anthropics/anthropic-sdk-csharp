using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

[JsonConverter(
    typeof(JsonModelConverter<BetaDeletedExternalStorage, BetaDeletedExternalStorageFromRaw>)
)]
public sealed record class BetaDeletedExternalStorage : JsonModel
{
    /// <summary>
    /// The External Storage ID, which starts with `estrg_`. Through Claude Platform
    /// on AWS, storage whose `provider_config.type` is `aws` has its bucket ARN
    /// as its ID instead: `arn:&lt;partition&gt;:s3:::&lt;bucket_name&gt;`, where
    /// `&lt;partition&gt;` is the partition of the bucket's region.
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
                JsonSerializer.SerializeToElement("external_storage_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDeletedExternalStorage()
    {
        this.Type = JsonSerializer.SerializeToElement("external_storage_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedExternalStorage(BetaDeletedExternalStorage betaDeletedExternalStorage)
        : base(betaDeletedExternalStorage) { }
#pragma warning restore CS8618

    public BetaDeletedExternalStorage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_storage_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedExternalStorage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedExternalStorageFromRaw.FromRawUnchecked"/>
    public static BetaDeletedExternalStorage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDeletedExternalStorage(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDeletedExternalStorageFromRaw : IFromRawJson<BetaDeletedExternalStorage>
{
    /// <inheritdoc/>
    public BetaDeletedExternalStorage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDeletedExternalStorage.FromRawUnchecked(rawData);
}
