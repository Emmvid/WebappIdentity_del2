using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Context;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Helpers.Services;

public class UserService
{
    #region Private and constructor
    private readonly IdentityContext _identityContext;

    public UserService(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }
    #endregion
    public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
    {

        var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
        return userProfileEntity;
    }
}
