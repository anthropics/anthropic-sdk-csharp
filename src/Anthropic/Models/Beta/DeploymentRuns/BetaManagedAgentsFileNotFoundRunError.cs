using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A file resource referenced by the deployment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileNotFoundRunError,
        BetaManagedAgentsFileNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileNotFoundRunError : JsonModel
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
                JsonSerializer.SerializeToElement("file_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsFileNotFoundRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("file_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileNotFoundRunError(
        BetaManagedAgentsFileNotFoundRunError betaManagedAgentsFileNotFoundRunError
    )
        : base(betaManagedAgentsFileNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileNotFoundRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsFileNotFoundRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsFileNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsFileNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileNotFoundRunError.FromRawUnchecked(rawData);
}
