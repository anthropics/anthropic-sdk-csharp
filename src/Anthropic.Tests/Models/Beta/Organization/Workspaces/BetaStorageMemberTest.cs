using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaStorageMemberTest : TestBase
{
    [Fact]
    public void InternalStorageValidationWorks()
    {
        BetaStorageMember value = new BetaInternalStorage();
        value.Validate();
    }

    [Fact]
    public void ExternalValidationWorks()
    {
        BetaStorageMember value = new BetaExternalStorageMember("external_storage_id");
        value.Validate();
    }

    [Fact]
    public void InternalStorageSerializationRoundtripWorks()
    {
        BetaStorageMember value = new BetaInternalStorage();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageMember>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalSerializationRoundtripWorks()
    {
        BetaStorageMember value = new BetaExternalStorageMember("external_storage_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageMember>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InternalStorageTypeWorks()
    {
        BetaStorageMember value = new BetaInternalStorage();
        Assert.Equal(BetaStorageMemberType.Internal, value.Type.Value());
    }

    [Fact]
    public void ExternalTypeWorks()
    {
        BetaStorageMember value = new BetaExternalStorageMember("external_storage_id");
        Assert.Equal(BetaStorageMemberType.External, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaStorageMember value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "internal"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaStorageMemberType> expectedType = BetaStorageMemberType.Internal;

        Assert.Equal(expectedType, value.Type);

        BetaStorageMember emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaStorageMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaStorageMemberType.Internal)]
    [InlineData(BetaStorageMemberType.External)]
    public void Validation_Works(BetaStorageMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStorageMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaStorageMemberType.Internal, 1356166642, "internal")]
    [InlineData(BetaStorageMemberType.External, 1996752248, "external")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaStorageMemberType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStorageMemberType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStorageMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
