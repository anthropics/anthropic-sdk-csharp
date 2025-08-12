using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using RequestProperties = Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties;

namespace Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties;

[JsonConverter(typeof(Anthropic::ModelConverter<Request>))]
public sealed record class Request : Anthropic::ModelBase, Anthropic::IFromRaw<Request>
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// Must be unique for each request within the Message Batch.
    /// </summary>
    public required string CustomID
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "custom_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("custom_id");
        }
        set { this.Properties["custom_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Messages API creation parameters for the individual request.
    ///
    /// See the [Messages API reference](/en/api/messages) for full documentation
    /// on available parameters.
    /// </summary>
    public required RequestProperties::Params Params
    {
        get
        {
            if (!this.Properties.TryGetValue("params", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "params",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<RequestProperties::Params>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("params");
        }
        set { this.Properties["params"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CustomID;
        this.Params.Validate();
    }

    public Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Request FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
