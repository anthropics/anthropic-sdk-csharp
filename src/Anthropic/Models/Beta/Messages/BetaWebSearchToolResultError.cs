using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaWebSearchToolResultError, BetaWebSearchToolResultErrorFromRaw>)
)]
public sealed record class BetaWebSearchToolResultError : JsonModel
{
    public required ApiEnum<string, BetaWebSearchToolResultErrorCode> ErrorCode
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, BetaWebSearchToolResultErrorCode>>(
                this.RawData,
                "error_code"
            );
        }
        init { JsonModel.Set(this._rawData, "error_code", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebSearchToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

    public BetaWebSearchToolResultError(BetaWebSearchToolResultError betaWebSearchToolResultError)
        : base(betaWebSearchToolResultError) { }

    public BetaWebSearchToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebSearchToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaWebSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebSearchToolResultError(ApiEnum<string, BetaWebSearchToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaWebSearchToolResultErrorFromRaw : IFromRawJson<BetaWebSearchToolResultError>
{
    /// <inheritdoc/>
    public BetaWebSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebSearchToolResultError.FromRawUnchecked(rawData);
}
