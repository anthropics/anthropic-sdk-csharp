using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaThinkingMismatchAllowedInputTransformation,
        BetaThinkingMismatchAllowedInputTransformationFromRaw
    >)
)]
public sealed record class BetaThinkingMismatchAllowedInputTransformation : JsonModel
{
    /// <summary>
    /// Where the block is in your request, as `messages.{i}.content.{j}`: `i` indexes
    /// the `messages` array you sent and `j` that message's `content` array — the
    /// same form error messages use.
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// Which binding check the block failed; the block was shown to the model all
    /// the same. Always `prefix_binding_mismatch` today — the conversation before
    /// the block differs from the conversation it was created in, or the block carries
    /// no record of one on a model that requires it. Were the check enforced for
    /// this request, the block would have been removed or the request rejected (`thinking.block_binding.prefix_mismatch_behavior`).
    /// A removal also takes the rest of that turn's consecutive thinking blocks,
    /// whereas here each block is checked on its own, so `thinking_mismatch_allowed`
    /// entries are a lower bound on what enforcement would remove.
    /// </summary>
    public required ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Always `thinking_mismatch_allowed` for this entry type.
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
        _ = this.Path;
        this.Reason.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("thinking_mismatch_allowed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingMismatchAllowedInputTransformation()
    {
        this.Type = JsonSerializer.SerializeToElement("thinking_mismatch_allowed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingMismatchAllowedInputTransformation(
        BetaThinkingMismatchAllowedInputTransformation betaThinkingMismatchAllowedInputTransformation
    )
        : base(betaThinkingMismatchAllowedInputTransformation) { }
#pragma warning restore CS8618

    public BetaThinkingMismatchAllowedInputTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thinking_mismatch_allowed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingMismatchAllowedInputTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingMismatchAllowedInputTransformationFromRaw.FromRawUnchecked"/>
    public static BetaThinkingMismatchAllowedInputTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingMismatchAllowedInputTransformationFromRaw
    : IFromRawJson<BetaThinkingMismatchAllowedInputTransformation>
{
    /// <inheritdoc/>
    public BetaThinkingMismatchAllowedInputTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingMismatchAllowedInputTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Which binding check the block failed; the block was shown to the model all the
/// same. Always `prefix_binding_mismatch` today — the conversation before the block
/// differs from the conversation it was created in, or the block carries no record
/// of one on a model that requires it. Were the check enforced for this request,
/// the block would have been removed or the request rejected (`thinking.block_binding.prefix_mismatch_behavior`).
/// A removal also takes the rest of that turn's consecutive thinking blocks, whereas
/// here each block is checked on its own, so `thinking_mismatch_allowed` entries
/// are a lower bound on what enforcement would remove.
/// </summary>
[JsonConverter(typeof(BetaThinkingMismatchAllowedInputTransformationReasonConverter))]
public enum BetaThinkingMismatchAllowedInputTransformationReason
{
    ModelBindingMismatch,
    PrefixBindingMismatch,
    OrganizationBindingMismatch,
    EndUserBindingMismatch,
}

sealed class BetaThinkingMismatchAllowedInputTransformationReasonConverter
    : JsonConverter<BetaThinkingMismatchAllowedInputTransformationReason>
{
    public override BetaThinkingMismatchAllowedInputTransformationReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "model_binding_mismatch" =>
                BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
            "prefix_binding_mismatch" =>
                BetaThinkingMismatchAllowedInputTransformationReason.PrefixBindingMismatch,
            "organization_binding_mismatch" =>
                BetaThinkingMismatchAllowedInputTransformationReason.OrganizationBindingMismatch,
            "end_user_binding_mismatch" =>
                BetaThinkingMismatchAllowedInputTransformationReason.EndUserBindingMismatch,
            _ => (BetaThinkingMismatchAllowedInputTransformationReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingMismatchAllowedInputTransformationReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch =>
                    "model_binding_mismatch",
                BetaThinkingMismatchAllowedInputTransformationReason.PrefixBindingMismatch =>
                    "prefix_binding_mismatch",
                BetaThinkingMismatchAllowedInputTransformationReason.OrganizationBindingMismatch =>
                    "organization_binding_mismatch",
                BetaThinkingMismatchAllowedInputTransformationReason.EndUserBindingMismatch =>
                    "end_user_binding_mismatch",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
