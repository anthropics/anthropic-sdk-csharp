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
        EncryptedCodeExecutionResultBlockParam,
        EncryptedCodeExecutionResultBlockParamFromRaw
    >)
)]
public sealed record class EncryptedCodeExecutionResultBlockParam : JsonModel
{
    public required IReadOnlyList<CodeExecutionOutputBlockParam> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CodeExecutionOutputBlockParam>>(
                "content"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CodeExecutionOutputBlockParam>>(
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

    public EncryptedCodeExecutionResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("encrypted_code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EncryptedCodeExecutionResultBlockParam(
        EncryptedCodeExecutionResultBlockParam encryptedCodeExecutionResultBlockParam
    )
        : base(encryptedCodeExecutionResultBlockParam) { }
#pragma warning restore CS8618

    public EncryptedCodeExecutionResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("encrypted_code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EncryptedCodeExecutionResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EncryptedCodeExecutionResultBlockParamFromRaw.FromRawUnchecked"/>
    public static EncryptedCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EncryptedCodeExecutionResultBlockParamFromRaw
    : IFromRawJson<EncryptedCodeExecutionResultBlockParam>
{
    /// <inheritdoc/>
    public EncryptedCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EncryptedCodeExecutionResultBlockParam.FromRawUnchecked(rawData);
}
