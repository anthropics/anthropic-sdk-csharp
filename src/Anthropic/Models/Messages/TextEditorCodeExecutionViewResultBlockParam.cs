using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        TextEditorCodeExecutionViewResultBlockParam,
        TextEditorCodeExecutionViewResultBlockParamFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionViewResultBlockParam : JsonModel
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

    public required ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType> FileType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType>
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

    public TextEditorCodeExecutionViewResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_view_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionViewResultBlockParam(
        TextEditorCodeExecutionViewResultBlockParam textEditorCodeExecutionViewResultBlockParam
    )
        : base(textEditorCodeExecutionViewResultBlockParam) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionViewResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_view_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionViewResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionViewResultBlockParamFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionViewResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextEditorCodeExecutionViewResultBlockParamFromRaw
    : IFromRawJson<TextEditorCodeExecutionViewResultBlockParam>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionViewResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionViewResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TextEditorCodeExecutionViewResultBlockParamFileTypeConverter))]
public enum TextEditorCodeExecutionViewResultBlockParamFileType
{
    Text,
    Image,
    Pdf,
}

sealed class TextEditorCodeExecutionViewResultBlockParamFileTypeConverter
    : JsonConverter<TextEditorCodeExecutionViewResultBlockParamFileType>
{
    public override TextEditorCodeExecutionViewResultBlockParamFileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => TextEditorCodeExecutionViewResultBlockParamFileType.Text,
            "image" => TextEditorCodeExecutionViewResultBlockParamFileType.Image,
            "pdf" => TextEditorCodeExecutionViewResultBlockParamFileType.Pdf,
            _ => (TextEditorCodeExecutionViewResultBlockParamFileType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextEditorCodeExecutionViewResultBlockParamFileType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextEditorCodeExecutionViewResultBlockParamFileType.Text => "text",
                TextEditorCodeExecutionViewResultBlockParamFileType.Image => "image",
                TextEditorCodeExecutionViewResultBlockParamFileType.Pdf => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
