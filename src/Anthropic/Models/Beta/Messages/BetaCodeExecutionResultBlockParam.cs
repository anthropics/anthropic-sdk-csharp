using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaCodeExecutionResultBlockParam>))]
public sealed record class BetaCodeExecutionResultBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCodeExecutionResultBlockParam>
{
    public required Generic::List<BetaCodeExecutionOutputBlockParam> Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<BetaCodeExecutionOutputBlockParam>>(
                    element
                ) ?? throw new System::ArgumentNullException("content");
        }
        set { this.Properties["content"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long ReturnCode
    {
        get
        {
            if (!this.Properties.TryGetValue("return_code", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "return_code",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["return_code"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Stderr
    {
        get
        {
            if (!this.Properties.TryGetValue("stderr", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "stderr",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("stderr");
        }
        set { this.Properties["stderr"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Stdout
    {
        get
        {
            if (!this.Properties.TryGetValue("stdout", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "stdout",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("stdout");
        }
        set { this.Properties["stdout"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
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
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"code_execution_result\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public BetaCodeExecutionResultBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"code_execution_result\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaCodeExecutionResultBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCodeExecutionResultBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
