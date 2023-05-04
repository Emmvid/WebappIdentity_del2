using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebappIdentity_del2.Services;

namespace WebappIdentity_del2.Factory
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly UserService _userService;



        public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
        {
            _userService = userService;
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {

            var claimsIdentity = await base.GenerateClaimsAsync(user);
            var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName}{userProfileEntity.LastName}"));

            return claimsIdentity;
        }
    }
}
