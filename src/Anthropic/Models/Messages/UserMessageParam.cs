using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<UserMessageParam, UserMessageParamFromRaw>))]
public sealed record class UserMessageParam : JsonModel
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
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("user")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserMessageParam(UserMessageParam userMessageParam)
        : base(userMessageParam) { }
#pragma warning restore CS8618

    public UserMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserMessageParamFromRaw.FromRawUnchecked"/>
    public static UserMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserMessageParam(MessageContentParam content)
        : this()
    {
        this.Content = content;
    }
}

class UserMessageParamFromRaw : IFromRawJson<UserMessageParam>
{
    /// <inheritdoc/>
    public UserMessageParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserMessageParam.FromRawUnchecked(rawData);
}
