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
        BetaTextEditorCodeExecutionViewResultBlock,
        BetaTextEditorCodeExecutionViewResultBlockFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionViewResultBlock : JsonModel
{
    public required string Content
    {
        get { return this._rawData.GetNotNullClass<string>("content"); }
        init { this._rawData.Set("content", value); }
    }

    public required ApiEnum<string, FileType> FileType
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, FileType>>("file_type"); }
        init { this._rawData.Set("file_type", value); }
    }

    public required long? NumLines
    {
        get { return this._rawData.GetNullableStruct<long>("num_lines"); }
        init { this._rawData.Set("num_lines", value); }
    }

    public required long? StartLine
    {
        get { return this._rawData.GetNullableStruct<long>("start_line"); }
        init { this._rawData.Set("start_line", value); }
    }

    public required long? TotalLines
    {
        get { return this._rawData.GetNullableStruct<long>("total_lines"); }
        init { this._rawData.Set("total_lines", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.FileType.Validate();
        _ = this.NumLines;
        _ = this.StartLine;
        _ = this.TotalLines;
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
    }

    public BetaTextEditorCodeExecutionViewResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
    }

    public BetaTextEditorCodeExecutionViewResultBlock(
        BetaTextEditorCodeExecutionViewResultBlock betaTextEditorCodeExecutionViewResultBlock
    )
        : base(betaTextEditorCodeExecutionViewResultBlock) { }

    public BetaTextEditorCodeExecutionViewResultBlock(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionViewResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionViewResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionViewResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionViewResultBlockFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionViewResultBlock>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionViewResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionViewResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FileTypeConverter))]
public enum FileType
{
    Text,
    Image,
    Pdf,
}

sealed class FileTypeConverter : JsonConverter<FileType>
{
    public override FileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FileType.Text,
            "image" => FileType.Image,
            "pdf" => FileType.Pdf,
            _ => (FileType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileType.Text => "text",
                FileType.Image => "image",
                FileType.Pdf => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
