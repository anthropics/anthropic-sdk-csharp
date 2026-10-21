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
        BetaManagedAgentsBranchCheckout,
        BetaManagedAgentsBranchCheckoutFromRaw
    >)
)]
public sealed record class BetaManagedAgentsBranchCheckout : JsonModel
{
    /// <summary>
    /// Branch name to check out.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("branch")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsBranchCheckout()
    {
        this.Type = JsonSerializer.SerializeToElement("branch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBranchCheckout(
        BetaManagedAgentsBranchCheckout betaManagedAgentsBranchCheckout
    )
        : base(betaManagedAgentsBranchCheckout) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBranchCheckout(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("branch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsBranchCheckout(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsBranchCheckoutFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsBranchCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsBranchCheckout(string name)
        : this()
    {
        this.Name = name;
    }
}

class BetaManagedAgentsBranchCheckoutFromRaw : IFromRawJson<BetaManagedAgentsBranchCheckout>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBranchCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBranchCheckout.FromRawUnchecked(rawData);
}
