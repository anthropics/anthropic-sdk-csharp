using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Models;

[JsonConverter(typeof(JsonModelConverter<ModelInfo, ModelInfoFromRaw>))]
public sealed record class ModelInfo : JsonModel
{
    /// <summary>
    /// Unique model identifier.
    /// </summary>
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
    /// RFC 3339 datetime string representing the time at which the model was released.
    /// May be set to an epoch value if the release date is unknown.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A human-readable name for the model.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Models, this is always `"model"`.</para>
    /// </summary>
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
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("model")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ModelInfo()
    {
        this.Type = JsonSerializer.SerializeToElement("model");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelInfo(ModelInfo modelInfo)
        : base(modelInfo) { }
#pragma warning restore CS8618

    public ModelInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("model");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelInfoFromRaw.FromRawUnchecked"/>
    public static ModelInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelInfoFromRaw : IFromRawJson<ModelInfo>
{
    /// <inheritdoc/>
    public ModelInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelInfo.FromRawUnchecked(rawData);
}
