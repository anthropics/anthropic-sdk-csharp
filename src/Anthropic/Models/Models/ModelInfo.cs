using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Models;

[JsonConverter(typeof(ModelConverter<ModelInfo, ModelInfoFromRaw>))]
public sealed record class ModelInfo : ModelBase
{
    /// <summary>
    /// Unique model identifier.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the model was released.
    /// May be set to an epoch value if the release date is unknown.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// A human-readable name for the model.
    /// </summary>
    public required string DisplayName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "display_name"); }
        init { ModelBase.Set(this._rawData, "display_name", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Models, this is always `"model"`.</para>
    /// </summary>
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"model\""))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ModelInfo()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"model\"");
    }

    public ModelInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"model\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelInfoFromRaw.FromRawUnchecked"/>
    public static ModelInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelInfoFromRaw : IFromRaw<ModelInfo>
{
    /// <inheritdoc/>
    public ModelInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelInfo.FromRawUnchecked(rawData);
}
