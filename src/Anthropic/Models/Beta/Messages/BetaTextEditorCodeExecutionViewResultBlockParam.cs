using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaTextEditorCodeExecutionViewResultBlockParam,
        BetaTextEditorCodeExecutionViewResultBlockParamFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionViewResultBlockParam : JsonModel
{
    public required string Content
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "content"); }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public required ApiEnum<
        string,
        BetaTextEditorCodeExecutionViewResultBlockParamFileType
    > FileType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType>
            >(this.RawData, "file_type");
        }
        init { JsonModel.Set(this._rawData, "file_type", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public long? NumLines
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "num_lines"); }
        init { JsonModel.Set(this._rawData, "num_lines", value); }
    }

    public long? StartLine
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "start_line"); }
        init { JsonModel.Set(this._rawData, "start_line", value); }
    }

    public long? TotalLines
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "total_lines"); }
        init { JsonModel.Set(this._rawData, "total_lines", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.FileType.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_view_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.NumLines;
        _ = this.StartLine;
        _ = this.TotalLines;
    }

    public BetaTextEditorCodeExecutionViewResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
    }

    public BetaTextEditorCodeExecutionViewResultBlockParam(
        BetaTextEditorCodeExecutionViewResultBlockParam betaTextEditorCodeExecutionViewResultBlockParam
    )
        : base(betaTextEditorCodeExecutionViewResultBlockParam) { }

    public BetaTextEditorCodeExecutionViewResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionViewResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionViewResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionViewResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionViewResultBlockParamFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionViewResultBlockParam>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionViewResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionViewResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaTextEditorCodeExecutionViewResultBlockParamFileTypeConverter))]
public enum BetaTextEditorCodeExecutionViewResultBlockParamFileType
{
    Text,
    Image,
    PDF,
}

sealed class BetaTextEditorCodeExecutionViewResultBlockParamFileTypeConverter
    : JsonConverter<BetaTextEditorCodeExecutionViewResultBlockParamFileType>
{
    public override BetaTextEditorCodeExecutionViewResultBlockParamFileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
            "image" => BetaTextEditorCodeExecutionViewResultBlockParamFileType.Image,
            "pdf" => BetaTextEditorCodeExecutionViewResultBlockParamFileType.PDF,
            _ => (BetaTextEditorCodeExecutionViewResultBlockParamFileType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextEditorCodeExecutionViewResultBlockParamFileType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text => "text",
                BetaTextEditorCodeExecutionViewResultBlockParamFileType.Image => "image",
                BetaTextEditorCodeExecutionViewResultBlockParamFileType.PDF => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
