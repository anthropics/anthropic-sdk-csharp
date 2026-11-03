using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A tool made available in `messages` takes a name that an available tool of another
/// kind, or of another MCP server, already holds.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ToolNameConflictErrorDetails, ToolNameConflictErrorDetailsFromRaw>)
)]
public sealed record class ToolNameConflictErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("tool_name_conflict")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolNameConflictErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("tool_name_conflict");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolNameConflictErrorDetails(ToolNameConflictErrorDetails toolNameConflictErrorDetails)
        : base(toolNameConflictErrorDetails) { }
#pragma warning restore CS8618

    public ToolNameConflictErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("tool_name_conflict");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolNameConflictErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolNameConflictErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ToolNameConflictErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolNameConflictErrorDetailsFromRaw : IFromRawJson<ToolNameConflictErrorDetails>
{
    /// <inheritdoc/>
    public ToolNameConflictErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolNameConflictErrorDetails.FromRawUnchecked(rawData);
}
