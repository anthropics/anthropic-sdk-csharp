fix(bedrock): sign repeated header values

The signature no longer covers `User-Agent`. The header is sent as before.
