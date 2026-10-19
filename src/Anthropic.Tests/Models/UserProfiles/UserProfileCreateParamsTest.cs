using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserProfileCreateParams
        {
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        ApiEnum<string, UserProfileAccessType> expectedAccessType =
            UserProfileAccessType.Application;
        UserProfileExternalUserDetailsParams expectedExternalUserDetails = new()
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "US",
            EmailHash = "x",
            EntityType = UserProfileExternalUserEntityType.Business,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
            ReferenceID = "user_12345",
        };
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "Example User";
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedAccessType, parameters.AccessType);
        Assert.Equal(expectedExternalUserDetails, parameters.ExternalUserDetails);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserProfileCreateParams { Name = "Example User" };

        Assert.Null(parameters.AccessType);
        Assert.False(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.ExternalUserDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("external_user_details"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserProfileCreateParams
        {
            Name = "Example User",

            // Null should be interpreted as omitted for these properties
            AccessType = null,
            ExternalUserDetails = null,
            Metadata = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.AccessType);
        Assert.False(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.ExternalUserDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("external_user_details"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new UserProfileCreateParams
        {
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            AccessType = null,
            ExternalUserDetails = null,
            Metadata = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.AccessType);
        Assert.False(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.ExternalUserDetails);
        Assert.False(parameters.RawBodyData.ContainsKey("external_user_details"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserProfileCreateParams
        {
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UserProfileCreateParams
        {
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",

            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        UserProfileCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/user_profiles"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserProfileCreateParams parameters = new()
        {
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserProfileCreateParams
        {
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Active,
                Country = "US",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Business,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2024-11-02T08:15:00Z"),
                ReferenceID = "user_12345",
            },
            Metadata = new Dictionary<string, string>(),
            Name = "Example User",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        UserProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
