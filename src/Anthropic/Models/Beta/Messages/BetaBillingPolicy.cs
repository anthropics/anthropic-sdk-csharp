using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Declares which organization is billed for the request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBillingPolicy, BetaBillingPolicyFromRaw>))]
public sealed record class BetaBillingPolicy : JsonModel
{
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
    /// Who is billed. `self`, the default, bills your organization, as if `billing_policy`
    /// were omitted. `user_profile` bills the customer behind the user profile the
    /// request names; if that customer has not linked an Anthropic organization
    /// to the profile, or has not allowed your organization to bill it, the request
    /// is rejected rather than billed to you.
    /// </summary>
    public ApiEnum<string, BetaBillTo>? BillTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaBillTo>>("bill_to");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("bill_to");
                return;
            }

            this._rawData.Set("bill_to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("billing_policy")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.BillTo?.Validate();
    }

    public BetaBillingPolicy()
    {
        this.Type = JsonSerializer.SerializeToElement("billing_policy");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBillingPolicy(BetaBillingPolicy betaBillingPolicy)
        : base(betaBillingPolicy) { }
#pragma warning restore CS8618

    public BetaBillingPolicy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("billing_policy");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBillingPolicy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBillingPolicyFromRaw.FromRawUnchecked"/>
    public static BetaBillingPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBillingPolicyFromRaw : IFromRawJson<BetaBillingPolicy>
{
    /// <inheritdoc/>
    public BetaBillingPolicy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaBillingPolicy.FromRawUnchecked(rawData);
}
