using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class DataResidencyCreateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataResidencyCreateConfig
        {
            AllowedInferenceGeos = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
        };

        DataResidencyCreateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo> expectedDefaultInferenceGeo =
            DataResidencyCreateConfigDefaultInferenceGeo.Global;
        ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo> expectedWorkspaceGeo =
            DataResidencyCreateConfigWorkspaceGeo.Us;

        Assert.Equal(expectedAllowedInferenceGeos, model.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, model.DefaultInferenceGeo);
        Assert.Equal(expectedWorkspaceGeo, model.WorkspaceGeo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataResidencyCreateConfig
        {
            AllowedInferenceGeos = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataResidencyCreateConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataResidencyCreateConfig
        {
            AllowedInferenceGeos = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataResidencyCreateConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataResidencyCreateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo> expectedDefaultInferenceGeo =
            DataResidencyCreateConfigDefaultInferenceGeo.Global;
        ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo> expectedWorkspaceGeo =
            DataResidencyCreateConfigWorkspaceGeo.Us;

        Assert.Equal(expectedAllowedInferenceGeos, deserialized.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, deserialized.DefaultInferenceGeo);
        Assert.Equal(expectedWorkspaceGeo, deserialized.WorkspaceGeo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataResidencyCreateConfig
        {
            AllowedInferenceGeos = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataResidencyCreateConfig { };

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
        var model = new DataResidencyCreateConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataResidencyCreateConfig
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
        var model = new DataResidencyCreateConfig
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
        var model = new DataResidencyCreateConfig
        {
            AllowedInferenceGeos = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyCreateConfigDefaultInferenceGeo.Global,
            WorkspaceGeo = DataResidencyCreateConfigWorkspaceGeo.Us,
        };

        DataResidencyCreateConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataResidencyCreateConfigAllowedInferenceGeosTest : TestBase
{
    [Fact]
    public void GeosValidationWorks()
    {
        DataResidencyCreateConfigAllowedInferenceGeos value = new([AllowedInferenceGeo.Global]);
        value.Validate();
    }

    [Fact]
    public void UnrestrictedValidationWorks()
    {
        DataResidencyCreateConfigAllowedInferenceGeos value =
            new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        value.Validate();
    }

    [Fact]
    public void GeosSerializationRoundtripWorks()
    {
        DataResidencyCreateConfigAllowedInferenceGeos value = new([AllowedInferenceGeo.Global]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnrestrictedSerializationRoundtripWorks()
    {
        DataResidencyCreateConfigAllowedInferenceGeos value =
            new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class DataResidencyCreateConfigAllowedInferenceGeosUnrestrictedTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
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
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        Assert.Throws<AnthropicInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new DataResidencyCreateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("unrestricted"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyCreateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class DataResidencyCreateConfigDefaultInferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(DataResidencyCreateConfigDefaultInferenceGeo.Global)]
    [InlineData(DataResidencyCreateConfigDefaultInferenceGeo.Us)]
    public void Validation_Works(DataResidencyCreateConfigDefaultInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataResidencyCreateConfigDefaultInferenceGeo.Global)]
    [InlineData(DataResidencyCreateConfigDefaultInferenceGeo.Us)]
    public void SerializationRoundtrip_Works(DataResidencyCreateConfigDefaultInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataResidencyCreateConfigWorkspaceGeoTest : TestBase
{
    [Theory]
    [InlineData(DataResidencyCreateConfigWorkspaceGeo.Us)]
    public void Validation_Works(DataResidencyCreateConfigWorkspaceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataResidencyCreateConfigWorkspaceGeo.Us)]
    public void SerializationRoundtrip_Works(DataResidencyCreateConfigWorkspaceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyCreateConfigWorkspaceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
