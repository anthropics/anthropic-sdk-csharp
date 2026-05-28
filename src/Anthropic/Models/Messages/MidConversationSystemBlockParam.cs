using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// System instructions that appear mid-conversation.
///
/// <para>Use this block to provide or update system-level instructions at a specific
/// point in the conversation, rather than only via the top-level `system` parameter.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MidConversationSystemBlockParam,
        MidConversationSystemBlockParamFromRaw
    >)
)]
public sealed record class MidConversationSystemBlockParam : JsonModel
{
    /// <summary>
    /// System instruction text blocks.
    /// </summary>
    public required IReadOnlyList<TextBlockParam> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TextBlockParam>>("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TextBlockParam>>(
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
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
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

    public MidConversationSystemBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("mid_conv_system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MidConversationSystemBlockParam(
        MidConversationSystemBlockParam midConversationSystemBlockParam
    )
        : base(midConversationSystemBlockParam) { }
#pragma warning restore CS8618

    public MidConversationSystemBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mid_conv_system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MidConversationSystemBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MidConversationSystemBlockParamFromRaw.FromRawUnchecked"/>
    public static MidConversationSystemBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MidConversationSystemBlockParam(IReadOnlyList<TextBlockParam> content)
        : this()
    {
        this.Content = content;
    }
}

class MidConversationSystemBlockParamFromRaw : IFromRawJson<MidConversationSystemBlockParam>
{
    /// <inheritdoc/>
    public MidConversationSystemBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MidConversationSystemBlockParam.FromRawUnchecked(rawData);
}
