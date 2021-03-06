using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class AuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> ResetPassword(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            await _context.SaveChangesAsync();

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //this uses the passwordSalt to create a key from the original password.
            //Ie hashes should now match
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.MainAdmin = false;

            //save to database.
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        public async Task<User> GetUser(int ID)
        {
            User user = await _context.Users.Include(x => x.UserPermissions).FirstOrDefaultAsync(x => x.Id == ID);

            return user;
        }

        public async Task<User> GetUser(string username)
        {
            User user = await _context.Users.Include(x => x.UserPermissions).FirstOrDefaultAsync(x => x.Username == username);

            return user;
        }

        public async Task<bool> MainAdminExists()
        {
            //User user = await _context.Users.Include(x => x.UserPermissions).FirstOrDefaultAsync(x => x.MainAdmin == true)
            /*
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            */
            /*if(await _context.Users.AnyAsync(x => x.MainAdmin == true))
                return true;

            return false;*/

            List<User> UserList = await GetAllUsers();
            foreach (User user in UserList)
            {
                if (user.MainAdmin == true)
                {
                    return true;
                }
            }
            
            return false;

        }

        public async Task<Permissions> GetPermissions(int ID)
        {
            Permissions permissions = await _context.Permissions.FirstOrDefaultAsync(x => x.PermissionsUserId == ID);

            return permissions;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await _context.Users.Include(x => x.UserPermissions).ToListAsync();
            return users;
        }

        public async Task<Permissions> CreatePermissions(Permissions permissions)
        {
            //save to database.
            await _context.Permissions.AddAsync(permissions);
            await _context.SaveChangesAsync();

            return permissions;
        }

        public async Task<bool> DeleteUser(int ID)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == ID);
            Permissions permissions = await _context.Permissions.FirstOrDefaultAsync(x => x.PermissionsUserId == ID);

            if (user == null)
                return false;
            else
            {
                _context.Users.Remove(user);
                if (permissions != null)
                {
                    _context.Permissions.Remove(permissions);
                }
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetUserPermissions(int UserId, Permissions permissions)
        {
            User exist = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);

            if (exist == null)
                return false;

            exist.UserPermissions = permissions;

            //await _context.Customers.AddAsync(exist);
            //await _context.SaveChangesAsync();*/

            _context.Users.Update(exist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetApiAuthToken(int UserId, string token, string realmID)
        {
            User exist = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);

            if (exist == null)
                return false;

            exist.ApiAuthToken = token;
            exist.realmID = realmID;

            _context.Users.Update(exist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetMainAdmin(int UserId, bool mainAdmin)
        {
            User exist = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);

            if (exist == null)
                return false;

            exist.MainAdmin = mainAdmin;

            _context.Users.Update(exist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ModifyUserPermissions(int ID, Permissions permissions)
        {
            //User exist = await _context.Users.FirstOrDefaultAsync(x => x.Id == ID);
            Permissions permissionsExist = await _context.Permissions.FirstOrDefaultAsync(x => x.PermissionsUserId == ID);

            if (permissionsExist == null)//if (exist == null || permissionsExist == null)
                return false;

            if (permissions != null)
            {
                permissionsExist.AddAlert = permissions.AddAlert;
                permissionsExist.AddCustomer = permissions.AddCustomer;
                permissionsExist.AddInvoice = permissions.AddInvoice;
                permissionsExist.AddIventory = permissions.AddIventory;
                permissionsExist.AddLocation = permissions.AddLocation;
                permissionsExist.ArchiveInvoice = permissions.ArchiveInvoice;
                permissionsExist.ArchiveIventory = permissions.ArchiveIventory;
                permissionsExist.DeleteAlert = permissions.DeleteAlert;
                permissionsExist.DeleteCustomer = permissions.DeleteCustomer;
                permissionsExist.DeleteLocation = permissions.DeleteLocation;
                permissionsExist.Level = permissions.Level;
                permissionsExist.SetUserPermissions = permissions.SetUserPermissions;
                permissionsExist.UpdateAlert = permissions.UpdateAlert;
                permissionsExist.UpdateCustomer = permissions.UpdateCustomer;
                permissionsExist.UpdateInventory = permissions.UpdateInventory;
                permissionsExist.UpdateInvoice = permissions.UpdateInvoice;
                permissionsExist.ViewAlert = permissions.ViewAlert;
                permissionsExist.ViewCustomer = permissions.ViewCustomer;
                permissionsExist.ViewInventory = permissions.ViewInventory;
                permissionsExist.ViewInvoice = permissions.ViewInvoice;
                permissionsExist.ViewLocation = permissions.ViewLocation;
                permissionsExist.ViewUserPermissions = permissions.ViewUserPermissions;
                //exist.UserPermissions = permissions;
                _context.Permissions.Update(permissionsExist);
                await _context.SaveChangesAsync();
            }

            //_context.Users.Update(exist);
            //await _context.SaveChangesAsync();

            return true;
        }


    }
}