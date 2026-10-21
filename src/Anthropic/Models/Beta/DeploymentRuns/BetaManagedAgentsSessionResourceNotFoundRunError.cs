using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A referenced resource no longer exists and its kind was not reported.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionResourceNotFoundRunError,
        BetaManagedAgentsSessionResourceNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionResourceNotFoundRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("session_resource_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionResourceNotFoundRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("session_resource_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionResourceNotFoundRunError(
        BetaManagedAgentsSessionResourceNotFoundRunError betaManagedAgentsSessionResourceNotFoundRunError
    )
        : base(betaManagedAgentsSessionResourceNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionResourceNotFoundRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_resource_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionResourceNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionResourceNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionResourceNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionResourceNotFoundRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsSessionResourceNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionResourceNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionResourceNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionResourceNotFoundRunError.FromRawUnchecked(rawData);
}
