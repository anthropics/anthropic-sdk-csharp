using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsErrorTest : TestBase
{
    [Fact]
    public void InvalidRequestValidationWorks()
    {
        BetaManagedAgentsError value = new BetaInvalidRequestError("message");
        value.Validate();
    }

    [Fact]
    public void AuthenticationValidationWorks()
    {
        BetaManagedAgentsError value = new BetaAuthenticationError("message");
        value.Validate();
    }

    [Fact]
    public void BillingValidationWorks()
    {
        BetaManagedAgentsError value = new BetaBillingError("message");
        value.Validate();
    }

    [Fact]
    public void PermissionValidationWorks()
    {
        BetaManagedAgentsError value = new BetaPermissionError("message");
        value.Validate();
    }

    [Fact]
    public void NotFoundValidationWorks()
    {
        BetaManagedAgentsError value = new BetaNotFoundError("message");
        value.Validate();
    }

    [Fact]
    public void RateLimitValidationWorks()
    {
        BetaManagedAgentsError value = new BetaRateLimitError("message");
        value.Validate();
    }

    [Fact]
    public void GatewayTimeoutValidationWorks()
    {
        BetaManagedAgentsError value = new BetaGatewayTimeoutError("message");
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaManagedAgentsError value = new BetaApiError("message");
        value.Validate();
    }

    [Fact]
    public void OverloadedValidationWorks()
    {
        BetaManagedAgentsError value = new BetaOverloadedError("message");
        value.Validate();
    }

    [Fact]
    public void MemoryPreconditionFailedValidationWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPreconditionFailedError()
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };
        value.Validate();
    }

    [Fact]
    public void MemoryPathConflictValidationWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPathConflictError()
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };
        value.Validate();
    }

    [Fact]
    public void ConflictValidationWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsConflictError()
        {
            Type = Type.ConflictError,
            Message = "message",
        };
        value.Validate();
    }

    [Fact]
    public void InvalidRequestSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaInvalidRequestError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AuthenticationSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaAuthenticationError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaBillingError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PermissionSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaPermissionError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaNotFoundError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RateLimitSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaRateLimitError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GatewayTimeoutSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaGatewayTimeoutError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaApiError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OverloadedSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaOverloadedError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryPreconditionFailedSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPreconditionFailedError()
        {
            Type = BetaManagedAgentsMemoryPreconditionFailedErrorType.MemoryPreconditionFailedError,
            Message = "message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryPathConflictSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsMemoryPathConflictError()
        {
            Type = BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            ConflictingMemoryID = "conflicting_memory_id",
            ConflictingPath = "conflicting_path",
            Message = "message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConflictSerializationRoundtripWorks()
    {
        BetaManagedAgentsError value = new BetaManagedAgentsConflictError()
        {
            Type = Type.ConflictError,
            Message = "message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
