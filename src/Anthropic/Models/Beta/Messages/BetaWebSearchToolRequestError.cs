using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaWebSearchToolRequestError, BetaWebSearchToolRequestErrorFromRaw>)
)]
public sealed record class BetaWebSearchToolRequestError : JsonModel
{
    public required ApiEnum<string, BetaWebSearchToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWebSearchToolResultErrorCode>>(
                "error_code"
            );
        }
        init { this._rawData.Set("error_code", value); }
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_search_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebSearchToolRequestError()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebSearchToolRequestError(
        BetaWebSearchToolRequestError betaWebSearchToolRequestError
    )
        : base(betaWebSearchToolRequestError) { }
#pragma warning restore CS8618

    public BetaWebSearchToolRequestError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebSearchToolRequestErrorFromRaw.FromRawUnchecked"/>
    public static BetaWebSearchToolRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebSearchToolRequestError(
        ApiEnum<string, BetaWebSearchToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaWebSearchToolRequestErrorFromRaw : IFromRawJson<BetaWebSearchToolRequestError>
{
    /// <inheritdoc/>
    public BetaWebSearchToolRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebSearchToolRequestError.FromRawUnchecked(rawData);
}
