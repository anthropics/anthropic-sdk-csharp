using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaCodeExecutionOutputBlock>))]
public sealed record class BetaCodeExecutionOutputBlock
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCodeExecutionOutputBlock>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "file_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("file_id");
        }
        set { this.Properties["file_id"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.FileID;
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"code_execution_output\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public BetaCodeExecutionOutputBlock()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"code_execution_output\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaCodeExecutionOutputBlock(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCodeExecutionOutputBlock FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
