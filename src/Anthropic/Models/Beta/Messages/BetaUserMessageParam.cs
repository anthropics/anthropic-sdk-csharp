using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaUserMessageParam, BetaUserMessageParamFromRaw>))]
public sealed record class BetaUserMessageParam : JsonModel
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
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("user")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaUserMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserMessageParam(BetaUserMessageParam betaUserMessageParam)
        : base(betaUserMessageParam) { }
#pragma warning restore CS8618

    public BetaUserMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserMessageParamFromRaw.FromRawUnchecked"/>
    public static BetaUserMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaUserMessageParam(BetaMessageContentParam content)
        : this()
    {
        this.Content = content;
    }
}

class BetaUserMessageParamFromRaw : IFromRawJson<BetaUserMessageParam>
{
    /// <inheritdoc/>
    public BetaUserMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserMessageParam.FromRawUnchecked(rawData);
}
