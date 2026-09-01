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
        BetaThinkingDroppedInputTransformation,
        BetaThinkingDroppedInputTransformationFromRaw
    >)
)]
public sealed record class BetaThinkingDroppedInputTransformation : JsonModel
{
    /// <summary>
    /// Where the removed block was in your request, as `messages.{i}.content.{j}`:
    /// `i` indexes the `messages` array you sent and `j` that message's `content`
    /// array — the same form error messages use.
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
    /// Which binding check removed the block: `model_binding_mismatch` — it was
    /// created by a model whose reasoning the requested model may not read; `prefix_binding_mismatch`
    /// — the conversation before it differs from the conversation it was created
    /// in (the rest of that turn's consecutive thinking blocks are removed with it,
    /// each with this reason); `organization_binding_mismatch` — it was created under
    /// a different organization (an Anthropic organization, AWS account or Google
    /// Cloud project) and this organization is not one of its additional organizations;
    /// `end_user_binding_mismatch` — it was created for a different end user, or
    /// was removed by the consumer-organization binding. A block that would fail
    /// several checks reports one reason, in this order of precedence: `organization_binding_mismatch`,
    /// `end_user_binding_mismatch`, `model_binding_mismatch`, `prefix_binding_mismatch`.
    /// </summary>
    public required ApiEnum<string, BetaThinkingDroppedInputTransformationReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaThinkingDroppedInputTransformationReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Always `thinking_dropped` for this entry type.
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
                JsonSerializer.SerializeToElement("thinking_dropped")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingDroppedInputTransformation()
    {
        this.Type = JsonSerializer.SerializeToElement("thinking_dropped");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingDroppedInputTransformation(
        BetaThinkingDroppedInputTransformation betaThinkingDroppedInputTransformation
    )
        : base(betaThinkingDroppedInputTransformation) { }
#pragma warning restore CS8618

    public BetaThinkingDroppedInputTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thinking_dropped");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingDroppedInputTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingDroppedInputTransformationFromRaw.FromRawUnchecked"/>
    public static BetaThinkingDroppedInputTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingDroppedInputTransformationFromRaw
    : IFromRawJson<BetaThinkingDroppedInputTransformation>
{
    /// <inheritdoc/>
    public BetaThinkingDroppedInputTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingDroppedInputTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Which binding check removed the block: `model_binding_mismatch` — it was created
/// by a model whose reasoning the requested model may not read; `prefix_binding_mismatch`
/// — the conversation before it differs from the conversation it was created in
/// (the rest of that turn's consecutive thinking blocks are removed with it, each
/// with this reason); `organization_binding_mismatch` — it was created under a different
/// organization (an Anthropic organization, AWS account or Google Cloud project)
/// and this organization is not one of its additional organizations; `end_user_binding_mismatch`
/// — it was created for a different end user, or was removed by the consumer-organization
/// binding. A block that would fail several checks reports one reason, in this order
/// of precedence: `organization_binding_mismatch`, `end_user_binding_mismatch`,
/// `model_binding_mismatch`, `prefix_binding_mismatch`.
/// </summary>
[JsonConverter(typeof(BetaThinkingDroppedInputTransformationReasonConverter))]
public enum BetaThinkingDroppedInputTransformationReason
{
    ModelBindingMismatch,
    PrefixBindingMismatch,
    OrganizationBindingMismatch,
    EndUserBindingMismatch,
}

sealed class BetaThinkingDroppedInputTransformationReasonConverter
    : JsonConverter<BetaThinkingDroppedInputTransformationReason>
{
    public override BetaThinkingDroppedInputTransformationReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "model_binding_mismatch" =>
                BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
            "prefix_binding_mismatch" =>
                BetaThinkingDroppedInputTransformationReason.PrefixBindingMismatch,
            "organization_binding_mismatch" =>
                BetaThinkingDroppedInputTransformationReason.OrganizationBindingMismatch,
            "end_user_binding_mismatch" =>
                BetaThinkingDroppedInputTransformationReason.EndUserBindingMismatch,
            _ => (BetaThinkingDroppedInputTransformationReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingDroppedInputTransformationReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch =>
                    "model_binding_mismatch",
                BetaThinkingDroppedInputTransformationReason.PrefixBindingMismatch =>
                    "prefix_binding_mismatch",
                BetaThinkingDroppedInputTransformationReason.OrganizationBindingMismatch =>
                    "organization_binding_mismatch",
                BetaThinkingDroppedInputTransformationReason.EndUserBindingMismatch =>
                    "end_user_binding_mismatch",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
