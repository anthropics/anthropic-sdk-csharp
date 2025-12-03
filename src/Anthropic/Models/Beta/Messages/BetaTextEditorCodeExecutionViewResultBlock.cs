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
    typeof(ModelConverter<
        BetaTextEditorCodeExecutionViewResultBlock,
        BetaTextEditorCodeExecutionViewResultBlockFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionViewResultBlock : ModelBase
{
    public required string Content
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required ApiEnum<string, FileType> FileType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, FileType>>(this.RawData, "file_type");
        }
        init { ModelBase.Set(this._rawData, "file_type", value); }
    }

    public required long? NumLines
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "num_lines"); }
        init { ModelBase.Set(this._rawData, "num_lines", value); }
    }

    public required long? StartLine
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "start_line"); }
        init { ModelBase.Set(this._rawData, "start_line", value); }
    }

    public required long? TotalLines
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "total_lines"); }
        init { ModelBase.Set(this._rawData, "total_lines", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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
    BetaTextEditorCodeExecutionViewResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    : IFromRaw<BetaTextEditorCodeExecutionViewResultBlock>
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
    PDF,
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
            "pdf" => FileType.PDF,
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
                FileType.PDF => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
