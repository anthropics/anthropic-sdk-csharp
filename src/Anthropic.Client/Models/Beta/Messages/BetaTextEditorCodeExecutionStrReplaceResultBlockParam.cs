using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>))]
public sealed record class BetaTextEditorCodeExecutionStrReplaceResultBlockParam
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>
{
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

    public List<string>? Lines
    {
        get
        {
            if (!this._properties.TryGetValue("lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? NewLines
    {
        get
        {
            if (!this._properties.TryGetValue("new_lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["new_lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? NewStart
    {
        get
        {
            if (!this._properties.TryGetValue("new_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["new_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? OldLines
    {
        get
        {
            if (!this._properties.TryGetValue("old_lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["old_lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? OldStart
    {
        get
        {
            if (!this._properties.TryGetValue("old_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["old_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_str_replace_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionStrReplaceResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
