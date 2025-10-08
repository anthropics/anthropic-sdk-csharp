using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCodeExecutionResultBlockParam>))]
public sealed record class BetaCodeExecutionResultBlockParam
    : ModelBase,
        IFromRaw<BetaCodeExecutionResultBlockParam>
{
    public required List<BetaCodeExecutionOutputBlockParam> Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BetaCodeExecutionOutputBlockParam>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentNullException("content")
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

    public required long ReturnCode
    {
        get
        {
            if (!this.Properties.TryGetValue("return_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'return_code' cannot be null",
                    new ArgumentOutOfRangeException("return_code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["return_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Stderr
    {
        get
        {
            if (!this.Properties.TryGetValue("stderr", out JsonElement element))
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
        set
        {
            this.Properties["stderr"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Stdout
    {
        get
        {
            if (!this.Properties.TryGetValue("stdout", out JsonElement element))
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
        set
        {
            this.Properties["stdout"] = JsonSerializer.SerializeToElement(
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
                    new ArgumentOutOfRangeException("type", "Missing required argument")
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

    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.ReturnCode;
        _ = this.Stderr;
        _ = this.Stdout;
    }

    public BetaCodeExecutionResultBlockParam()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCodeExecutionResultBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
