using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ServerToolUseBlock, ServerToolUseBlockFromRaw>))]
public sealed record class ServerToolUseBlock : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("input");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "input",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.ID;
        _ = this.Input;
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("web_search")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("server_tool_use"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ServerToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("web_search");
        this.Type = JsonSerializer.SerializeToElement("server_tool_use");
    }

    public ServerToolUseBlock(ServerToolUseBlock serverToolUseBlock)
        : base(serverToolUseBlock) { }

    public ServerToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("web_search");
        this.Type = JsonSerializer.SerializeToElement("server_tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolUseBlockFromRaw.FromRawUnchecked"/>
    public static ServerToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServerToolUseBlockFromRaw : IFromRawJson<ServerToolUseBlock>
{
    /// <inheritdoc/>
    public ServerToolUseBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ServerToolUseBlock.FromRawUnchecked(rawData);
}
