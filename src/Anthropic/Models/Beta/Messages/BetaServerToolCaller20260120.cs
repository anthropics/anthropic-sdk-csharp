using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaServerToolCaller20260120, BetaServerToolCaller20260120FromRaw>)
)]
public sealed record class BetaServerToolCaller20260120 : JsonModel
{
    public required string ToolID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_id");
        }
        init { this._rawData.Set("tool_id", value); }
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
        _ = this.ToolID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_20260120")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaServerToolCaller20260120()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServerToolCaller20260120(BetaServerToolCaller20260120 betaServerToolCaller20260120)
        : base(betaServerToolCaller20260120) { }
#pragma warning restore CS8618

    public BetaServerToolCaller20260120(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolCaller20260120(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServerToolCaller20260120FromRaw.FromRawUnchecked"/>
    public static BetaServerToolCaller20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaServerToolCaller20260120(string toolID)
        : this()
    {
        this.ToolID = toolID;
    }
}

class BetaServerToolCaller20260120FromRaw : IFromRawJson<BetaServerToolCaller20260120>
{
    /// <inheritdoc/>
    public BetaServerToolCaller20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaServerToolCaller20260120.FromRawUnchecked(rawData);
}
