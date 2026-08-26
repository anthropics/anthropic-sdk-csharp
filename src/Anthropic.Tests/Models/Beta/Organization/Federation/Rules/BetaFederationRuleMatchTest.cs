using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

public class BetaFederationRuleMatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };

        string expectedAudience = "audience";
        Dictionary<string, string> expectedClaims = new() { { "foo", "string" } };
        string expectedCondition = "condition";
        string expectedSubjectPrefix = "subject_prefix";

        Assert.Equal(expectedAudience, model.Audience);
        Assert.NotNull(model.Claims);
        Assert.Equal(expectedClaims.Count, model.Claims.Count);
        foreach (var item in expectedClaims)
        {
            Assert.True(model.Claims.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Claims[item.Key]);
        }
        Assert.Equal(expectedCondition, model.Condition);
        Assert.Equal(expectedSubjectPrefix, model.SubjectPrefix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationRuleMatch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationRuleMatch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAudience = "audience";
        Dictionary<string, string> expectedClaims = new() { { "foo", "string" } };
        string expectedCondition = "condition";
        string expectedSubjectPrefix = "subject_prefix";

        Assert.Equal(expectedAudience, deserialized.Audience);
        Assert.NotNull(deserialized.Claims);
        Assert.Equal(expectedClaims.Count, deserialized.Claims.Count);
        foreach (var item in expectedClaims)
        {
            Assert.True(deserialized.Claims.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Claims[item.Key]);
        }
        Assert.Equal(expectedCondition, deserialized.Condition);
        Assert.Equal(expectedSubjectPrefix, deserialized.SubjectPrefix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaFederationRuleMatch { };

        Assert.Null(model.Audience);
        Assert.False(model.RawData.ContainsKey("audience"));
        Assert.Null(model.Claims);
        Assert.False(model.RawData.ContainsKey("claims"));
        Assert.Null(model.Condition);
        Assert.False(model.RawData.ContainsKey("condition"));
        Assert.Null(model.SubjectPrefix);
        Assert.False(model.RawData.ContainsKey("subject_prefix"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaFederationRuleMatch { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = null,
            Claims = null,
            Condition = null,
            SubjectPrefix = null,
        };

        Assert.Null(model.Audience);
        Assert.True(model.RawData.ContainsKey("audience"));
        Assert.Null(model.Claims);
        Assert.True(model.RawData.ContainsKey("claims"));
        Assert.Null(model.Condition);
        Assert.True(model.RawData.ContainsKey("condition"));
        Assert.Null(model.SubjectPrefix);
        Assert.True(model.RawData.ContainsKey("subject_prefix"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = null,
            Claims = null,
            Condition = null,
            SubjectPrefix = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFederationRuleMatch
        {
            Audience = "audience",
            Claims = new Dictionary<string, string>() { { "foo", "string" } },
            Condition = "condition",
            SubjectPrefix = "subject_prefix",
        };

        BetaFederationRuleMatch copied = new(model);

        Assert.Equal(model, copied);
    }
}
