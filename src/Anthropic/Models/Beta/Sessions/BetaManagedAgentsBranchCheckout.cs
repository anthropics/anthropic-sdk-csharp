using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsBranchCheckoutType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsBranchCheckoutType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Type.Validate();
    }

    public BetaManagedAgentsBranchCheckout() { }

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
}

class BetaManagedAgentsBranchCheckoutFromRaw : IFromRawJson<BetaManagedAgentsBranchCheckout>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBranchCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBranchCheckout.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsBranchCheckoutTypeConverter))]
public enum BetaManagedAgentsBranchCheckoutType
{
    Branch,
}

sealed class BetaManagedAgentsBranchCheckoutTypeConverter
    : JsonConverter<BetaManagedAgentsBranchCheckoutType>
{
    public override BetaManagedAgentsBranchCheckoutType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "branch" => BetaManagedAgentsBranchCheckoutType.Branch,
            _ => (BetaManagedAgentsBranchCheckoutType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsBranchCheckoutType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsBranchCheckoutType.Branch => "branch",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
