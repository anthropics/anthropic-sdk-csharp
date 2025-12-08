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
        BetaCodeExecutionResultBlockParam,
        BetaCodeExecutionResultBlockParamFromRaw
    >)
)]
public sealed record class BetaCodeExecutionResultBlockParam : ModelBase
{
    public required IReadOnlyList<BetaCodeExecutionOutputBlockParam> Content
    {
        get
        {
            return ModelBase.GetNotNullClass<List<BetaCodeExecutionOutputBlockParam>>(
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
                JsonSerializer.Deserialize<JsonElement>("\"code_execution_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCodeExecutionResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_result\"");
    }

    public BetaCodeExecutionResultBlockParam(
        BetaCodeExecutionResultBlockParam betaCodeExecutionResultBlockParam
    )
        : base(betaCodeExecutionResultBlockParam) { }

    public BetaCodeExecutionResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCodeExecutionResultBlockParamFromRaw : IFromRaw<BetaCodeExecutionResultBlockParam>
{
    /// <inheritdoc/>
    public BetaCodeExecutionResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionResultBlockParam.FromRawUnchecked(rawData);
}
