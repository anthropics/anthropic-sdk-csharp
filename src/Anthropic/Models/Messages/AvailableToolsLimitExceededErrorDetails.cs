using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The tools available after a message exceed a limit on their number or their size.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AvailableToolsLimitExceededErrorDetails,
        AvailableToolsLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class AvailableToolsLimitExceededErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("available_tools_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public AvailableToolsLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("available_tools_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailableToolsLimitExceededErrorDetails(
        AvailableToolsLimitExceededErrorDetails availableToolsLimitExceededErrorDetails
    )
        : base(availableToolsLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public AvailableToolsLimitExceededErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("available_tools_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailableToolsLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AvailableToolsLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static AvailableToolsLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AvailableToolsLimitExceededErrorDetailsFromRaw
    : IFromRawJson<AvailableToolsLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public AvailableToolsLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AvailableToolsLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
