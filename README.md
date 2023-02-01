# CompareJson.Api
Provide two endpoints that accept base64 JSON encoded binary data in both, and a third to return the differences between them.

#How it works:
Provide two endpoints that receive JSON base64 encoded binary data on both endpoints;

[POST] https://localhost:7076/api/v1/diff/1/right
[Payload]
{
  "base64": "ewogICAgImJhc2U2NCI6ICJ4cHRvIgp9"
}

[Result] 200
{
}

[POST] https://localhost:7076/api/v1/diff/1/left
[Payload]
{
  "base64": "ewogICAgImJhc2U2NCI6ICJ4cHRvIgp9"
}

[Result] 200
{
}

Endpoint for comparison between them.

[GET]:  https://localhost:7076/api/v1/diff/1

[Result] 200
{
  "id": 1,
  "message":"The data is the same",
  "length" : 0
}

The results provide the following info in JSON format:
- Jsons are equal
- Jsons are different size
- Jsons are same size but with differences

# Techonologies
- ASP.NET Core 7 - Web Api
- EntityFramework Core InMemory
- Swagger for documentation
- DDD (with MediatR)
- NUnitTest + Moq
- FluentValidation.AspNetCore 

# Suggestion to improve
- Change InMemory database to a relational (Sql Server for example) or non-relational (MongoDb or CosmosDb) database. If necessary, the CQRS architecture model (Queries in non-relational databases and insertions in relational databases) can be adopted.
- Put a cache in the Api layer (Redis for example)
- Distribute the application in Docker containers and use Kubernets for orchestration.
- Use an API gateway or create an authentication layer using a jwt token.
- Implement log monitoring through elasticsearch
