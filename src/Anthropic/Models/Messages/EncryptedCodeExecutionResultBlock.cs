using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// Code execution result with encrypted stdout for PFC + web_search results.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EncryptedCodeExecutionResultBlock,
        EncryptedCodeExecutionResultBlockFromRaw
    >)
)]
public sealed record class EncryptedCodeExecutionResultBlock : JsonModel
{
    public required IReadOnlyList<CodeExecutionOutputBlock> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CodeExecutionOutputBlock>>(
                "content"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CodeExecutionOutputBlock>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string EncryptedStdout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("encrypted_stdout");
        }
        init { this._rawData.Set("encrypted_stdout", value); }
    }

    public required long ReturnCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("return_code");
        }
        init { this._rawData.Set("return_code", value); }
    }

    public required string Stderr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("stderr");
        }
        init { this._rawData.Set("stderr", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.EncryptedStdout;
        _ = this.ReturnCode;
        _ = this.Stderr;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("encrypted_code_execution_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public EncryptedCodeExecutionResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("encrypted_code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EncryptedCodeExecutionResultBlock(
        EncryptedCodeExecutionResultBlock encryptedCodeExecutionResultBlock
    )
        : base(encryptedCodeExecutionResultBlock) { }
#pragma warning restore CS8618

    public EncryptedCodeExecutionResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("encrypted_code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EncryptedCodeExecutionResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EncryptedCodeExecutionResultBlockFromRaw.FromRawUnchecked"/>
    public static EncryptedCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EncryptedCodeExecutionResultBlockFromRaw : IFromRawJson<EncryptedCodeExecutionResultBlock>
{
    /// <inheritdoc/>
    public EncryptedCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EncryptedCodeExecutionResultBlock.FromRawUnchecked(rawData);
}
