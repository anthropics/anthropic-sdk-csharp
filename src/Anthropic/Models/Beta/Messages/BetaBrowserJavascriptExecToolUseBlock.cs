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
        BetaBrowserJavascriptExecToolUseBlock,
        BetaBrowserJavascriptExecToolUseBlockFromRaw
    >)
)]
public sealed record class BetaBrowserJavascriptExecToolUseBlock : JsonModel
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
    /// Execute JavaScript in the page context and return the value of the last expression.
    /// The code runs with access to the DOM, `window`, and page variables. Write
    /// the expression you want evaluated — do NOT use `return`.
    /// </summary>
    public required BetaBrowserJavascriptExecInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserJavascriptExecInput>("input");
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
        if (
            !JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("javascript_exec"))
        )
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

    public BetaBrowserJavascriptExecToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("javascript_exec");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserJavascriptExecToolUseBlock(
        BetaBrowserJavascriptExecToolUseBlock betaBrowserJavascriptExecToolUseBlock
    )
        : base(betaBrowserJavascriptExecToolUseBlock) { }
#pragma warning restore CS8618

    public BetaBrowserJavascriptExecToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("javascript_exec");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserJavascriptExecToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserJavascriptExecToolUseBlockFromRaw.FromRawUnchecked"/>
    public static BetaBrowserJavascriptExecToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserJavascriptExecToolUseBlockFromRaw
    : IFromRawJson<BetaBrowserJavascriptExecToolUseBlock>
{
    /// <inheritdoc/>
    public BetaBrowserJavascriptExecToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserJavascriptExecToolUseBlock.FromRawUnchecked(rawData);
}
