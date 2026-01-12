using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaPermissionError, BetaPermissionErrorFromRaw>))]
public sealed record class BetaPermissionError : JsonModel
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
                JsonSerializer.Deserialize<JsonElement>("\"permission_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPermissionError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"permission_error\"");
    }

    public BetaPermissionError(BetaPermissionError betaPermissionError)
        : base(betaPermissionError) { }

    public BetaPermissionError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"permission_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPermissionError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPermissionErrorFromRaw.FromRawUnchecked"/>
    public static BetaPermissionError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPermissionError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaPermissionErrorFromRaw : IFromRawJson<BetaPermissionError>
{
    /// <inheritdoc/>
    public BetaPermissionError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPermissionError.FromRawUnchecked(rawData);
}
