using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ToolBash20250124, ToolBash20250124FromRaw>))]
public sealed record class ToolBash20250124 : ModelBase
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
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.Deserialize<JsonElement>("\"bash\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ToolBash20250124()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
    }

    public ToolBash20250124(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolBash20250124(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolBash20250124FromRaw.FromRawUnchecked"/>
    public static ToolBash20250124 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolBash20250124FromRaw : IFromRaw<ToolBash20250124>
{
    /// <inheritdoc/>
    public ToolBash20250124 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolBash20250124.FromRawUnchecked(rawData);
}
