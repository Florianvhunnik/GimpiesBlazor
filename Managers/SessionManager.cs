using GimpiesBlazor.Models.Entities;

namespace GimpiesBlazor.Managers
{
    public class SessionManager
    {
        public static bool IsLoggedIn => _account != null;
        private static Account? _account;
        public static string Role => _account?.Role.RoleName ?? string.Empty;

        public static void SetAccount(Account account)
        {
            _account = account;
        }

        public static bool HasPermission(string permissionName)
        {
            return _account != null &&
                   _account.Role.RolePermissions.Any(rp => rp.Permission.Name == permissionName);
        }
    }
}
