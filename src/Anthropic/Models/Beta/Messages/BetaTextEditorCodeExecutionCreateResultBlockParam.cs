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
        BetaTextEditorCodeExecutionCreateResultBlockParam,
        BetaTextEditorCodeExecutionCreateResultBlockParamFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionCreateResultBlockParam : JsonModel
{
    public required bool IsFileUpdate
    {
        get { return this._rawData.GetNotNullStruct<bool>("is_file_update"); }
        init { this._rawData.Set("is_file_update", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsFileUpdate;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_create_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextEditorCodeExecutionCreateResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );
    }

    public BetaTextEditorCodeExecutionCreateResultBlockParam(
        BetaTextEditorCodeExecutionCreateResultBlockParam betaTextEditorCodeExecutionCreateResultBlockParam
    )
        : base(betaTextEditorCodeExecutionCreateResultBlockParam) { }

    public BetaTextEditorCodeExecutionCreateResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionCreateResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionCreateResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionCreateResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTextEditorCodeExecutionCreateResultBlockParam(bool isFileUpdate)
        : this()
    {
        this.IsFileUpdate = isFileUpdate;
    }
}

class BetaTextEditorCodeExecutionCreateResultBlockParamFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionCreateResultBlockParam>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionCreateResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionCreateResultBlockParam.FromRawUnchecked(rawData);
}
