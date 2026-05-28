using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// System instructions that appear mid-conversation.
///
/// <para>Use this block to provide or update system-level instructions at a specific
/// point in the conversation, rather than only via the top-level `system` parameter.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaMidConversationSystemBlockParam,
        BetaMidConversationSystemBlockParamFromRaw
    >)
)]
public sealed record class BetaMidConversationSystemBlockParam : JsonModel
{
    /// <summary>
    /// System instruction text blocks.
    /// </summary>
    public required IReadOnlyList<BetaTextBlockParam> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaTextBlockParam>>("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaTextBlockParam>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mid_conv_system"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaMidConversationSystemBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("mid_conv_system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMidConversationSystemBlockParam(
        BetaMidConversationSystemBlockParam betaMidConversationSystemBlockParam
    )
        : base(betaMidConversationSystemBlockParam) { }
#pragma warning restore CS8618

    public BetaMidConversationSystemBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mid_conv_system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMidConversationSystemBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMidConversationSystemBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaMidConversationSystemBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMidConversationSystemBlockParam(IReadOnlyList<BetaTextBlockParam> content)
        : this()
    {
        this.Content = content;
    }
}

class BetaMidConversationSystemBlockParamFromRaw : IFromRawJson<BetaMidConversationSystemBlockParam>
{
    /// <inheritdoc/>
    public BetaMidConversationSystemBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMidConversationSystemBlockParam.FromRawUnchecked(rawData);
}
