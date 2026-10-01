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
/// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
///
/// <para>This defines the shape of the `input` that your tool accepts and that the
/// model will produce.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaResponseToolInputSchema, BetaResponseToolInputSchemaFromRaw>)
)]
public sealed record class BetaResponseToolInputSchema : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<string>? Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("required");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("object")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Properties;
        _ = this.Required;
    }

    public BetaResponseToolInputSchema()
    {
        this.Type = JsonSerializer.SerializeToElement("object");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaResponseToolInputSchema(BetaResponseToolInputSchema betaResponseToolInputSchema)
        : base(betaResponseToolInputSchema) { }
#pragma warning restore CS8618

    public BetaResponseToolInputSchema(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("object");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaResponseToolInputSchema(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaResponseToolInputSchemaFromRaw.FromRawUnchecked"/>
    public static BetaResponseToolInputSchema FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaResponseToolInputSchemaFromRaw : IFromRawJson<BetaResponseToolInputSchema>
{
    /// <inheritdoc/>
    public BetaResponseToolInputSchema FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaResponseToolInputSchema.FromRawUnchecked(rawData);
}
