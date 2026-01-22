using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaAuthenticationError, BetaAuthenticationErrorFromRaw>))]
public sealed record class BetaAuthenticationError : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("authentication_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAuthenticationError()
    {
        this.Type = JsonSerializer.SerializeToElement("authentication_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAuthenticationError(BetaAuthenticationError betaAuthenticationError)
        : base(betaAuthenticationError) { }
#pragma warning restore CS8618

    public BetaAuthenticationError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("authentication_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAuthenticationError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAuthenticationErrorFromRaw.FromRawUnchecked"/>
    public static BetaAuthenticationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAuthenticationError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaAuthenticationErrorFromRaw : IFromRawJson<BetaAuthenticationError>
{
    /// <inheritdoc/>
    public BetaAuthenticationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAuthenticationError.FromRawUnchecked(rawData);
}
