using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Organization.ExternalKeys;

public class AwsExternalKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };

        string expectedKmsArn =
            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");
        string expectedRegion = "us-east-1";

        Assert.Equal(expectedKmsArn, model.KmsArn);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AwsExternalKeyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AwsExternalKeyConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKmsArn =
            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");
        string expectedRegion = "us-east-1";

        Assert.Equal(expectedKmsArn, deserialized.KmsArn);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
        };

        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",

            Region = null,
        };

        Assert.Null(model.Region);
        Assert.True(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",

            Region = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };

        AwsExternalKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
