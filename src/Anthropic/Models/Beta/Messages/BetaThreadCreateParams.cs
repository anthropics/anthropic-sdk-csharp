using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Start holding conversation state under this response's ``id``.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaThreadCreateParams, BetaThreadCreateParamsFromRaw>))]
public sealed record class BetaThreadCreateParams : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("create")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThreadCreateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("create");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThreadCreateParams(BetaThreadCreateParams betaThreadCreateParams)
        : base(betaThreadCreateParams) { }
#pragma warning restore CS8618

    public BetaThreadCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("create");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThreadCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThreadCreateParamsFromRaw.FromRawUnchecked"/>
    public static BetaThreadCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThreadCreateParamsFromRaw : IFromRawJson<BetaThreadCreateParams>
{
    /// <inheritdoc/>
    public BetaThreadCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThreadCreateParams.FromRawUnchecked(rawData);
}
