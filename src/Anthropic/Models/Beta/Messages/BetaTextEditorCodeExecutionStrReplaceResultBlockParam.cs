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
        BetaTextEditorCodeExecutionStrReplaceResultBlockParam,
        BetaTextEditorCodeExecutionStrReplaceResultBlockParamFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionStrReplaceResultBlockParam : JsonModel
{
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public IReadOnlyList<string>? Lines
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "lines"); }
        init { JsonModel.Set(this._rawData, "lines", value); }
    }

    public long? NewLines
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "new_lines"); }
        init { JsonModel.Set(this._rawData, "new_lines", value); }
    }

    public long? NewStart
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "new_start"); }
        init { JsonModel.Set(this._rawData, "new_start", value); }
    }

    public long? OldLines
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "old_lines"); }
        init { JsonModel.Set(this._rawData, "old_lines", value); }
    }

    public long? OldStart
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "old_start"); }
        init { JsonModel.Set(this._rawData, "old_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_str_replace_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Lines;
        _ = this.NewLines;
        _ = this.NewStart;
        _ = this.OldLines;
        _ = this.OldStart;
    }

    public BetaTextEditorCodeExecutionStrReplaceResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_str_replace_result\""
        );
    }

    public BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        BetaTextEditorCodeExecutionStrReplaceResultBlockParam betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
        : base(betaTextEditorCodeExecutionStrReplaceResultBlockParam) { }

    public BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_str_replace_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionStrReplaceResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionStrReplaceResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionStrReplaceResultBlockParamFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionStrReplaceResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionStrReplaceResultBlockParam.FromRawUnchecked(rawData);
}
