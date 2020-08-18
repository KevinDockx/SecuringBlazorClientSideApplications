// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Marvin.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("country", new [] { "country" })
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("bethanyspieshophrapi", 
                    "Bethany's Pie Shop HR API", 
                    new [] { "country" })
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            { 
                new Client
                {
                    ClientId = "bethanyspieshophr",
                    ClientName = "Bethany's Pie Shop HRM",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = { "https://localhost:44341/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:44341/authentication/logout-callback" },
                    AllowedScopes = { "openid", "profile", "email", "bethanyspieshophrapi", "country" },
                    AllowedCorsOrigins = { "https://localhost:44341" },
                    RequireConsent = false
                }             
            };
    }
}