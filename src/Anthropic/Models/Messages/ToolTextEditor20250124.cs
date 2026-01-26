using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ToolTextEditor20250124, ToolTextEditor20250124FromRaw>))]
public sealed record class ToolTextEditor20250124 : JsonModel
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
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
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.SerializeToElement("str_replace_editor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_20250124")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ToolTextEditor20250124()
    {
        this.Name = JsonSerializer.SerializeToElement("str_replace_editor");
        this.Type = JsonSerializer.SerializeToElement("text_editor_20250124");
    }

    public ToolTextEditor20250124(ToolTextEditor20250124 toolTextEditor20250124)
        : base(toolTextEditor20250124) { }

    public ToolTextEditor20250124(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("str_replace_editor");
        this.Type = JsonSerializer.SerializeToElement("text_editor_20250124");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolTextEditor20250124(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolTextEditor20250124FromRaw.FromRawUnchecked"/>
    public static ToolTextEditor20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolTextEditor20250124FromRaw : IFromRawJson<ToolTextEditor20250124>
{
    /// <inheritdoc/>
    public ToolTextEditor20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolTextEditor20250124.FromRawUnchecked(rawData);
}
