using Microsoft.AspNetCore.Identity;
using Proiect1.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect1.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext db;

        public InitialSeed(RoleManager<Role> roleManager, UserManager<User> userManager, AppDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.db = db;
        }

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "User"
                                };

            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                _roleManager.CreateAsync(role).Wait();
            }
        }

        public async Task CreateUsers()
        {
            var admin = new User
            {
                Email = "admin@gmail.com",
                UserName = "admin"
            };
            var user_verify = db.Users.SingleOrDefault(x => x.Email == admin.Email);
            if (user_verify == null)
            {
                await _userManager.CreateAsync(admin, "Admin0!");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            var user1 = new User
            {
                Email = "miruna@gmail.com",
                UserName = "mirunaa08"
            };
            user_verify = db.Users.SingleOrDefault(x => x.Email == user1.Email);
            if (user_verify == null)
            {
                await _userManager.CreateAsync(user1, "Miruna08!");
                await _userManager.AddToRoleAsync(user1, "User");
            }

            var user2 = new User
            {
                Email = "mara@gmail.com",
                UserName = "maraa16"
            };
            user_verify = db.Users.SingleOrDefault(x => x.Email == user2.Email);
            if (user_verify == null)
            {
                await _userManager.CreateAsync(user2, "Mara16!");
                await _userManager.AddToRoleAsync(user2, "User");
            }
        }

    }
}
