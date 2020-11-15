using web.Models;
using System;
using System.Linq;

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
        }
    }
}