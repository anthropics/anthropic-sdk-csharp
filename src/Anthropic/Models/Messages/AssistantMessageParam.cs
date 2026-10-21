using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<AssistantMessageParam, AssistantMessageParamFromRaw>))]
public sealed record class AssistantMessageParam : JsonModel
{
    public required MessageContentParam Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MessageContentParam>("content");
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

    public AssistantMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("assistant");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantMessageParam(AssistantMessageParam assistantMessageParam)
        : base(assistantMessageParam) { }
#pragma warning restore CS8618

    public AssistantMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("assistant");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssistantMessageParamFromRaw.FromRawUnchecked"/>
    public static AssistantMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AssistantMessageParam(MessageContentParam content)
        : this()
    {
        this.Content = content;
    }
}

class AssistantMessageParamFromRaw : IFromRawJson<AssistantMessageParam>
{
    /// <inheritdoc/>
    public AssistantMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AssistantMessageParam.FromRawUnchecked(rawData);
}
