using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaToolTextEditor20250429, BetaToolTextEditor20250429FromRaw>)
)]
public sealed record class BetaToolTextEditor20250429 : JsonModel
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

    public IReadOnlyList<ApiEnum<string, BetaToolTextEditor20250429AllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaToolTextEditor20250429AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, BetaToolTextEditor20250429AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
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

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defer_loading", value);
        }
    }

    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? InputExamples
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("input_examples");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "input_examples",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.SerializeToElement("str_replace_based_edit_tool")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_20250429")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.InputExamples;
        _ = this.Strict;
    }

    public BetaToolTextEditor20250429()
    {
        this.Name = JsonSerializer.SerializeToElement("str_replace_based_edit_tool");
        this.Type = JsonSerializer.SerializeToElement("text_editor_20250429");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolTextEditor20250429(BetaToolTextEditor20250429 betaToolTextEditor20250429)
        : base(betaToolTextEditor20250429) { }
#pragma warning restore CS8618

    public BetaToolTextEditor20250429(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("str_replace_based_edit_tool");
        this.Type = JsonSerializer.SerializeToElement("text_editor_20250429");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolTextEditor20250429(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolTextEditor20250429FromRaw.FromRawUnchecked"/>
    public static BetaToolTextEditor20250429 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolTextEditor20250429FromRaw : IFromRawJson<BetaToolTextEditor20250429>
{
    /// <inheritdoc/>
    public BetaToolTextEditor20250429 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolTextEditor20250429.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolTextEditor20250429AllowedCallerConverter))]
public enum BetaToolTextEditor20250429AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaToolTextEditor20250429AllowedCallerConverter
    : JsonConverter<BetaToolTextEditor20250429AllowedCaller>
{
    public override BetaToolTextEditor20250429AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaToolTextEditor20250429AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaToolTextEditor20250429AllowedCaller.CodeExecution20250825,
            _ => (BetaToolTextEditor20250429AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolTextEditor20250429AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolTextEditor20250429AllowedCaller.Direct => "direct",
                BetaToolTextEditor20250429AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
