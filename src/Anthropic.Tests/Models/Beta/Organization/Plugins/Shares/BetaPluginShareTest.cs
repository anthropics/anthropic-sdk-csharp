using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Models.Beta.Organization.Plugins.Shares;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.Shares;

public class BetaPluginShareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginShare
        {
            GrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
        };

        DateTimeOffset expectedGrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        Target expectedTarget = new BetaPluginTargetOrganization();
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_share");

        Assert.Equal(expectedGrantedAt, model.GrantedAt);
        Assert.Equal(expectedPluginID, model.PluginID);
        Assert.Equal(expectedTarget, model.Target);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginShare
        {
            GrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginShare>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginShare
        {
            GrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginShare>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedGrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        string expectedPluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne";
        Target expectedTarget = new BetaPluginTargetOrganization();
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_share");

        Assert.Equal(expectedGrantedAt, deserialized.GrantedAt);
        Assert.Equal(expectedPluginID, deserialized.PluginID);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginShare
        {
            GrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginShare
        {
            GrantedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            PluginID = "plugin_01JyHfbRkZvD1gW7oTqXc3Ne",
            Target = new BetaPluginTargetOrganization(),
        };

        BetaPluginShare copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void BetaPluginTargetOrganizationValidationWorks()
    {
        Target value = new BetaPluginTargetOrganization();
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetRbacGroupValidationWorks()
    {
        Target value = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF");
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberValidationWorks()
    {
        Target value = new BetaPluginTargetOrganizationMember("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaPluginTargetOrganizationSerializationRoundtripWorks()
    {
        Target value = new BetaPluginTargetOrganization();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Target>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetRbacGroupSerializationRoundtripWorks()
    {
        Target value = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Target>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberSerializationRoundtripWorks()
    {
        Target value = new BetaPluginTargetOrganizationMember("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Target>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginTargetOrganizationTypeWorks()
    {
        Target value = new BetaPluginTargetOrganization();
        Assert.Equal(TargetTypeValue.Organization, value.Type.Value());
    }

    [Fact]
    public void BetaPluginTargetRbacGroupTypeWorks()
    {
        Target value = new BetaPluginTargetRbacGroup("rbac_group_012rppKaSVsmTo6NqRDXQXNF");
        Assert.Equal(TargetTypeValue.RbacGroup, value.Type.Value());
    }

    [Fact]
    public void BetaPluginTargetOrganizationMemberTypeWorks()
    {
        Target value = new BetaPluginTargetOrganizationMember("user_01WCz1FkmYMm4gnmykNKUu3Q");
        Assert.Equal(TargetTypeValue.OrganizationMember, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Target value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, TargetTypeValue> expectedType = TargetTypeValue.Organization;

        Assert.Equal(expectedType, value.Type);

        Target emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class TargetTypeValueTest : TestBase
{
    [Theory]
    [InlineData(TargetTypeValue.Organization)]
    [InlineData(TargetTypeValue.RbacGroup)]
    [InlineData(TargetTypeValue.OrganizationMember)]
    public void Validation_Works(TargetTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TargetTypeValue> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TargetTypeValue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TargetTypeValue.Organization)]
    [InlineData(TargetTypeValue.RbacGroup)]
    [InlineData(TargetTypeValue.OrganizationMember)]
    public void SerializationRoundtrip_Works(TargetTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TargetTypeValue> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TargetTypeValue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TargetTypeValue>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TargetTypeValue>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
