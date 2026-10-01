using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaDataResidencyCreateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = BetaDataResidencyCreateConfigWorkspaceGeo.Us,
        };

        BetaDataResidencyCreateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<
            string,
            BetaDataResidencyCreateConfigDefaultInferenceGeo
        > expectedDefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global;
        ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo> expectedWorkspaceGeo =
            BetaDataResidencyCreateConfigWorkspaceGeo.Us;

        Assert.Equal(expectedAllowedInferenceGeos, model.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, model.DefaultInferenceGeo);
        Assert.Equal(expectedWorkspaceGeo, model.WorkspaceGeo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = BetaDataResidencyCreateConfigWorkspaceGeo.Us,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDataResidencyCreateConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = BetaDataResidencyCreateConfigWorkspaceGeo.Us,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDataResidencyCreateConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaDataResidencyCreateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<
            string,
            BetaDataResidencyCreateConfigDefaultInferenceGeo
        > expectedDefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global;
        ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo> expectedWorkspaceGeo =
            BetaDataResidencyCreateConfigWorkspaceGeo.Us;

        Assert.Equal(expectedAllowedInferenceGeos, deserialized.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, deserialized.DefaultInferenceGeo);
        Assert.Equal(expectedWorkspaceGeo, deserialized.WorkspaceGeo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = BetaDataResidencyCreateConfigWorkspaceGeo.Us,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaDataResidencyCreateConfig { };

        Assert.Null(model.AllowedInferenceGeos);
        Assert.False(model.RawData.ContainsKey("allowed_inference_geos"));
        Assert.Null(model.DefaultInferenceGeo);
        Assert.False(model.RawData.ContainsKey("default_inference_geo"));
        Assert.Null(model.WorkspaceGeo);
        Assert.False(model.RawData.ContainsKey("workspace_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaDataResidencyCreateConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos = null,
            DefaultInferenceGeo = null,
            WorkspaceGeo = null,
        };

        Assert.Null(model.AllowedInferenceGeos);
        Assert.True(model.RawData.ContainsKey("allowed_inference_geos"));
        Assert.Null(model.DefaultInferenceGeo);
        Assert.True(model.RawData.ContainsKey("default_inference_geo"));
        Assert.Null(model.WorkspaceGeo);
        Assert.True(model.RawData.ContainsKey("workspace_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos = null,
            DefaultInferenceGeo = null,
            WorkspaceGeo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDataResidencyCreateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = BetaDataResidencyCreateConfigWorkspaceGeo.Us,
        };

        BetaDataResidencyCreateConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaDataResidencyCreateConfigAllowedInferenceGeosTest : TestBase
{
    [Fact]
    public void GeosValidationWorks()
    {
        BetaDataResidencyCreateConfigAllowedInferenceGeos value = new(
            [BetaAllowedInferenceGeo.Global]
        );
        value.Validate();
    }

    [Fact]
    public void UnrestrictedValidationWorks()
    {
        BetaDataResidencyCreateConfigAllowedInferenceGeos value =
            new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        value.Validate();
    }

    [Fact]
    public void GeosSerializationRoundtripWorks()
    {
        BetaDataResidencyCreateConfigAllowedInferenceGeos value = new(
            [BetaAllowedInferenceGeo.Global]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnrestrictedSerializationRoundtripWorks()
    {
        BetaDataResidencyCreateConfigAllowedInferenceGeos value =
            new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestrictedTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("unrestricted"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        Assert.Throws<AnthropicInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("unrestricted"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class BetaDataResidencyCreateConfigDefaultInferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(BetaDataResidencyCreateConfigDefaultInferenceGeo.Global)]
    [InlineData(BetaDataResidencyCreateConfigDefaultInferenceGeo.Us)]
    public void Validation_Works(BetaDataResidencyCreateConfigDefaultInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDataResidencyCreateConfigDefaultInferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDataResidencyCreateConfigDefaultInferenceGeo.Global)]
    [InlineData(BetaDataResidencyCreateConfigDefaultInferenceGeo.Us)]
    public void SerializationRoundtrip_Works(
        BetaDataResidencyCreateConfigDefaultInferenceGeo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDataResidencyCreateConfigDefaultInferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaDataResidencyCreateConfigWorkspaceGeoTest : TestBase
{
    [Theory]
    [InlineData(BetaDataResidencyCreateConfigWorkspaceGeo.Us)]
    public void Validation_Works(BetaDataResidencyCreateConfigWorkspaceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDataResidencyCreateConfigWorkspaceGeo.Us)]
    public void SerializationRoundtrip_Works(BetaDataResidencyCreateConfigWorkspaceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyCreateConfigWorkspaceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
