using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCommitCheckout,
        BetaManagedAgentsCommitCheckoutFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCommitCheckout : JsonModel
{
    /// <summary>
    /// Full commit SHA to check out.
    /// </summary>
    public required string Sha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sha");
        }
        init { this._rawData.Set("sha", value); }
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
        _ = this.Sha;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("commit")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsCommitCheckout()
    {
        this.Type = JsonSerializer.SerializeToElement("commit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCommitCheckout(
        BetaManagedAgentsCommitCheckout betaManagedAgentsCommitCheckout
    )
        : base(betaManagedAgentsCommitCheckout) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCommitCheckout(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("commit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCommitCheckout(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCommitCheckoutFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCommitCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsCommitCheckout(string sha)
        : this()
    {
        this.Sha = sha;
    }
}

class BetaManagedAgentsCommitCheckoutFromRaw : IFromRawJson<BetaManagedAgentsCommitCheckout>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCommitCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCommitCheckout.FromRawUnchecked(rawData);
}
