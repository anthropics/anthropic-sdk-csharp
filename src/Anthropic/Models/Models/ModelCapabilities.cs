using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Model capability information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ModelCapabilities, ModelCapabilitiesFromRaw>))]
public sealed record class ModelCapabilities : JsonModel
{
    /// <summary>
    /// Whether the model supports the Batch API.
    /// </summary>
    public required CapabilitySupport Batch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("batch");
        }
        init { this._rawData.Set("batch", value); }
    }

    /// <summary>
    /// Whether the model supports citation generation.
    /// </summary>
    public required CapabilitySupport Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("citations");
        }
        init { this._rawData.Set("citations", value); }
    }

    /// <summary>
    /// Whether the model supports code execution tools.
    /// </summary>
    public required CapabilitySupport CodeExecution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("code_execution");
        }
        init { this._rawData.Set("code_execution", value); }
    }

    /// <summary>
    /// Context management support and available strategies.
    /// </summary>
    public required ContextManagementCapability ContextManagement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContextManagementCapability>("context_management");
        }
        init { this._rawData.Set("context_management", value); }
    }

    /// <summary>
    /// Effort (reasoning_effort) support and available levels.
    /// </summary>
    public required EffortCapability Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EffortCapability>("effort");
        }
        init { this._rawData.Set("effort", value); }
    }

    /// <summary>
    /// Whether the model accepts image content blocks.
    /// </summary>
    public required CapabilitySupport ImageInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("image_input");
        }
        init { this._rawData.Set("image_input", value); }
    }

    /// <summary>
    /// Whether the model accepts PDF content blocks.
    /// </summary>
    public required CapabilitySupport PdfInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("pdf_input");
        }
        init { this._rawData.Set("pdf_input", value); }
    }

    /// <summary>
    /// Whether the model supports structured output / JSON mode / strict tool schemas.
    /// </summary>
    public required CapabilitySupport StructuredOutputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("structured_outputs");
        }
        init { this._rawData.Set("structured_outputs", value); }
    }

    /// <summary>
    /// Thinking capability and supported type configurations.
    /// </summary>
    public required ThinkingCapability Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ThinkingCapability>("thinking");
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

    public ModelCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelCapabilities(ModelCapabilities modelCapabilities)
        : base(modelCapabilities) { }
#pragma warning restore CS8618

    public ModelCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelCapabilitiesFromRaw.FromRawUnchecked"/>
    public static ModelCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelCapabilitiesFromRaw : IFromRawJson<ModelCapabilities>
{
    /// <inheritdoc/>
    public ModelCapabilities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelCapabilities.FromRawUnchecked(rawData);
}
