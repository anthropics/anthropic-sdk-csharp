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
        BetaCodeExecutionOutputBlockParam,
        BetaCodeExecutionOutputBlockParamFromRaw
    >)
)]
public sealed record class BetaCodeExecutionOutputBlockParam : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCodeExecutionOutputBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\"");
    }

    public BetaCodeExecutionOutputBlockParam(
        BetaCodeExecutionOutputBlockParam betaCodeExecutionOutputBlockParam
    )
        : base(betaCodeExecutionOutputBlockParam) { }

    public BetaCodeExecutionOutputBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionOutputBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionOutputBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionOutputBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCodeExecutionOutputBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaCodeExecutionOutputBlockParamFromRaw : IFromRaw<BetaCodeExecutionOutputBlockParam>
{
    /// <inheritdoc/>
    public BetaCodeExecutionOutputBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionOutputBlockParam.FromRawUnchecked(rawData);
}
