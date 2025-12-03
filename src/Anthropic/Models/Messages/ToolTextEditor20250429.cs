using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ToolTextEditor20250429, ToolTextEditor20250429FromRaw>))]
public sealed record class ToolTextEditor20250429 : ModelBase
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"str_replace_based_edit_tool\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250429\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ToolTextEditor20250429()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_based_edit_tool\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250429\"");
    }

    public ToolTextEditor20250429(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_based_edit_tool\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250429\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolTextEditor20250429(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolTextEditor20250429FromRaw.FromRawUnchecked"/>
    public static ToolTextEditor20250429 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolTextEditor20250429FromRaw : IFromRaw<ToolTextEditor20250429>
{
    /// <inheritdoc/>
    public ToolTextEditor20250429 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolTextEditor20250429.FromRawUnchecked(rawData);
}
