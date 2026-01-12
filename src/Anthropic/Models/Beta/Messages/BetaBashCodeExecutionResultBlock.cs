using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaBashCodeExecutionOutputBlock>>(
                "content"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaBashCodeExecutionOutputBlock>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long ReturnCode
    {
        get { return this._rawData.GetNotNullStruct<long>("return_code"); }
        init { this._rawData.Set("return_code", value); }
    }

    public required string Stderr
    {
        get { return this._rawData.GetNotNullClass<string>("stderr"); }
        init { this._rawData.Set("stderr", value); }
    }

    public required string Stdout
    {
        get { return this._rawData.GetNotNullClass<string>("stdout"); }
        init { this._rawData.Set("stdout", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
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
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
