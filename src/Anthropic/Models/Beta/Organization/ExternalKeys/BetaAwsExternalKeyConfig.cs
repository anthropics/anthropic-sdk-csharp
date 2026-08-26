using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

[JsonConverter(
    typeof(JsonModelConverter<BetaAwsExternalKeyConfig, BetaAwsExternalKeyConfigFromRaw>)
)]
public sealed record class BetaAwsExternalKeyConfig : JsonModel
{
    /// <summary>
    /// Full ARN of the AWS KMS key.
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

    /// <summary>
    /// IAM role ARN. Deprecated — Anthropic reaches the KMS key via a managed intermediate
    /// role; this field is ignored.
    /// </summary>
    [Obsolete("deprecated")]
    public string? RoleArn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role_arn");
        }
        init { this._rawData.Set("role_arn", value); }
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
        _ = this.RoleArn;
    }

    public BetaAwsExternalKeyConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAwsExternalKeyConfig(BetaAwsExternalKeyConfig betaAwsExternalKeyConfig)
        : base(betaAwsExternalKeyConfig) { }
#pragma warning restore CS8618

    public BetaAwsExternalKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAwsExternalKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAwsExternalKeyConfigFromRaw.FromRawUnchecked"/>
    public static BetaAwsExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAwsExternalKeyConfig(string kmsArn)
        : this()
    {
        this.KmsArn = kmsArn;
    }
}

class BetaAwsExternalKeyConfigFromRaw : IFromRawJson<BetaAwsExternalKeyConfig>
{
    /// <inheritdoc/>
    public BetaAwsExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAwsExternalKeyConfig.FromRawUnchecked(rawData);
}
