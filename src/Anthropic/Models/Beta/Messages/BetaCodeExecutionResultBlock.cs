using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaCodeExecutionResultBlock>))]
public sealed record class BetaCodeExecutionResultBlock
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCodeExecutionResultBlock>
{
    public required List<BetaCodeExecutionOutputBlock> Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<BetaCodeExecutionOutputBlock>>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("content");
        }
        set { this.Properties["content"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long ReturnCode
    {
        get
        {
            if (!this.Properties.TryGetValue("return_code", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "return_code",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["return_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Stderr
    {
        get
        {
            if (!this.Properties.TryGetValue("stderr", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "stderr",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("stderr");
        }
        set { this.Properties["stderr"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Stdout
    {
        get
        {
            if (!this.Properties.TryGetValue("stdout", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "stdout",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("stdout");
        }
        set { this.Properties["stdout"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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

    public BetaCodeExecutionResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCodeExecutionResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
