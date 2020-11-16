using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace SEP3_Tier1.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync() {
            throw new System.NotImplementedException();
            string commas = ",,,";

            commas.TrimEnd(',');
        }
    }
}