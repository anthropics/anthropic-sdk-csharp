using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Client.Models.Beta;
using Anthropic.Client.Models.Beta.Files;
using Anthropic.Client.Models.Messages.Batches;
using Batches = Anthropic.Client.Models.Beta.Messages.Batches;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Messages::MediaType>(),
            new ApiEnumConverter<string, Messages::TTL>(),
            new ApiEnumConverter<string, Messages::Role>(),
            new ApiEnumConverter<string, Messages::Model>(),
            new ApiEnumConverter<string, Messages::StopReason>(),
            new ApiEnumConverter<string, Messages::Type>(),
            new ApiEnumConverter<string, Messages::ServiceTierModel>(),
            new ApiEnumConverter<string, Messages::ErrorCode>(),
            new ApiEnumConverter<string, Messages::ErrorCodeModel>(),
            new ApiEnumConverter<string, Messages::ServiceTier>(),
            new ApiEnumConverter<string, ProcessingStatus>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.MediaType>(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.ErrorCode>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.ErrorCodeModel
            >(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.TTL>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.BetaCodeExecutionToolResultErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.Role>(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.Name>(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.NameModel>(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.Type>(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.TypeModel>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.BetaStopReason
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.ErrorCode1
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.ErrorCode2
            >(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.FileType>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.FileTypeModel
            >(),
            new ApiEnumConverter<string, global::Anthropic.Client.Models.Beta.Messages.Type1>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.ServiceTierModel
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultErrorCode
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.BetaWebSearchToolResultErrorCode
            >(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Client.Models.Beta.Messages.ServiceTier
            >(),
            new ApiEnumConverter<string, Batches::ProcessingStatus>(),
            new ApiEnumConverter<string, Batches::ServiceTier>(),
            new ApiEnumConverter<string, Type>(),
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
