using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(ModelConverter<BetaAuthenticationError, BetaAuthenticationErrorFromRaw>))]
public sealed record class BetaAuthenticationError : ModelBase
{
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"authentication_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAuthenticationError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"authentication_error\"");
    }

    public BetaAuthenticationError(BetaAuthenticationError betaAuthenticationError)
        : base(betaAuthenticationError) { }

    public BetaAuthenticationError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"authentication_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAuthenticationError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaAuthenticationErrorFromRaw : IFromRaw<BetaAuthenticationError>
{
    /// <inheritdoc/>
    public BetaAuthenticationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAuthenticationError.FromRawUnchecked(rawData);
}
