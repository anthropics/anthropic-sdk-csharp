using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaAssistantMessageParam, BetaAssistantMessageParamFromRaw>)
)]
public sealed record class BetaAssistantMessageParam : JsonModel
{
    public required BetaMessageContentParam Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaMessageContentParam>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public JsonElement Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("assistant")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAssistantMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("assistant");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAssistantMessageParam(BetaAssistantMessageParam betaAssistantMessageParam)
        : base(betaAssistantMessageParam) { }
#pragma warning restore CS8618

    public BetaAssistantMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("assistant");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAssistantMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAssistantMessageParamFromRaw.FromRawUnchecked"/>
    public static BetaAssistantMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAssistantMessageParam(BetaMessageContentParam content)
        : this()
    {
        this.Content = content;
    }
}

class BetaAssistantMessageParamFromRaw : IFromRawJson<BetaAssistantMessageParam>
{
    /// <inheritdoc/>
    public BetaAssistantMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAssistantMessageParam.FromRawUnchecked(rawData);
}
