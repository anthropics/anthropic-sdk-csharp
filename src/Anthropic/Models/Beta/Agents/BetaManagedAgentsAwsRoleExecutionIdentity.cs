using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// An AWS IAM role principal as returned in API responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAwsRoleExecutionIdentity,
        BetaManagedAgentsAwsRoleExecutionIdentityFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAwsRoleExecutionIdentity : JsonModel
{
    /// <summary>
    /// The IAM role's ARN.
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

    public BetaManagedAgentsAwsRoleExecutionIdentity()
    {
        this.Type = JsonSerializer.SerializeToElement("aws_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAwsRoleExecutionIdentity(
        BetaManagedAgentsAwsRoleExecutionIdentity betaManagedAgentsAwsRoleExecutionIdentity
    )
        : base(betaManagedAgentsAwsRoleExecutionIdentity) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAwsRoleExecutionIdentity(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("aws_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAwsRoleExecutionIdentity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAwsRoleExecutionIdentityFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAwsRoleExecutionIdentity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAwsRoleExecutionIdentity(string roleArn)
        : this()
    {
        this.RoleArn = roleArn;
    }
}

class BetaManagedAgentsAwsRoleExecutionIdentityFromRaw
    : IFromRawJson<BetaManagedAgentsAwsRoleExecutionIdentity>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAwsRoleExecutionIdentity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAwsRoleExecutionIdentity.FromRawUnchecked(rawData);
}
