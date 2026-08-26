using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class BetaAwsExternalKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };

        string expectedKmsArn =
            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");
        string expectedRegion = "us-east-1";
        string expectedRoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek";

        Assert.Equal(expectedKmsArn, model.KmsArn);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedRoleArn, model.RoleArn);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAwsExternalKeyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAwsExternalKeyConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKmsArn =
            "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");
        string expectedRegion = "us-east-1";
        string expectedRoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek";

        Assert.Equal(expectedKmsArn, deserialized.KmsArn);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedRoleArn, deserialized.RoleArn);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
        };

        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.RoleArn);
        Assert.False(model.RawData.ContainsKey("role_arn"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",

            Region = null,
            RoleArn = null,
        };

        Assert.Null(model.Region);
        Assert.True(model.RawData.ContainsKey("region"));
        Assert.Null(model.RoleArn);
        Assert.True(model.RawData.ContainsKey("role_arn"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",

            Region = null,
            RoleArn = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAwsExternalKeyConfig
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };

        BetaAwsExternalKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
