using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Client.Models.Beta;
using Anthropic.Client.Models.Beta.Messages;
using Anthropic.Client.Models.Beta.Messages.BetaServerToolUseBlockProperties;
using Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionViewResultBlockProperties;
using Anthropic.Client.Models.Messages.Base64ImageSourceProperties;
using Anthropic.Client.Models.Messages.Batches.MessageBatchProperties;
using Anthropic.Client.Models.Messages.CacheControlEphemeralProperties;
using Anthropic.Client.Models.Messages.MessageParamProperties;
using Anthropic.Client.Models.Messages.ToolProperties;
using Anthropic.Client.Models.Messages.UsageProperties;
using Anthropic.Client.Models.Messages.WebSearchToolRequestErrorProperties;
using BetaBase64ImageSourceProperties = Anthropic.Client.Models.Beta.Messages.BetaBase64ImageSourceProperties;
using BetaBashCodeExecutionToolResultErrorParamProperties = Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultErrorParamProperties;
using BetaBashCodeExecutionToolResultErrorProperties = Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultErrorProperties;
using BetaCacheControlEphemeralProperties = Anthropic.Client.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using BetaMessageBatchProperties = Anthropic.Client.Models.Beta.Messages.Batches.BetaMessageBatchProperties;
using BetaMessageParamProperties = Anthropic.Client.Models.Beta.Messages.BetaMessageParamProperties;
using BetaServerToolUseBlockParamProperties = Anthropic.Client.Models.Beta.Messages.BetaServerToolUseBlockParamProperties;
using BetaTextEditorCodeExecutionToolResultErrorParamProperties = Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultErrorParamProperties;
using BetaTextEditorCodeExecutionToolResultErrorProperties = Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultErrorProperties;
using BetaTextEditorCodeExecutionViewResultBlockParamProperties = Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionViewResultBlockParamProperties;
using BetaToolProperties = Anthropic.Client.Models.Beta.Messages.BetaToolProperties;
using BetaUsageProperties = Anthropic.Client.Models.Beta.Messages.BetaUsageProperties;
using DeletedFileProperties = Anthropic.Client.Models.Beta.Files.DeletedFileProperties;
using MessageCreateParamsProperties = Anthropic.Client.Models.Messages.MessageCreateParamsProperties;
using Messages = Anthropic.Client.Models.Messages;
using ParamsProperties = Anthropic.Client.Models.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;
using WebSearchToolResultErrorProperties = Anthropic.Client.Models.Messages.WebSearchToolResultErrorProperties;

namespace Anthropic.Client;

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
            new ApiEnumConverter<
                string,
                BetaBashCodeExecutionToolResultErrorProperties::ErrorCode
            >(),
            new ApiEnumConverter<
                string,
                BetaBashCodeExecutionToolResultErrorParamProperties::ErrorCode
            >(),
            new ApiEnumConverter<string, BetaCacheControlEphemeralProperties::TTL>(),
            new ApiEnumConverter<string, BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, BetaMessageParamProperties::Role>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, BetaServerToolUseBlockParamProperties::Name>(),
            new ApiEnumConverter<string, BetaStopReason>(),
            new ApiEnumConverter<
                string,
                BetaTextEditorCodeExecutionToolResultErrorProperties::ErrorCode
            >(),
            new ApiEnumConverter<
                string,
                BetaTextEditorCodeExecutionToolResultErrorParamProperties::ErrorCode
            >(),
            new ApiEnumConverter<string, FileType>(),
            new ApiEnumConverter<
                string,
                BetaTextEditorCodeExecutionViewResultBlockParamProperties::FileType
            >(),
            new ApiEnumConverter<string, BetaToolProperties::Type>(),
            new ApiEnumConverter<string, BetaUsageProperties::ServiceTier>(),
            new ApiEnumConverter<string, BetaWebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, BetaWebSearchToolResultErrorCode>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.MessageCreateParamsProperties.ServiceTier
            >(),
            new ApiEnumConverter<string, BetaMessageBatchProperties::ProcessingStatus>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties.ServiceTier
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
