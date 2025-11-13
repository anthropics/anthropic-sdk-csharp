using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionCreateResultBlock>))]
public sealed record class BetaTextEditorCodeExecutionCreateResultBlock
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionCreateResultBlock>
{
    public required bool IsFileUpdate
    {
        get
        {
            if (!this._properties.TryGetValue("is_file_update", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'is_file_update' cannot be null",
                    new ArgumentOutOfRangeException("is_file_update", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["is_file_update"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public BetaTextEditorCodeExecutionCreateResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );
    }

    public BetaTextEditorCodeExecutionCreateResultBlock(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionCreateResultBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionCreateResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaTextEditorCodeExecutionCreateResultBlock(bool isFileUpdate)
        : this()
    {
        this.IsFileUpdate = isFileUpdate;
    }
}
