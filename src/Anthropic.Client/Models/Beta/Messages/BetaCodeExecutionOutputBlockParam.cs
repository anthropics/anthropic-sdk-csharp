using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCodeExecutionOutputBlockParam>))]
public sealed record class BetaCodeExecutionOutputBlockParam
    : ModelBase,
        IFromRaw<BetaCodeExecutionOutputBlockParam>
{
    public required string FileID
    {
        get
        {
            if (!this._properties.TryGetValue("file_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'file_id' cannot be null",
                    new ArgumentOutOfRangeException("file_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'file_id' cannot be null",
                    new ArgumentNullException("file_id")
                );
        }
        init
        {
            this._properties["file_id"] = JsonSerializer.SerializeToElement(
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
        _ = this.FileID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCodeExecutionOutputBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\"");
    }

    public BetaCodeExecutionOutputBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionOutputBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaCodeExecutionOutputBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaCodeExecutionOutputBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}
