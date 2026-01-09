using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCodeExecutionResultBlock, BetaCodeExecutionResultBlockFromRaw>)
)]
public sealed record class BetaCodeExecutionResultBlock : JsonModel
{
    public required IReadOnlyList<BetaCodeExecutionOutputBlock> Content
    {
        get
        {
            return JsonModel.GetNotNullClass<List<BetaCodeExecutionOutputBlock>>(
                this.RawData,
                "content"
            );
        }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public required long ReturnCode
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "return_code"); }
        init { JsonModel.Set(this._rawData, "return_code", value); }
    }

    public required string Stderr
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "stderr"); }
        init { JsonModel.Set(this._rawData, "stderr", value); }
    }

    public required string Stdout
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "stdout"); }
        init { JsonModel.Set(this._rawData, "stdout", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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

    public BetaCodeExecutionResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_result\"");
    }

    public BetaCodeExecutionResultBlock(BetaCodeExecutionResultBlock betaCodeExecutionResultBlock)
        : base(betaCodeExecutionResultBlock) { }

    public BetaCodeExecutionResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCodeExecutionResultBlockFromRaw : IFromRawJson<BetaCodeExecutionResultBlock>
{
    /// <inheritdoc/>
    public BetaCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionResultBlock.FromRawUnchecked(rawData);
}
