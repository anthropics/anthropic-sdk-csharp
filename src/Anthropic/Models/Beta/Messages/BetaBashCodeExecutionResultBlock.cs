using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaBashCodeExecutionResultBlock,
        BetaBashCodeExecutionResultBlockFromRaw
    >)
)]
public sealed record class BetaBashCodeExecutionResultBlock : JsonModel
{
    public required IReadOnlyList<BetaBashCodeExecutionOutputBlock> Content
    {
        get
        {
            return JsonModel.GetNotNullClass<List<BetaBashCodeExecutionOutputBlock>>(
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
                JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

    public BetaBashCodeExecutionResultBlock(
        BetaBashCodeExecutionResultBlock betaBashCodeExecutionResultBlock
    )
        : base(betaBashCodeExecutionResultBlock) { }

    public BetaBashCodeExecutionResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBashCodeExecutionResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaBashCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBashCodeExecutionResultBlockFromRaw : IFromRawJson<BetaBashCodeExecutionResultBlock>
{
    /// <inheritdoc/>
    public BetaBashCodeExecutionResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBashCodeExecutionResultBlock.FromRawUnchecked(rawData);
}
