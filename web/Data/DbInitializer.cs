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

            // Look for any sheep.
            if (context.Ovce.Any())
            {
                return;   // DB has been seeded
            }

            var crede = new Creda[]
            {
                new Creda{Opombe = "V štali"},
                new Creda{Opombe = "Na pašniku"}
            };

            foreach (Creda c in crede) {
                context.Crede.Add(c);
            }
            context.SaveChanges();


            var ovce = new Ovca[]
            {
                new Ovca{OvcaID="632", CredaID=crede[0].CredeID, DatumRojstva=DateTime.Parse("20.2.2019"), Pasma="JSR", Stanje="Živa", Opombe="Bella, Pako"},
                new Ovca{OvcaID="639",  CredaID=crede[0].CredeID, Pasma="JSR", Stanje="Živa", Opombe="Effie, Pako"}, 
                new Ovca{OvcaID="772", CredaID=crede[0].CredeID, Pasma="JS", DatumRojstva=DateTime.Parse("1.1.2020")}
               
            };
            foreach (Ovca o in ovce)
            {
                context.Ovce.Add(o);
            }
            context.SaveChanges();
            
            var ovni = new Oven[]
            {
                new Oven{OvenID="102", CredaID=crede[0].CredeID, Pasma="Dorper", SteviloSorojencev = 2, Poreklo = "Avstrija"}
               
            };
            foreach (Oven ov in ovni)
            {
                context.Ovni.Add(ov);
            }
            context.SaveChanges();


            var kotitve = new Kotitev[]
            {
                new Kotitev{DatumKotitve=DateTime.Parse("12-01-2019"), SteviloMladih=3, OvcaID=ovce[1].OvcaID, OvenID = ovni[0].OvenID, SteviloMrtvih = 0},
                new Kotitev{DatumKotitve=DateTime.Parse("20-12-2019"), SteviloMladih=2, OvcaID=ovce[3].OvcaID, OvenID = ovni[0].OvenID, SteviloMrtvih = 0},
                new Kotitev{DatumKotitve=DateTime.Parse("01-12-2020"), SteviloMladih=2, OvcaID=ovce[0].OvcaID, OvenID = ovni[0].OvenID, SteviloMrtvih = 0},
                
            };
            foreach (Kotitev k in kotitve)
            {
                context.Kotitve.Add(k);
            }
            context.SaveChanges();

            var gonitve = new Gonitev[]
            {
                new Gonitev{OvcaID = ovce[0].OvcaID, OvenID = ovni[0].OvenID, DatumGonitve=DateTime.Parse("10-01-2019")},
                new Gonitev{OvcaID = ovce[1].OvcaID, OvenID = ovni[0].OvenID, DatumGonitve=DateTime.Parse("08-11-2020")}
            };
            foreach (Gonitev g in gonitve)
            {
                context.Gonitve.Add(g);
            }
            context.SaveChanges();
        }
    }
}