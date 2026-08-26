using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ApiKeys;

public class ApiKeyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeyListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            CreatedByUserID = "created_by_user_id",
            Limit = 1,
            Status = ApiKeyListParamsStatus.Active,
            WorkspaceID = "workspace_id",
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        string expectedCreatedByUserID = "created_by_user_id";
        long expectedLimit = 1;
        ApiEnum<string, ApiKeyListParamsStatus> expectedStatus = ApiKeyListParamsStatus.Active;
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.Equal(expectedCreatedByUserID, parameters.CreatedByUserID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ApiKeyListParams
        {
            CreatedByUserID = "created_by_user_id",
            Status = ApiKeyListParamsStatus.Active,
            WorkspaceID = "workspace_id",
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ApiKeyListParams
        {
            CreatedByUserID = "created_by_user_id",
            Status = ApiKeyListParamsStatus.Active,
            WorkspaceID = "workspace_id",

            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Limit = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ApiKeyListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
        };

        Assert.Null(parameters.CreatedByUserID);
        Assert.False(parameters.RawQueryData.ContainsKey("created_by_user_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ApiKeyListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,

            CreatedByUserID = null,
            Status = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.CreatedByUserID);
        Assert.True(parameters.RawQueryData.ContainsKey("created_by_user_id"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.WorkspaceID);
        Assert.True(parameters.RawQueryData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeyListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            CreatedByUserID = "created_by_user_id",
            Limit = 1,
            Status = ApiKeyListParamsStatus.Active,
            WorkspaceID = "workspace_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/api_keys?beta=true&after_id=after_id&before_id=before_id&created_by_user_id=created_by_user_id&limit=1&status=active&workspace_id=workspace_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeyListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            CreatedByUserID = "created_by_user_id",
            Limit = 1,
            Status = ApiKeyListParamsStatus.Active,
            WorkspaceID = "workspace_id",
        };

        ApiKeyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ApiKeyListParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(ApiKeyListParamsStatus.Active)]
    [InlineData(ApiKeyListParamsStatus.Archived)]
    [InlineData(ApiKeyListParamsStatus.Expired)]
    [InlineData(ApiKeyListParamsStatus.Inactive)]
    public void Validation_Works(ApiKeyListParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeyListParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyListParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeyListParamsStatus.Active)]
    [InlineData(ApiKeyListParamsStatus.Archived)]
    [InlineData(ApiKeyListParamsStatus.Expired)]
    [InlineData(ApiKeyListParamsStatus.Inactive)]
    public void SerializationRoundtrip_Works(ApiKeyListParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeyListParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyListParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyListParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyListParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
