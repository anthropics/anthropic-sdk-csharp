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
        BetaWebSearchToolResultBlockParam,
        BetaWebSearchToolResultBlockParamFromRaw
    >)
)]
public sealed record class BetaWebSearchToolResultBlockParam : JsonModel
{
    public required BetaWebSearchToolResultBlockParamContent Content
    {
        get
        {
            return this._rawData.GetNotNullClass<BetaWebSearchToolResultBlockParamContent>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get { return this._rawData.GetNotNullClass<string>("tool_use_id"); }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get { return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control"); }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaWebSearchToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

    public BetaWebSearchToolResultBlockParam(
        BetaWebSearchToolResultBlockParam betaWebSearchToolResultBlockParam
    )
        : base(betaWebSearchToolResultBlockParam) { }

    public BetaWebSearchToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebSearchToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaWebSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebSearchToolResultBlockParamFromRaw : IFromRawJson<BetaWebSearchToolResultBlockParam>
{
    /// <inheritdoc/>
    public BetaWebSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebSearchToolResultBlockParam.FromRawUnchecked(rawData);
}
