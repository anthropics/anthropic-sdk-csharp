using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaWebFetchToolResultErrorBlock,
        BetaWebFetchToolResultErrorBlockFromRaw
    >)
)]
public sealed record class BetaWebFetchToolResultErrorBlock : ModelBase
{
    public required ApiEnum<string, BetaWebFetchToolResultErrorCode> ErrorCode
    {
        get
        {
            if (!this._rawData.TryGetValue("error_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new ArgumentOutOfRangeException("error_code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BetaWebFetchToolResultErrorCode>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new ArgumentNullException("error_code")
                );
        }
        init
        {
            this._rawData["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchToolResultErrorBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result_error\"");
    }

    public BetaWebFetchToolResultErrorBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultErrorBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaWebFetchToolResultErrorBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebFetchToolResultErrorBlock(
        ApiEnum<string, BetaWebFetchToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaWebFetchToolResultErrorBlockFromRaw : IFromRaw<BetaWebFetchToolResultErrorBlock>
{
    public BetaWebFetchToolResultErrorBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchToolResultErrorBlock.FromRawUnchecked(rawData);
}
