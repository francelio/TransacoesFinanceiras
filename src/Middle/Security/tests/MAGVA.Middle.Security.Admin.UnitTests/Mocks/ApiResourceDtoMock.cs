﻿using System;
using System.Linq;
using Bogus;
using MAGVA.Middle.Security.Admin.BusinessLogic.Constants;
using MAGVA.Middle.Security.Admin.BusinessLogic.Dtos.Configuration;

namespace MAGVA.Middle.Security.Admin.UnitTests.Mocks
{
    public static class ApiResourceDtoMock
    {
        public static Faker<ApiResourceDto> GetApiResourceFaker(int id)
        {            
            var fakerApiResource = new Faker<ApiResourceDto>()
                .RuleFor(o => o.Name, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.DisplayName, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.Enabled, f => f.Random.Bool())                
                .RuleFor(o => o.UserClaims, f => Enumerable.Range(1, f.Random.Int(1, 10)).Select(x => f.PickRandom(ClientConsts.GetStandardClaims())).ToList());
            
            return fakerApiResource;
        }

        public static Faker<ApiSecretsDto> GetApiSecretFaker(int id, int resourceId)
        {
            var fakerApiSecret = new Faker<ApiSecretsDto>()
                .RuleFor(o => o.Type, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Value, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.ApiSecretId, id)
                .RuleFor(o => o.ApiResourceId, resourceId)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.Expiration, f => f.Date.Future());                

            return fakerApiSecret;
        }
   
        public static Faker<ApiScopesDto> GetApiScopeFaker(int id, int resourceId)
        {
            var fakerApiScope = new Faker<ApiScopesDto>()
                .RuleFor(o => o.Name, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.ApiScopeId, id)
                .RuleFor(o => o.ApiResourceId, resourceId)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.DisplayName, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.UserClaims,
                    f => Enumerable.Range(1, f.Random.Int(1, 10))
                        .Select(x => f.PickRandom(ClientConsts.GetStandardClaims())).ToList())
                .RuleFor(o => o.Emphasize, f => f.Random.Bool())
                .RuleFor(o => o.Required, f => f.Random.Bool())
                .RuleFor(o => o.ShowInDiscoveryDocument, f => f.Random.Bool());              

            return fakerApiScope;
        }

        public static ApiResourceDto GenerateRandomApiResource(int id)
        {
            var apiResource = GetApiResourceFaker(id).Generate();

            return apiResource;
        }

        public static ApiScopesDto GenerateRandomApiScope(int id, int resourceId)
        {
            var apiScope = GetApiScopeFaker(id, resourceId).Generate();

            return apiScope;
        }

        public static ApiSecretsDto GenerateRandomApiSecret(int id, int resourceId)
        {
            var apiSecret = GetApiSecretFaker(id, resourceId).Generate();

            return apiSecret;
        }
    }
}
