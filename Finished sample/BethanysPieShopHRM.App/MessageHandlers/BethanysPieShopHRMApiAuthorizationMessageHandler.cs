using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.MessageHandlers
{
    public class BethanysPieShopHRMApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public BethanysPieShopHRMApiAuthorizationMessageHandler(
            IAccessTokenProvider provider, NavigationManager navigation) 
            : base(provider, navigation)
        {
            ConfigureHandler(
                  authorizedUrls: new[] { "https://localhost:44340/" });
        }
    }
}
