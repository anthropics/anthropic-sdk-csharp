using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaStorageMemberParamTest : TestBase
{
    [Fact]
    public void InternalStorageValidationWorks()
    {
        BetaStorageMemberParam value = new BetaInternalStorageParam();
        value.Validate();
    }

    [Fact]
    public void ExternalValidationWorks()
    {
        BetaStorageMemberParam value = new BetaExternalStorageMemberParam("external_storage_id");
        value.Validate();
    }

    [Fact]
    public void InternalStorageSerializationRoundtripWorks()
    {
        BetaStorageMemberParam value = new BetaInternalStorageParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageMemberParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalSerializationRoundtripWorks()
    {
        BetaStorageMemberParam value = new BetaExternalStorageMemberParam("external_storage_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageMemberParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InternalStorageTypeWorks()
    {
        BetaStorageMemberParam value = new BetaInternalStorageParam();
        Assert.Equal(BetaStorageMemberParamType.Internal, value.Type.Value());
    }

    [Fact]
    public void ExternalTypeWorks()
    {
        BetaStorageMemberParam value = new BetaExternalStorageMemberParam("external_storage_id");
        Assert.Equal(BetaStorageMemberParamType.External, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaStorageMemberParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "internal"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaStorageMemberParamType> expectedType =
            BetaStorageMemberParamType.Internal;

        Assert.Equal(expectedType, value.Type);

        BetaStorageMemberParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaStorageMemberParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaStorageMemberParamType.Internal)]
    [InlineData(BetaStorageMemberParamType.External)]
    public void Validation_Works(BetaStorageMemberParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStorageMemberParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaStorageMemberParamType.Internal, 1356166642, "internal")]
    [InlineData(BetaStorageMemberParamType.External, 1996752248, "external")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaStorageMemberParamType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStorageMemberParamType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberParamType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberParamType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberParamType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
