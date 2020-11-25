using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;


namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(eShepherdContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Ovce.Any())
            {
                return;   // DB has been seeded
            }

            var crede = new Creda[]

            {
                new Creda{CredeID = 1},
            };

            foreach (Creda c in crede) {
                context.Crede.Add(c);
            }
            context.SaveChanges();

            var ovceArray = new Ovca[]
            {
            new Ovca{OvcaID="031 654", DatumRojstva=DateTime.Parse("2005-09-01")},

            };
            foreach (Ovca s in ovceArray)
            {
                context.Ovce.Add(s);
            }
            context.SaveChanges();

            var kotitveArray = new Kotitev[]
            {
            new Kotitev{KotitevID=1050,DatumKotitve=DateTime.Parse("2005-09-01"),SteviloMladih=3},

            };
            foreach (Kotitev k in kotitveArray)
            {
                context.Kotitve.Add(k);
            }
            context.SaveChanges();

            var gonitevArray = new Gonitev[]
            {
            new Gonitev{GonitevID=1050,DatumGonitve=DateTime.Parse("2005-09-01")},
            };
            foreach (Gonitev g in gonitevArray)
            {
                context.Gonitve.Add(g);
            }
            context.SaveChanges();

            var user = new ApplicationUser {
                FirstName="Bob", 
                LastName="Dilon", 
                City="Ljubljana",
                Email="b@email.com",
                NormalizedEmail="xxxx@email.com",
                UserName="Bobby",
                NormalizedUserName = "bobby@email.com",
                PhoneNumber="+1234", 
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName)) {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Testni123");
                user.PasswordHash = hashed;
                context.Users.Add(user);
            };

            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="Administrator"},
                new IdentityRole{Id="2", Name="Manager"}, 
                new IdentityRole{Id="3", Name="Staff"}
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }



            context.SaveChanges();

            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId=roles[0].Id, UserId=user.Id},
                new IdentityUserRole<string>{RoleId=roles[1].Id, UserId=user.Id}
            };
            foreach (IdentityUserRole<string> r in UserRoles) {
                context.UserRoles.Add(r);
            }
            context.SaveChanges();
        }
    }
}