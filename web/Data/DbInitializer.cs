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
                new Creda{CredeID = "0", Opombe = "/"},
                new Creda{CredeID = "1", Opombe = "V štali"},
                new Creda{CredeID = "2", Opombe = "Na pašniku"}
            };

            foreach (Creda c in crede) {
                context.Crede.Add(c);
            }
            context.SaveChanges();


            var ovce = new Ovca[]
            {
                new Ovca{OvcaID="/", CredaID="0"},
                new Ovca{OvcaID="632", CredaID=crede[1].CredeID, DatumRojstva=DateTime.Parse("20.2.2014"), Pasma="JSR", Stanje="Živa", Opombe="Bella, Pako"},
                new Ovca{OvcaID="639",  CredaID=crede[1].CredeID, Pasma="JSR", Stanje="Živa", Opombe="Effie, Pako"}, 
                new Ovca{OvcaID="772", CredaID=crede[1].CredeID, Pasma="JS", DatumRojstva=DateTime.Parse("6.7.2017")},
                new Ovca{OvcaID="677", CredaID=crede[2].CredeID, Pasma="JS", DatumRojstva=DateTime.Parse("19.1.2018")},
                new Ovca{OvcaID="680", CredaID=crede[2].CredeID, Pasma="JS", DatumRojstva=DateTime.Parse("12.1.2020")},
                new Ovca{OvcaID="377", CredaID=crede[2].CredeID, Pasma="JS", DatumRojstva=DateTime.Parse("4.2.2020")}
               
            };
            foreach (Ovca o in ovce)
            {
                context.Ovce.Add(o);
            }
            context.SaveChanges();
            
            var ovni = new Oven[]
            {
                new Oven{OvenID="/", CredaID="0"},
                new Oven{OvenID="102", CredaID=crede[1].CredeID, Pasma="Dorper", SteviloSorojencev = 2, Poreklo = "Avstrija"},
                new Oven{OvenID="666", CredaID=crede[2].CredeID, Pasma="Dorper", SteviloSorojencev = 2, Poreklo = "Slovenija"}
               
            };
            foreach (Oven ov in ovni)
            {
                context.Ovni.Add(ov);
            }
            context.SaveChanges();


            var kotitve = new Kotitev[]
            {
                new Kotitev{DatumKotitve=DateTime.Parse("12-01-2019"),  OvcaID=ovce[1].OvcaID, OvenID = ovni[1].OvenID, SteviloMrtvih = 0},
                new Kotitev{DatumKotitve=DateTime.Parse("20-12-2019"),  OvcaID=ovce[2].OvcaID, OvenID = ovni[1].OvenID, SteviloMrtvih = 0},
                new Kotitev{DatumKotitve=DateTime.Parse("01-12-2020"),  OvcaID=ovce[5].OvcaID, OvenID = ovni[2].OvenID, SteviloMrtvih = 0},
                new Kotitev{DatumKotitve=DateTime.Parse("03-12-2020"),  OvcaID=ovce[4].OvcaID, OvenID = ovni[2].OvenID, SteviloMrtvih = 0},
                
            };
            foreach (Kotitev k in kotitve)
            {
                context.Kotitve.Add(k);
            }
            context.SaveChanges();

            var gonitve = new Gonitev[]
            {
                new Gonitev{OvcaID = ovce[1].OvcaID, OvenID = ovni[1].OvenID, DatumGonitve=DateTime.Parse("10-01-2019")},
                new Gonitev{OvcaID = ovce[2].OvcaID, OvenID = ovni[1].OvenID, DatumGonitve=DateTime.Parse("08-11-2020")},
                new Gonitev{OvcaID = ovce[3].OvcaID, OvenID = ovni[2].OvenID, DatumGonitve=DateTime.Parse("08-11-2020")},
            };
            foreach (Gonitev g in gonitve)
            {
                context.Gonitve.Add(g);
            }

            context.SaveChanges();
        }
    }
}