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
        BetaCodeExecutionOutputBlockParam,
        BetaCodeExecutionOutputBlockParamFromRaw
    >)
)]
public sealed record class BetaCodeExecutionOutputBlockParam : JsonModel
{
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
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
        _ = this.FileID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_output")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCodeExecutionOutputBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCodeExecutionOutputBlockParam(
        BetaCodeExecutionOutputBlockParam betaCodeExecutionOutputBlockParam
    )
        : base(betaCodeExecutionOutputBlockParam) { }
#pragma warning restore CS8618

    public BetaCodeExecutionOutputBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionOutputBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BetaCodeExecutionOutputBlockParamFromRaw : IFromRawJson<BetaCodeExecutionOutputBlockParam>
{
    /// <inheritdoc/>
    public BetaCodeExecutionOutputBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionOutputBlockParam.FromRawUnchecked(rawData);
}
