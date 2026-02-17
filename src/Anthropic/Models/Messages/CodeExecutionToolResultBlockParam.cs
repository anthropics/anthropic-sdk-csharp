using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        CodeExecutionToolResultBlockParam,
        CodeExecutionToolResultBlockParamFromRaw
    >)
)]
public sealed record class CodeExecutionToolResultBlockParam : JsonModel
{
    /// <summary>
    /// Code execution result with encrypted stdout for PFC + web_search results.
    /// </summary>
    public required CodeExecutionToolResultBlockParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CodeExecutionToolResultBlockParamContent>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public CodeExecutionToolResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionToolResultBlockParam(
        CodeExecutionToolResultBlockParam codeExecutionToolResultBlockParam
    )
        : base(codeExecutionToolResultBlockParam) { }
#pragma warning restore CS8618

    public CodeExecutionToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static CodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionToolResultBlockParamFromRaw : IFromRawJson<CodeExecutionToolResultBlockParam>
{
    /// <inheritdoc/>
    public CodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionToolResultBlockParam.FromRawUnchecked(rawData);
}
