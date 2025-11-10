using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaBashCodeExecutionResultBlock>))]
public sealed record class BetaBashCodeExecutionResultBlock
    : ModelBase,
        IFromRaw<BetaBashCodeExecutionResultBlock>
{
    public required List<BetaBashCodeExecutionOutputBlock> Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BetaBashCodeExecutionOutputBlock>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentNullException("content")
                );
        }
        init
        {
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long ReturnCode
    {
        get
        {
            if (!this._properties.TryGetValue("return_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'return_code' cannot be null",
                    new ArgumentOutOfRangeException("return_code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["return_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Stderr
    {
        get
        {
            if (!this._properties.TryGetValue("stderr", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'stderr' cannot be null",
                    new ArgumentOutOfRangeException("stderr", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'stderr' cannot be null",
                    new ArgumentNullException("stderr")
                );
        }
        init
        {
            this._properties["stderr"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Stdout
    {
        get
        {
            if (!this._properties.TryGetValue("stdout", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'stdout' cannot be null",
                    new ArgumentOutOfRangeException("stdout", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'stdout' cannot be null",
                    new ArgumentNullException("stdout")
                );
        }
        init
        {
            this._properties["stdout"] = JsonSerializer.SerializeToElement(
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
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.ReturnCode;
        _ = this.Stderr;
        _ = this.Stdout;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

    public BetaBashCodeExecutionResultBlock(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionResultBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaBashCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
