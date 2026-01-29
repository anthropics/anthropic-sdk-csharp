using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<OutputConfig, OutputConfigFromRaw>))]
public sealed record class OutputConfig : JsonModel
{
    /// <summary>
    /// A schema to specify Claude's output format in responses. See [structured outputs](https://platform.claude.com/docs/en/build-with-claude/structured-outputs)
    /// </summary>
    public JsonOutputFormat? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JsonOutputFormat>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Format?.Validate();
    }

    public OutputConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputConfig(OutputConfig outputConfig)
        : base(outputConfig) { }
#pragma warning restore CS8618

    public OutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputConfigFromRaw.FromRawUnchecked"/>
    public static OutputConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputConfigFromRaw : IFromRawJson<OutputConfig>
{
    /// <inheritdoc/>
    public OutputConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OutputConfig.FromRawUnchecked(rawData);
}
