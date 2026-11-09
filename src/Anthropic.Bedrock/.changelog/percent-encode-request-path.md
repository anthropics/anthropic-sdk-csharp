fix(bedrock): throw on an empty model or one of `"."` or `".."`, and send the `/` in an inference profile's ARN as `%2F`, so the model can't change the request path
