using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaAdvisorResultBlockParam, BetaAdvisorResultBlockParamFromRaw>)
)]
public sealed record class BetaAdvisorResultBlockParam : JsonModel
{
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("advisor_result")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorResultBlockParam(BetaAdvisorResultBlockParam betaAdvisorResultBlockParam)
        : base(betaAdvisorResultBlockParam) { }
#pragma warning restore CS8618

    public BetaAdvisorResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAdvisorResultBlockParam(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaAdvisorResultBlockParamFromRaw : IFromRawJson<BetaAdvisorResultBlockParam>
{
    /// <inheritdoc/>
    public BetaAdvisorResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorResultBlockParam.FromRawUnchecked(rawData);
}
