using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A tool change or MCP tool listing references a tool or MCP server that is not
/// defined at that position in the conversation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ToolReferenceUnresolvedErrorDetails,
        ToolReferenceUnresolvedErrorDetailsFromRaw
    >)
)]
public sealed record class ToolReferenceUnresolvedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("tool_reference_unresolved")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolReferenceUnresolvedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("tool_reference_unresolved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolReferenceUnresolvedErrorDetails(
        ToolReferenceUnresolvedErrorDetails toolReferenceUnresolvedErrorDetails
    )
        : base(toolReferenceUnresolvedErrorDetails) { }
#pragma warning restore CS8618

    public ToolReferenceUnresolvedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("tool_reference_unresolved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolReferenceUnresolvedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolReferenceUnresolvedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ToolReferenceUnresolvedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolReferenceUnresolvedErrorDetailsFromRaw : IFromRawJson<ToolReferenceUnresolvedErrorDetails>
{
    /// <inheritdoc/>
    public ToolReferenceUnresolvedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolReferenceUnresolvedErrorDetails.FromRawUnchecked(rawData);
}
