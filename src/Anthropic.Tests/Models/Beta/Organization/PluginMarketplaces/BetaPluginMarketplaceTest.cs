using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;
using Plugins = Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class BetaPluginMarketplaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginMarketplace
        {
            ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            DefaultInstallationPreference =
                BetaPluginMarketplaceDefaultInstallationPreference.Available,
            LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            Name = "engineering-tools",
            Owner = new Plugins::BetaPluginOwnerOrganization(),
            Source = BetaPluginMarketplaceSource.GitHub,
            SyncStatus = SyncStatus.Success,
        };

        string expectedID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        ApiEnum<
            string,
            BetaPluginMarketplaceDefaultInstallationPreference
        > expectedDefaultInstallationPreference =
            BetaPluginMarketplaceDefaultInstallationPreference.Available;
        DateTimeOffset expectedLastSyncEndedAt = DateTimeOffset.Parse(
            "2026-03-14T09:26:53.589793Z"
        );
        string expectedLastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8";
        string expectedName = "engineering-tools";
        Owner expectedOwner = new Plugins::BetaPluginOwnerOrganization();
        ApiEnum<string, BetaPluginMarketplaceSource> expectedSource =
            BetaPluginMarketplaceSource.GitHub;
        ApiEnum<string, SyncStatus> expectedSyncStatus = SyncStatus.Success;
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_marketplace");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDefaultInstallationPreference, model.DefaultInstallationPreference);
        Assert.Equal(expectedLastSyncEndedAt, model.LastSyncEndedAt);
        Assert.Equal(expectedLastSyncReadSha, model.LastSyncReadSha);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOwner, model.Owner);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedSyncStatus, model.SyncStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginMarketplace
        {
            ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            DefaultInstallationPreference =
                BetaPluginMarketplaceDefaultInstallationPreference.Available,
            LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            Name = "engineering-tools",
            Owner = new Plugins::BetaPluginOwnerOrganization(),
            Source = BetaPluginMarketplaceSource.GitHub,
            SyncStatus = SyncStatus.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginMarketplace
        {
            ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            DefaultInstallationPreference =
                BetaPluginMarketplaceDefaultInstallationPreference.Available,
            LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            Name = "engineering-tools",
            Owner = new Plugins::BetaPluginOwnerOrganization(),
            Source = BetaPluginMarketplaceSource.GitHub,
            SyncStatus = SyncStatus.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginMarketplace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z");
        ApiEnum<
            string,
            BetaPluginMarketplaceDefaultInstallationPreference
        > expectedDefaultInstallationPreference =
            BetaPluginMarketplaceDefaultInstallationPreference.Available;
        DateTimeOffset expectedLastSyncEndedAt = DateTimeOffset.Parse(
            "2026-03-14T09:26:53.589793Z"
        );
        string expectedLastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8";
        string expectedName = "engineering-tools";
        Owner expectedOwner = new Plugins::BetaPluginOwnerOrganization();
        ApiEnum<string, BetaPluginMarketplaceSource> expectedSource =
            BetaPluginMarketplaceSource.GitHub;
        ApiEnum<string, SyncStatus> expectedSyncStatus = SyncStatus.Success;
        JsonElement expectedType = JsonSerializer.SerializeToElement("plugin_marketplace");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(
            expectedDefaultInstallationPreference,
            deserialized.DefaultInstallationPreference
        );
        Assert.Equal(expectedLastSyncEndedAt, deserialized.LastSyncEndedAt);
        Assert.Equal(expectedLastSyncReadSha, deserialized.LastSyncReadSha);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOwner, deserialized.Owner);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedSyncStatus, deserialized.SyncStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginMarketplace
        {
            ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            DefaultInstallationPreference =
                BetaPluginMarketplaceDefaultInstallationPreference.Available,
            LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            Name = "engineering-tools",
            Owner = new Plugins::BetaPluginOwnerOrganization(),
            Source = BetaPluginMarketplaceSource.GitHub,
            SyncStatus = SyncStatus.Success,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginMarketplace
        {
            ID = "marketplace_01HxQ3v9KpZ2mTn8RwLc4Ys7",
            CreatedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            DefaultInstallationPreference =
                BetaPluginMarketplaceDefaultInstallationPreference.Available,
            LastSyncEndedAt = DateTimeOffset.Parse("2026-03-14T09:26:53.589793Z"),
            LastSyncReadSha = "9fceb02d0ae598e95dc970b74767f19372d61af8",
            Name = "engineering-tools",
            Owner = new Plugins::BetaPluginOwnerOrganization(),
            Source = BetaPluginMarketplaceSource.GitHub,
            SyncStatus = SyncStatus.Success,
        };

        BetaPluginMarketplace copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaPluginMarketplaceDefaultInstallationPreferenceTest : TestBase
{
    [Theory]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.AutoInstall)]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.Available)]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.NotAvailable)]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.Required)]
    public void Validation_Works(BetaPluginMarketplaceDefaultInstallationPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.AutoInstall)]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.Available)]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.NotAvailable)]
    [InlineData(BetaPluginMarketplaceDefaultInstallationPreference.Required)]
    public void SerializationRoundtrip_Works(
        BetaPluginMarketplaceDefaultInstallationPreference rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OwnerTest : TestBase
{
    [Fact]
    public void BetaPluginOwnerOrganizationValidationWorks()
    {
        Owner value = new Plugins::BetaPluginOwnerOrganization();
        value.Validate();
    }

    [Fact]
    public void BetaPluginOwnerUserValidationWorks()
    {
        Owner value = new Plugins::BetaPluginOwnerUser("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void BetaPluginOwnerOrganizationSerializationRoundtripWorks()
    {
        Owner value = new Plugins::BetaPluginOwnerOrganization();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Owner>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPluginOwnerUserSerializationRoundtripWorks()
    {
        Owner value = new Plugins::BetaPluginOwnerUser("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Owner>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Owner value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Owner emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaPluginMarketplaceSourceTest : TestBase
{
    [Theory]
    [InlineData(BetaPluginMarketplaceSource.Directory)]
    [InlineData(BetaPluginMarketplaceSource.GitHub)]
    [InlineData(BetaPluginMarketplaceSource.Gitlab)]
    [InlineData(BetaPluginMarketplaceSource.Manual)]
    [InlineData(BetaPluginMarketplaceSource.PublicGit)]
    public void Validation_Works(BetaPluginMarketplaceSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPluginMarketplaceSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaPluginMarketplaceSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaPluginMarketplaceSource.Directory)]
    [InlineData(BetaPluginMarketplaceSource.GitHub)]
    [InlineData(BetaPluginMarketplaceSource.Gitlab)]
    [InlineData(BetaPluginMarketplaceSource.Manual)]
    [InlineData(BetaPluginMarketplaceSource.PublicGit)]
    public void SerializationRoundtrip_Works(BetaPluginMarketplaceSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPluginMarketplaceSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaPluginMarketplaceSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaPluginMarketplaceSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaPluginMarketplaceSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SyncStatusTest : TestBase
{
    [Theory]
    [InlineData(SyncStatus.FailedAuth)]
    [InlineData(SyncStatus.FailedContent)]
    [InlineData(SyncStatus.FailedLimits)]
    [InlineData(SyncStatus.FailedTransient)]
    [InlineData(SyncStatus.InProgress)]
    [InlineData(SyncStatus.Success)]
    public void Validation_Works(SyncStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SyncStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SyncStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SyncStatus.FailedAuth)]
    [InlineData(SyncStatus.FailedContent)]
    [InlineData(SyncStatus.FailedLimits)]
    [InlineData(SyncStatus.FailedTransient)]
    [InlineData(SyncStatus.InProgress)]
    [InlineData(SyncStatus.Success)]
    public void SerializationRoundtrip_Works(SyncStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SyncStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SyncStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SyncStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SyncStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
