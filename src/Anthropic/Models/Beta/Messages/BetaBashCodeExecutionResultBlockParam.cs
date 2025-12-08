using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaBashCodeExecutionResultBlockParam,
        BetaBashCodeExecutionResultBlockParamFromRaw
    >)
)]
public sealed record class BetaBashCodeExecutionResultBlockParam : ModelBase
{
    public required IReadOnlyList<BetaBashCodeExecutionOutputBlockParam> Content
    {
        get
        {
            return ModelBase.GetNotNullClass<List<BetaBashCodeExecutionOutputBlockParam>>(
                this.RawData,
                "content"
            );
        }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required long ReturnCode
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "return_code"); }
        init { ModelBase.Set(this._rawData, "return_code", value); }
    }

    public required string Stderr
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "stderr"); }
        init { ModelBase.Set(this._rawData, "stderr", value); }
    }

    public required string Stdout
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "stdout"); }
        init { ModelBase.Set(this._rawData, "stdout", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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
                JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

    public BetaBashCodeExecutionResultBlockParam(
        BetaBashCodeExecutionResultBlockParam betaBashCodeExecutionResultBlockParam
    )
        : base(betaBashCodeExecutionResultBlockParam) { }

    public BetaBashCodeExecutionResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBashCodeExecutionResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaBashCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBashCodeExecutionResultBlockParamFromRaw : IFromRaw<BetaBashCodeExecutionResultBlockParam>
{
    /// <inheritdoc/>
    public BetaBashCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBashCodeExecutionResultBlockParam.FromRawUnchecked(rawData);
}
