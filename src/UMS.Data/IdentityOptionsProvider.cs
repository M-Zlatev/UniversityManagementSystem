namespace UMS.Data
{
    using Microsoft.AspNetCore.Identity;

    public class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 3;
        }
    }
}
