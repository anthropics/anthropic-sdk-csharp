using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

[JsonConverter(typeof(JsonModelConverter<AwsExternalKeyConfig, AwsExternalKeyConfigFromRaw>))]
public sealed record class AwsExternalKeyConfig : JsonModel
{
    /// <summary>
    /// Full ARN of the AWS KMS key. On Claude Platform on AWS the key must be a single-Region
    /// key in your organization's own AWS account; cross-account keys, multi-Region
    /// keys, and alias ARNs are rejected.
    /// </summary>
    public required string KmsArn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("kms_arn");
        }
        init { this._rawData.Set("kms_arn", value); }
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

    /// <summary>
    /// AWS region. Derived from `kms_arn` if omitted.
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.KmsArn;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("aws")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Region;
    }

    public AwsExternalKeyConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AwsExternalKeyConfig(AwsExternalKeyConfig awsExternalKeyConfig)
        : base(awsExternalKeyConfig) { }
#pragma warning restore CS8618

    public AwsExternalKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AwsExternalKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AwsExternalKeyConfigFromRaw.FromRawUnchecked"/>
    public static AwsExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AwsExternalKeyConfig(string kmsArn)
        : this()
    {
        this.KmsArn = kmsArn;
    }
}

class AwsExternalKeyConfigFromRaw : IFromRawJson<AwsExternalKeyConfig>
{
    /// <inheritdoc/>
    public AwsExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AwsExternalKeyConfig.FromRawUnchecked(rawData);
}
