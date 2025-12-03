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
        BetaBashCodeExecutionOutputBlockParam,
        BetaBashCodeExecutionOutputBlockParamFromRaw
    >)
)]
public sealed record class BetaBashCodeExecutionOutputBlockParam : ModelBase
{
    public required string FileID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_output\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionOutputBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_output\"");
    }

    public BetaBashCodeExecutionOutputBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionOutputBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBashCodeExecutionOutputBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaBashCodeExecutionOutputBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBashCodeExecutionOutputBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaBashCodeExecutionOutputBlockParamFromRaw : IFromRaw<BetaBashCodeExecutionOutputBlockParam>
{
    /// <inheritdoc/>
    public BetaBashCodeExecutionOutputBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBashCodeExecutionOutputBlockParam.FromRawUnchecked(rawData);
}
