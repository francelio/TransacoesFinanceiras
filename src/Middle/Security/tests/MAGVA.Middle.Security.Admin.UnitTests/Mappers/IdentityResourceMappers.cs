﻿using System.Linq;
using FluentAssertions;
using MAGVA.Middle.Security.Admin.BusinessLogic.Mappers;
using MAGVA.Middle.Security.Admin.UnitTests.Mocks;
using Xunit;

namespace MAGVA.Middle.Security.Admin.UnitTests.Mappers
{
    public class IdentityResourceMappers
    {
        [Fact]
        public void CanMapIdentityResourceToModel()
        {
            //Generate entity
            var identityResource = IdentityResourceMock.GenerateRandomIdentityResource(1);

            //Try map to DTO
            var identityResourceDto = identityResource.ToModel();

            //Asert
            identityResourceDto.Should().NotBeNull();

            identityResource.ShouldBeEquivalentTo(identityResourceDto, options =>
                options.Excluding(o => o.UserClaims));

            //Assert collection
            identityResource.UserClaims.Select(x => x.Type).ShouldBeEquivalentTo(identityResourceDto.UserClaims);
        }

        [Fact]
        public void CanMapIdentityResourceDtoToEntity()
        {
            //Generate DTO
            var identityResourceDto = IdentityResourceDtoMock.GenerateRandomIdentityResource(1);

            //Try map to entity
            var identityResource = identityResourceDto.ToEntity();

            identityResource.Should().NotBeNull();

            identityResource.ShouldBeEquivalentTo(identityResourceDto, options =>
                options.Excluding(o => o.UserClaims));

            //Assert collection
            identityResource.UserClaims.Select(x => x.Type).ShouldBeEquivalentTo(identityResourceDto.UserClaims);
        }
    }
}
