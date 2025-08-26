using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Beta.Client.Models.Beta;
using Anthropic.Beta.Client.Models.Beta.Messages;
using Anthropic.Beta.Client.Models.Beta.Messages.BetaServerToolUseBlockProperties;
using Anthropic.Beta.Client.Models.Messages.Base64ImageSourceProperties;
using Anthropic.Beta.Client.Models.Messages.Batches.MessageBatchProperties;
using Anthropic.Beta.Client.Models.Messages.CacheControlEphemeralProperties;
using Anthropic.Beta.Client.Models.Messages.MessageParamProperties;
using Anthropic.Beta.Client.Models.Messages.ToolProperties;
using Anthropic.Beta.Client.Models.Messages.UsageProperties;
using Anthropic.Beta.Client.Models.Messages.WebSearchToolRequestErrorProperties;
using BetaBase64ImageSourceProperties = Anthropic.Beta.Client.Models.Beta.Messages.BetaBase64ImageSourceProperties;
using BetaCacheControlEphemeralProperties = Anthropic.Beta.Client.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using BetaMessageBatchProperties = Anthropic.Beta.Client.Models.Beta.Messages.Batches.BetaMessageBatchProperties;
using BetaMessageParamProperties = Anthropic.Beta.Client.Models.Beta.Messages.BetaMessageParamProperties;
using BetaServerToolUseBlockParamProperties = Anthropic.Beta.Client.Models.Beta.Messages.BetaServerToolUseBlockParamProperties;
using BetaToolProperties = Anthropic.Beta.Client.Models.Beta.Messages.BetaToolProperties;
using BetaUsageProperties = Anthropic.Beta.Client.Models.Beta.Messages.BetaUsageProperties;
using DeletedFileProperties = Anthropic.Beta.Client.Models.Beta.Files.DeletedFileProperties;
using MessageCreateParamsProperties = Anthropic.Beta.Client.Models.Messages.MessageCreateParamsProperties;
using Messages = Anthropic.Beta.Client.Models.Messages;
using ParamsProperties = Anthropic.Beta.Client.Models.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;
using WebSearchToolResultErrorProperties = Anthropic.Beta.Client.Models.Messages.WebSearchToolResultErrorProperties;

namespace Anthropic.Beta.Client;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, MediaType>(),
            new ApiEnumConverter<string, TTL>(),
            new ApiEnumConverter<string, Messages::Model>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, Messages::StopReason>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, ErrorCode>(),
            new ApiEnumConverter<string, WebSearchToolResultErrorProperties::ErrorCode>(),
            new ApiEnumConverter<string, MessageCreateParamsProperties::ServiceTier>(),
            new ApiEnumConverter<string, ProcessingStatus>(),
            new ApiEnumConverter<string, ParamsProperties::ServiceTier>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, BetaBase64ImageSourceProperties::MediaType>(),
            new ApiEnumConverter<string, BetaCacheControlEphemeralProperties::TTL>(),
            new ApiEnumConverter<string, BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, BetaMessageParamProperties::Role>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, BetaServerToolUseBlockParamProperties::Name>(),
            new ApiEnumConverter<string, BetaStopReason>(),
            new ApiEnumConverter<string, BetaToolProperties::Type>(),
            new ApiEnumConverter<string, BetaUsageProperties::ServiceTier>(),
            new ApiEnumConverter<string, BetaWebSearchToolResultErrorCode>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Beta.Client.Models.Beta.Messages.MessageCreateParamsProperties.ServiceTier
            >(),
            new ApiEnumConverter<string, BetaMessageBatchProperties::ProcessingStatus>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Beta.Client.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties.ServiceTier
            >(),
            new ApiEnumConverter<string, DeletedFileProperties::Type>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
