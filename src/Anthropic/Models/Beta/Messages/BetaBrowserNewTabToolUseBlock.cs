using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserNewTabToolUseBlock, BetaBrowserNewTabToolUseBlockFromRaw>)
)]
public sealed record class BetaBrowserNewTabToolUseBlock : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Open a new empty tab and return its tab_id.
    /// </summary>
    public required BetaBrowserNewTabInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserNewTabInput>("input");
        }
        init { this._rawData.Set("input", value); }
    }

    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement ToolsetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("toolset_name");
        }
        init { this._rawData.Set("toolset_name", value); }
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

    /// <summary>
    /// Which party invoked the tool call: the model directly, or a server tool on
    /// its behalf.
    /// </summary>
    public BetaToolUseCaller? Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaToolUseCaller>("caller");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("caller");
                return;
            }

            this._rawData.Set("caller", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Input.Validate();
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("new_tab")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.ToolsetName, JsonSerializer.SerializeToElement("browser")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_use")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Caller?.Validate();
    }

    public BetaBrowserNewTabToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("new_tab");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserNewTabToolUseBlock(
        BetaBrowserNewTabToolUseBlock betaBrowserNewTabToolUseBlock
    )
        : base(betaBrowserNewTabToolUseBlock) { }
#pragma warning restore CS8618

    public BetaBrowserNewTabToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("new_tab");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserNewTabToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserNewTabToolUseBlockFromRaw.FromRawUnchecked"/>
    public static BetaBrowserNewTabToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserNewTabToolUseBlockFromRaw : IFromRawJson<BetaBrowserNewTabToolUseBlock>
{
    /// <inheritdoc/>
    public BetaBrowserNewTabToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserNewTabToolUseBlock.FromRawUnchecked(rawData);
}
