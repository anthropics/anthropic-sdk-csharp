using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Failure detail for a Dream whose `status` is `failed`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamError, BetaDreamErrorFromRaw>))]
public sealed record class BetaDreamError : JsonModel
{
    /// <summary>
    /// A human-readable explanation of why the dream failed.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// A code for why the dream failed, such as `timeout` or `internal_error`.
    ///
    /// <para>The [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#errors)
    /// lists common error codes and when they occur.</para>
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Type;
    }

    public BetaDreamError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamError(BetaDreamError betaDreamError)
        : base(betaDreamError) { }
#pragma warning restore CS8618

    public BetaDreamError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamErrorFromRaw.FromRawUnchecked"/>
    public static BetaDreamError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDreamErrorFromRaw : IFromRawJson<BetaDreamError>
{
    /// <inheritdoc/>
    public BetaDreamError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDreamError.FromRawUnchecked(rawData);
}
