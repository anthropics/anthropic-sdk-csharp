using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// An AWS IAM role principal.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAwsRoleExecutionIdentityParams,
        BetaManagedAgentsAwsRoleExecutionIdentityParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAwsRoleExecutionIdentityParams : JsonModel
{
    /// <summary>
    /// The IAM role's ARN, e.g. "arn:aws:iam::123456789012:role/my-agent-runner".
    /// Maximum 2048 characters.
    /// </summary>
    public required string RoleArn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("role_arn");
        }
        init { this._rawData.Set("role_arn", value); }
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
        _ = this.RoleArn;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("aws_role")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAwsRoleExecutionIdentityParams()
    {
        this.Type = JsonSerializer.SerializeToElement("aws_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAwsRoleExecutionIdentityParams(
        BetaManagedAgentsAwsRoleExecutionIdentityParams betaManagedAgentsAwsRoleExecutionIdentityParams
    )
        : base(betaManagedAgentsAwsRoleExecutionIdentityParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAwsRoleExecutionIdentityParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("aws_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAwsRoleExecutionIdentityParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAwsRoleExecutionIdentityParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAwsRoleExecutionIdentityParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAwsRoleExecutionIdentityParams(string roleArn)
        : this()
    {
        this.RoleArn = roleArn;
    }
}

class BetaManagedAgentsAwsRoleExecutionIdentityParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAwsRoleExecutionIdentityParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAwsRoleExecutionIdentityParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAwsRoleExecutionIdentityParams.FromRawUnchecked(rawData);
}
