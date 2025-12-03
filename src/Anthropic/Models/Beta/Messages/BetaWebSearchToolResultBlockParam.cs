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
        BetaWebSearchToolResultBlockParam,
        BetaWebSearchToolResultBlockParamFromRaw
    >)
)]
public sealed record class BetaWebSearchToolResultBlockParam : ModelBase
{
    public required BetaWebSearchToolResultBlockParamContent Content
    {
        get
        {
            return ModelBase.GetNotNullClass<BetaWebSearchToolResultBlockParamContent>(
                this.RawData,
                "content"
            );
        }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required string ToolUseID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tool_use_id"); }
        init { ModelBase.Set(this._rawData, "tool_use_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
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

    public BetaWebSearchToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaWebSearchToolResultBlockParamFromRaw : IFromRaw<BetaWebSearchToolResultBlockParam>
{
    /// <inheritdoc/>
    public BetaWebSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebSearchToolResultBlockParam.FromRawUnchecked(rawData);
}
