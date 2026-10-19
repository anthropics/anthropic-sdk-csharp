using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Suspended,
                Country = "country",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Individual,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ReferenceID = "x",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "x",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedUserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        ApiEnum<string, UserProfileAccessType> expectedAccessType =
            UserProfileAccessType.Application;
        UserProfileExternalUserDetailsParams expectedExternalUserDetails = new()
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Suspended,
            Country = "country",
            EmailHash = "x",
            EntityType = UserProfileExternalUserEntityType.Individual,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "x",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "x";
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
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
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            Name = "x",
        };

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
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            Name = "x",

            // Null should be interpreted as omitted for these properties
            ExternalUserDetails = null,
            Metadata = null,
            WorkspaceID = null,
        };

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
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Suspended,
                Country = "country",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Individual,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ReferenceID = "x",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "x",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            ExternalUserDetails = null,
            Metadata = null,
            WorkspaceID = null,
        };

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
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Suspended,
                Country = "country",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Individual,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ReferenceID = "x",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        Assert.Null(parameters.AccessType);
        Assert.False(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Suspended,
                Country = "country",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Individual,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ReferenceID = "x",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",

            AccessType = null,
            Name = null,
        };

        Assert.Null(parameters.AccessType);
        Assert.True(parameters.RawBodyData.ContainsKey("access_type"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        UserProfileUpdateParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/user_profiles/uprof_011CZkZCu8hGbp5mYRQgUmz9"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserProfileUpdateParams parameters = new()
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
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
        var parameters = new UserProfileUpdateParams
        {
            UserProfileID = "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            AccessType = UserProfileAccessType.Application,
            ExternalUserDetails = new()
            {
                AccountStatus = UserProfileExternalUserAccountStatus.Suspended,
                Country = "country",
                EmailHash = "x",
                EntityType = UserProfileExternalUserEntityType.Individual,
                NameHash = "x",
                OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ReferenceID = "x",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "x",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        UserProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
