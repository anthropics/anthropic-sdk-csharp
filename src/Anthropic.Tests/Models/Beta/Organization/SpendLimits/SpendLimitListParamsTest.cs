using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class SpendLimitListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Limit = 1,
            Page = "page",
            ScopeType = [ScopeType.Organization],
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        long expectedLimit = 1;
        string expectedPage = "page";
        List<ApiEnum<string, ScopeType>> expectedScopeType = [ScopeType.Organization];
        string expectedWorkspaceID = "workspace_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.ScopeType);
        Assert.Equal(expectedScopeType.Count, parameters.ScopeType.Count);
        for (int i = 0; i < expectedScopeType.Count; i++)
        {
            Assert.Equal(expectedScopeType[i], parameters.ScopeType[i]);
        }
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Page = "page",
            ScopeType = [ScopeType.Organization],
            WorkspaceID = "workspace_id",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Page = "page",
            ScopeType = [ScopeType.Organization],
            WorkspaceID = "workspace_id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Limit = 1,
            Page = "page",
            ScopeType = [ScopeType.Organization],
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.ScopeType);
        Assert.False(parameters.RawQueryData.ContainsKey("scope_type"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Limit = 1,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            Page = null,
            ScopeType = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.ScopeType);
        Assert.True(parameters.RawQueryData.ContainsKey("scope_type"));
        Assert.Null(parameters.WorkspaceID);
        Assert.True(parameters.RawQueryData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void Url_Works()
    {
        SpendLimitListParams parameters = new()
        {
            Limit = 1,
            Page = "page",
            ScopeType = [ScopeType.Organization],
            WorkspaceID = "workspace_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limits?limit=1&page=page&scope_type%5b%5d=organization&workspace_id=workspace_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SpendLimitListParams parameters = new() { Betas = [AnthropicBeta.ComputerUse2024_10_22] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,spend-limit-reads-2026-09-26"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SpendLimitListParams
        {
            Limit = 1,
            Page = "page",
            ScopeType = [ScopeType.Organization],
            WorkspaceID = "workspace_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        SpendLimitListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ScopeTypeTest : TestBase
{
    [Theory]
    [InlineData(ScopeType.Organization)]
    [InlineData(ScopeType.OrganizationService)]
    [InlineData(ScopeType.RbacGroup)]
    [InlineData(ScopeType.SeatTier)]
    [InlineData(ScopeType.UsageTier)]
    [InlineData(ScopeType.User)]
    [InlineData(ScopeType.Workspace)]
    public void Validation_Works(ScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScopeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScopeType.Organization, 0, "organization")]
    [InlineData(ScopeType.OrganizationService, 1, "organization_service")]
    [InlineData(ScopeType.RbacGroup, 2, "rbac_group")]
    [InlineData(ScopeType.SeatTier, 3, "seat_tier")]
    [InlineData(ScopeType.UsageTier, 4, "usage_tier")]
    [InlineData(ScopeType.User, 5, "user")]
    [InlineData(ScopeType.Workspace, 6, "workspace")]
    public void EnumMemberSerializationRoundtrip_Works(
        ScopeType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScopeType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
