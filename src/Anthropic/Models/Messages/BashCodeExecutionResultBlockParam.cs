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
    typeof(JsonModelConverter<
        BashCodeExecutionResultBlockParam,
        BashCodeExecutionResultBlockParamFromRaw
    >)
)]
public sealed record class BashCodeExecutionResultBlockParam : JsonModel
{
    public required IReadOnlyList<BashCodeExecutionOutputBlockParam> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BashCodeExecutionOutputBlockParam>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BashCodeExecutionOutputBlockParam>>(
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
                JsonSerializer.SerializeToElement("bash_code_execution_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BashCodeExecutionResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BashCodeExecutionResultBlockParam(
        BashCodeExecutionResultBlockParam bashCodeExecutionResultBlockParam
    )
        : base(bashCodeExecutionResultBlockParam) { }
#pragma warning restore CS8618

    public BashCodeExecutionResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BashCodeExecutionResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BashCodeExecutionResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BashCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BashCodeExecutionResultBlockParamFromRaw : IFromRawJson<BashCodeExecutionResultBlockParam>
{
    /// <inheritdoc/>
    public BashCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BashCodeExecutionResultBlockParam.FromRawUnchecked(rawData);
}
