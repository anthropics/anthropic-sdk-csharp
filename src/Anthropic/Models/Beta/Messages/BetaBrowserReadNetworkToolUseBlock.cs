using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaBrowserReadNetworkToolUseBlock,
        BetaBrowserReadNetworkToolUseBlockFromRaw
    >)
)]
public sealed record class BetaBrowserReadNetworkToolUseBlock : JsonModel
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

    /// <summary>
    /// Return the network requests (method, URL, status, MIME type, timing) recorded
    /// since the driver attached to the tab and since the last read, one line per
    /// entry. An empty result does not mean no traffic for a tab that predates attach.
    /// </summary>
    public required BetaBrowserReadNetworkInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserReadNetworkInput>("input");
        }
        init { this._rawData.Set("input", value); }
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

    public JsonElement ToolsetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("toolset_name");
        }
        init { this._rawData.Set("toolset_name", value); }
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

    /// <summary>
    /// Which party invoked the tool call: the model directly, or a server tool on
    /// its behalf.
    /// </summary>
    public BetaToolUseCaller? Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaToolUseCaller>("caller");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("caller");
                return;
            }

            this._rawData.Set("caller", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Input.Validate();
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("read_network")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.ToolsetName, JsonSerializer.SerializeToElement("browser")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_use")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Caller?.Validate();
    }

    public BetaBrowserReadNetworkToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("read_network");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserReadNetworkToolUseBlock(
        BetaBrowserReadNetworkToolUseBlock betaBrowserReadNetworkToolUseBlock
    )
        : base(betaBrowserReadNetworkToolUseBlock) { }
#pragma warning restore CS8618

    public BetaBrowserReadNetworkToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("read_network");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserReadNetworkToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserReadNetworkToolUseBlockFromRaw.FromRawUnchecked"/>
    public static BetaBrowserReadNetworkToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserReadNetworkToolUseBlockFromRaw : IFromRawJson<BetaBrowserReadNetworkToolUseBlock>
{
    /// <inheritdoc/>
    public BetaBrowserReadNetworkToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserReadNetworkToolUseBlock.FromRawUnchecked(rawData);
}
