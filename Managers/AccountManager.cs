using GimpiesBlazor.Data;
using GimpiesBlazor.Handlers;
using GimpiesBlazor.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GimpiesBlazor.Managers
{
    public class AccountManager(AppDbContext context)
    {
        public string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<AccountManager>();
            return passwordHasher.HashPassword(this, password);
        }

        public bool VerifyPassword(string passwordHash, string password)
        {
            var passwordHasher = new PasswordHasher<AccountManager>();
            var result = passwordHasher.VerifyHashedPassword(this, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password, string role)
        {
            try
            {
                var existingRole = await context.Roles
                    .FirstOrDefaultAsync(r => r.RoleName == role);

                if (existingRole == null)
                {
                    existingRole = new Role
                    {
                        RoleName = role,
                        RolePermissions = (List<RolePermission>) []
                    };

                    context.Roles.Add(existingRole);
                }

                var account = new Account
                {
                    Username = username,
                    Email = email,
                    PasswordHash = HashPassword(password),
                    FkRoleId = existingRole.RoleId,
                    Role = existingRole
                };

                context.Accounts.Add(account);

                var result = await context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ErrorHandler.GetErrorMessage(ProgramError.DatabaseError), ex);
            }
        }

        public async Task<(Account? account, bool isActive)> CheckAccountAsync(string usernameOrEmail, string password)
        {
            try
            {
                var account = await context.Accounts
                    .Include(a => a.Role)
                    .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                    .FirstOrDefaultAsync(a => 
                        EF.Functions.Collate(a.Username, "SQL_Latin1_General_CP1_CS_AS") == usernameOrEmail ||
                        EF.Functions.Collate(a.Email, "SQL_Latin1_General_CP1_CS_AS") == usernameOrEmail);


                if (account != null && VerifyPassword(account.PasswordHash, password))
                    return account.IsActive ? (account, true) : (account, false);

                return (null, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Er is een fout opgetreden bij het ophalen van een account!");
            }
        }

        public async Task<Account?> GetAccount(string username, string email)
        {
            try
            {
                return await context.Accounts
                    .Include(a => a.Role)
                    .FirstOrDefaultAsync(a => a.Username == username || a.Email == email);
            }
            catch
            {
                throw new InvalidOperationException("Er is een fout opgetreden bij het ophalen van een account!");
            }
        }

        public void LogoutUser()
        {
            
        }
    }
}
