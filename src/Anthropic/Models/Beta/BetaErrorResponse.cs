using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaErrorResponse, BetaErrorResponseFromRaw>))]
public sealed record class BetaErrorResponse : JsonModel
{
    public required BetaError Error
    {
        get { return this._rawData.GetNotNullClass<BetaError>("error"); }
        init { this._rawData.Set("error", value); }
    }

    public required string? RequestID
    {
        get { return this._rawData.GetNullableClass<string>("request_id"); }
        init { this._rawData.Set("request_id", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        _ = this.RequestID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"error\""))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaErrorResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

    public BetaErrorResponse(BetaErrorResponse betaErrorResponse)
        : base(betaErrorResponse) { }

    public BetaErrorResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaErrorResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaErrorResponseFromRaw.FromRawUnchecked"/>
    public static BetaErrorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaErrorResponseFromRaw : IFromRawJson<BetaErrorResponse>
{
    /// <inheritdoc/>
    public BetaErrorResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaErrorResponse.FromRawUnchecked(rawData);
}
