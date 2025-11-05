using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionViewResultBlockParam>))]
public sealed record class BetaTextEditorCodeExecutionViewResultBlockParam
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionViewResultBlockParam>
{
    public required string Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, FileTypeModel> FileType
    {
        get
        {
            if (!this.Properties.TryGetValue("file_type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'file_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "file_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, FileTypeModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["file_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? NumLines
    {
        get
        {
            if (!this.Properties.TryGetValue("num_lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["num_lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? StartLine
    {
        get
        {
            if (!this.Properties.TryGetValue("start_line", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_line"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? TotalLines
    {
        get
        {
            if (!this.Properties.TryGetValue("total_lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["total_lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        this.FileType.Validate();
        _ = this.Type;
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionViewResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionViewResultBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(FileTypeModelConverter))]
public enum FileTypeModel
{
    Text,
    Image,
    PDF,
}

sealed class FileTypeModelConverter : JsonConverter<FileTypeModel>
{
    public override FileTypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => FileTypeModel.Text,
            "image" => FileTypeModel.Image,
            "pdf" => FileTypeModel.PDF,
            _ => (FileTypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileTypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileTypeModel.Text => "text",
                FileTypeModel.Image => "image",
                FileTypeModel.PDF => "pdf",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
