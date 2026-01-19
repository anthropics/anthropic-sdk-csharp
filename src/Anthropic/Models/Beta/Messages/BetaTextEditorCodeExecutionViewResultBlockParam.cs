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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required ApiEnum<
        string,
        BetaTextEditorCodeExecutionViewResultBlockParamFileType
    > FileType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType>
            >("file_type");
        }
        init { this._rawData.Set("file_type", value); }
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

    public long? NumLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_lines");
        }
        init { this._rawData.Set("num_lines", value); }
    }

    public long? StartLine
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start_line");
        }
        init { this._rawData.Set("start_line", value); }
    }

    public long? TotalLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_lines");
        }
        init { this._rawData.Set("total_lines", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.FileType.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_view_result")
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
        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_view_result");
    }

    public BetaTextEditorCodeExecutionViewResultBlockParam(
        BetaTextEditorCodeExecutionViewResultBlockParam betaTextEditorCodeExecutionViewResultBlockParam
    )
        : base(betaTextEditorCodeExecutionViewResultBlockParam) { }

    public BetaTextEditorCodeExecutionViewResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_view_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionViewResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    Pdf,
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
            "pdf" => BetaTextEditorCodeExecutionViewResultBlockParamFileType.Pdf,
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
                BetaTextEditorCodeExecutionViewResultBlockParamFileType.Pdf => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
