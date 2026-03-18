using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Model capability information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaModelCapabilities, BetaModelCapabilitiesFromRaw>))]
public sealed record class BetaModelCapabilities : JsonModel
{
    /// <summary>
    /// Whether the model supports the Batch API.
    /// </summary>
    public required BetaCapabilitySupport Batch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("batch");
        }
        init { this._rawData.Set("batch", value); }
    }

    /// <summary>
    /// Whether the model supports citation generation.
    /// </summary>
    public required BetaCapabilitySupport Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("citations");
        }
        init { this._rawData.Set("citations", value); }
    }

    /// <summary>
    /// Whether the model supports code execution tools.
    /// </summary>
    public required BetaCapabilitySupport CodeExecution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("code_execution");
        }
        init { this._rawData.Set("code_execution", value); }
    }

    /// <summary>
    /// Context management support and available strategies.
    /// </summary>
    public required BetaContextManagementCapability ContextManagement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaContextManagementCapability>(
                "context_management"
            );
        }
        init { this._rawData.Set("context_management", value); }
    }

    /// <summary>
    /// Effort (reasoning_effort) support and available levels.
    /// </summary>
    public required BetaEffortCapability Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaEffortCapability>("effort");
        }
        init { this._rawData.Set("effort", value); }
    }

    /// <summary>
    /// Whether the model accepts image content blocks.
    /// </summary>
    public required BetaCapabilitySupport ImageInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("image_input");
        }
        init { this._rawData.Set("image_input", value); }
    }

    /// <summary>
    /// Whether the model accepts PDF content blocks.
    /// </summary>
    public required BetaCapabilitySupport PdfInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("pdf_input");
        }
        init { this._rawData.Set("pdf_input", value); }
    }

    /// <summary>
    /// Whether the model supports structured output / JSON mode / strict tool schemas.
    /// </summary>
    public required BetaCapabilitySupport StructuredOutputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("structured_outputs");
        }
        init { this._rawData.Set("structured_outputs", value); }
    }

    /// <summary>
    /// Thinking capability and supported type configurations.
    /// </summary>
    public required BetaThinkingCapability Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaThinkingCapability>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Batch.Validate();
        this.Citations.Validate();
        this.CodeExecution.Validate();
        this.ContextManagement.Validate();
        this.Effort.Validate();
        this.ImageInput.Validate();
        this.PdfInput.Validate();
        this.StructuredOutputs.Validate();
        this.Thinking.Validate();
    }

    public BetaModelCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaModelCapabilities(BetaModelCapabilities betaModelCapabilities)
        : base(betaModelCapabilities) { }
#pragma warning restore CS8618

    public BetaModelCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaModelCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaModelCapabilitiesFromRaw.FromRawUnchecked"/>
    public static BetaModelCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaModelCapabilitiesFromRaw : IFromRawJson<BetaModelCapabilities>
{
    /// <inheritdoc/>
    public BetaModelCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaModelCapabilities.FromRawUnchecked(rawData);
}
