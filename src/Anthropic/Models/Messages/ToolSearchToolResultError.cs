using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<ToolSearchToolResultError, ToolSearchToolResultErrorFromRaw>)
)]
public sealed record class ToolSearchToolResultError : JsonModel
{
    public required ApiEnum<string, ToolSearchToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ToolSearchToolResultErrorCode>>(
                "error_code"
            );
        }
        init { this._rawData.Set("error_code", value); }
    }

    public required string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
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
        this.ErrorCode.Validate();
        _ = this.ErrorMessage;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("tool_search_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolSearchToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolSearchToolResultError(ToolSearchToolResultError toolSearchToolResultError)
        : base(toolSearchToolResultError) { }
#pragma warning restore CS8618

    public ToolSearchToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolSearchToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolSearchToolResultErrorFromRaw.FromRawUnchecked"/>
    public static ToolSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolSearchToolResultErrorFromRaw : IFromRawJson<ToolSearchToolResultError>
{
    /// <inheritdoc/>
    public ToolSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolSearchToolResultError.FromRawUnchecked(rawData);
}
