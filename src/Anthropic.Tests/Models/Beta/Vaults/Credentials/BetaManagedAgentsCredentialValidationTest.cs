using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsCredentialValidationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCredentialValidation
        {
            CredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            HasRefreshToken = true,
            McpProbe = null,
            Refresh = null,
            Status = BetaManagedAgentsCredentialValidationStatus.Valid,
            ValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        string expectedCredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw";
        bool expectedHasRefreshToken = true;
        ApiEnum<string, BetaManagedAgentsCredentialValidationStatus> expectedStatus =
            BetaManagedAgentsCredentialValidationStatus.Valid;
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential_validation");
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";

        Assert.Equal(expectedCredentialID, model.CredentialID);
        Assert.Equal(expectedHasRefreshToken, model.HasRefreshToken);
        Assert.Null(model.McpProbe);
        Assert.Null(model.Refresh);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValidatedAt, model.ValidatedAt);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCredentialValidation
        {
            CredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            HasRefreshToken = true,
            McpProbe = null,
            Refresh = null,
            Status = BetaManagedAgentsCredentialValidationStatus.Valid,
            ValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialValidation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCredentialValidation
        {
            CredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            HasRefreshToken = true,
            McpProbe = null,
            Refresh = null,
            Status = BetaManagedAgentsCredentialValidationStatus.Valid,
            ValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialValidation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw";
        bool expectedHasRefreshToken = true;
        ApiEnum<string, BetaManagedAgentsCredentialValidationStatus> expectedStatus =
            BetaManagedAgentsCredentialValidationStatus.Valid;
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential_validation");
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";

        Assert.Equal(expectedCredentialID, deserialized.CredentialID);
        Assert.Equal(expectedHasRefreshToken, deserialized.HasRefreshToken);
        Assert.Null(deserialized.McpProbe);
        Assert.Null(deserialized.Refresh);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValidatedAt, deserialized.ValidatedAt);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCredentialValidation
        {
            CredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            HasRefreshToken = true,
            McpProbe = null,
            Refresh = null,
            Status = BetaManagedAgentsCredentialValidationStatus.Valid,
            ValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCredentialValidation
        {
            CredentialID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            HasRefreshToken = true,
            McpProbe = null,
            Refresh = null,
            Status = BetaManagedAgentsCredentialValidationStatus.Valid,
            ValidatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        BetaManagedAgentsCredentialValidation copied = new(model);

        Assert.Equal(model, copied);
    }
}
