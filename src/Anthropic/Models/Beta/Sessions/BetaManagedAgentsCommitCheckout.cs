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

    public required ApiEnum<string, BetaManagedAgentsCommitCheckoutType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsCommitCheckoutType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Sha;
        this.Type.Validate();
    }

    public BetaManagedAgentsCommitCheckout() { }

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
}

class BetaManagedAgentsCommitCheckoutFromRaw : IFromRawJson<BetaManagedAgentsCommitCheckout>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCommitCheckout FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCommitCheckout.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsCommitCheckoutTypeConverter))]
public enum BetaManagedAgentsCommitCheckoutType
{
    Commit,
}

sealed class BetaManagedAgentsCommitCheckoutTypeConverter
    : JsonConverter<BetaManagedAgentsCommitCheckoutType>
{
    public override BetaManagedAgentsCommitCheckoutType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "commit" => BetaManagedAgentsCommitCheckoutType.Commit,
            _ => (BetaManagedAgentsCommitCheckoutType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCommitCheckoutType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCommitCheckoutType.Commit => "commit",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
