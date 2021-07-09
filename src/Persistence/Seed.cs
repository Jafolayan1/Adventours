using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Jay", UserName = "OluwaJay",Email = "jay@test.com"},
                    new AppUser{DisplayName = "winnie", UserName = "Dpowinnie",Email = "winnie@test.com"},
                    new AppUser{DisplayName = "mubarak", UserName = "mbk",Email = "mbk@test.com"},
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (context.Tours.Any()) return;

            var tours = new List<Tour>
            {
                new Tour
                {
                    TourCenterName = "Ikogosi Warm Spring",
                    Location = " Ekiti State",
                    Description = "The Ikogosi Warm Springs is a tourist attraction located at Ikogosi, a town in Ekiti State, southwestern Nigeria. Flowing abreast the warm spring is another cold blah blah blah ",
                    DateAdded = DateTime.Now.AddDays(-5),
                    Rating = 4,
                    Category = "springing"
                },
                new Tour
                {
                    TourCenterName = "Erin Ijesha Waterfall",
                    Location = "Osun State",
                    Description = "Erin-Ijesha Waterfalls is located in Erin-Ijesha. It is a tourist attraction located in Oriade local government area, Osun State, Nigeria. The waterfalls was discovered in 1140 AD by one of the daughters of Oduduwa. However, blah blah blah ",
                    DateAdded = DateTime.Now.AddDays(-1),
                    Rating = 3,
                    Category = "Waterfalling"
                },
                new Tour
                {
                    TourCenterName = "Olumo Rock",
                    Location = "Ogun State",
                    Description = "Olumo Rock is a mountain in south-western Nigeria. It is located in the ancient city of Abeokuta, Ogun State, and was normally used as a natural fortress during inter-tribal warfare in the 19th century blah blah blah ",
                    DateAdded = DateTime.Now,
                    Rating = 2,
                    Category = "Adventure"
                },
                new Tour
                 {
                    TourCenterName = "Badagy Beach",
                    Location = "Lagos State",
                    Description = "Olumo Rock is a mountain in south-western Nigeria. It is located in the ancient city of Abeokuta, Ogun State, and was normally used as a natural fortress during inter-tribal warfare in the 19th century blah blah blah ",
                    DateAdded = DateTime.Now.AddDays(-10),
                    Rating = 2,
                    Category = "Swimming"
                },
            };

            await context.Tours.AddRangeAsync(tours);
            await context.SaveChangesAsync();
        }
    }
}