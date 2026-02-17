using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionResultBlockParam, CodeExecutionResultBlockParamFromRaw>)
)]
public sealed record class CodeExecutionResultBlockParam : JsonModel
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

    public required string Stdout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("stdout");
        }
        init { this._rawData.Set("stdout", value); }
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
        _ = this.ReturnCode;
        _ = this.Stderr;
        _ = this.Stdout;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CodeExecutionResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionResultBlockParam(
        CodeExecutionResultBlockParam codeExecutionResultBlockParam
    )
        : base(codeExecutionResultBlockParam) { }
#pragma warning restore CS8618

    public CodeExecutionResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionResultBlockParamFromRaw.FromRawUnchecked"/>
    public static CodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionResultBlockParamFromRaw : IFromRawJson<CodeExecutionResultBlockParam>
{
    /// <inheritdoc/>
    public CodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionResultBlockParam.FromRawUnchecked(rawData);
}
