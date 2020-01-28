using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ghost.Models;

namespace Ghost.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<Investigation> Investigation { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // setting up getting dates functions for use in controllers
            modelBuilder.Entity<Evidence>()
                .Property(e => e.Date)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Investigation>()
                .Property(i => i.Date)
                .HasDefaultValueSql("GetDate()");
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Ryan",
                LastName = "Clay",
                Email = "Ryan@Ryan.com",
                EmailConfirmed = true,
                NormalizedEmail = "RYAN@RYAN.COM",
                NewUserName = "Ghost_Ryan",
                LockoutEnabled = false,
                SecurityStamp = "12345-6789-ffffff",
                Id="0000222211-22221111"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);
            // created seed data for evidence table

            modelBuilder.Entity<Evidence>().HasData(
                new Evidence()
                {
                    Id = 1,
                    UserId = user.Id,
                    Type= "Audio",
                    Summary="Spooky Ghost was heard here",
                    InvestigationId = 1,
                    MyAudio = "https://townsquare.media/site/518/files/2013/01/5-026StitchinTimeSavesNine.mp3",
                    MyVideo= null
                },
                new Evidence()
                {
                    Id = 2,
                    UserId = user.Id,
                    Type = "Video",
                    Summary = "Spooky Ghost was seen here",
                    InvestigationId = 2,
                    MyAudio= null,
                    MyVideo = "https://youtu.be/vh99uSI22BU"
                },
                new Evidence()
                  {
                Id = 3,
                    UserId = user.Id,
                    Type = "Video",
                    Summary = "Spooky Ghost was seen here",
                    InvestigationId = 2,
                    MyAudio = null,
                    MyVideo = "https://youtu.be/nFqpo0zcvow"
                }
                );
            modelBuilder.Entity<Investigation>().HasData(
                new Investigation()
                {
                    Id = 1,
                    Summary="Investigation Number 1",
                    isPrivate=true,
                    LocationId=1,
                },
                    new Investigation()
                    {
                        Id = 2,
                        Summary = "Investigation Number 2",
                        isPrivate = false,
                        LocationId = 2,
                    },
                        new Investigation()
                        {
                            Id = 3,
                            Summary = "Investigation Number 3",
                            isPrivate = true,
                            LocationId = 3,
                        },
                            new Investigation()
                            {
                                Id = 4,
                                Summary = "Investigation Number 4",
                                isPrivate = false,
                                LocationId = 4,
                            });
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    Id = 1,
                    Name = "Trans-Allegheny Lunatic Asylum",
                    Summary = "The Trans-Allegheny Lunatic Asylum, subsequently the Weston State Hospital, was a Kirkbride [3] psychiatric hospital that was operated from 1864 until 1994 by the government of the U.S. state of West Virginia, in the city of Weston. Weston State Hospital got its name in 1913 which was used while patients occupied it, but was changed back to its originally commissioned, unused name, the Trans-Allegheny Lunatic Asylum, after being reopened as a tourist attraction." +
                    "http://www.trans-alleghenylunaticasylum.com/",
                    Hours="Monday-Friday 9:00am-5:00pm",
                    PhNumber="304-269-5070"
                },
                new Location()
                {
                Id=2,
                Name="West Virginia Penitentiary",
                Summary= "The West Virginia Penitentiary is a gothic-style prison located in Moundsville, West Virginia. Now withdrawn and retired from prison use, it operated from 1876 to 1995. Currently, the site is maintained as a tourist attraction and training facility." +
                "https://wvpentours.com/contact/",
                Hours= "Monday-Friday, 9 am-4 pm. Closed for lunch 12p – 1p.",
                PhNumber= "304-845-6200",

                },
                new Location()
                {
                    Id=3,
                    Name="Lake Shawnee Abandoned Amusment Park",
                    Summary= "The Lake Shawnee Amusement Park is a defunct amusement park in Princeton, West Virginia, United States, located along Lake Shawnee. Opened in 1926, the park operated for 40 years before closing in 1966. It received public attention for a total of 6 deaths that occurred on the premises during its operations, which led to urban legends regarding the park being haunted. Due to these local legends,the park was featured on the television series Scariest Places on Earth in 2002",
                    Hours= "Gates open from 5:00 PM. till 7:00 PM. FOR DAY PHOTOS ONLY," +
                    "Gates open again at 7:00 PM.till 11:00 PM." +
                    "Ticket Booth opens from 5:00 PM.till 10:30 PM." +
                    "Photo History Tour & Lake Nightmare Hostel start at DUSK.",
                    PhNumber="304-921-1580"
                },
                new Location()
                {
                    Id=4,
                    Name="Old Hospital on College Hill",
                    Summary= "The Old Hospital On College Hill is a combination of paranormal tours and a haunted house that is open seasonally during the month of October in Williamson, West Virginia. The facility is only open Thursdays, Fridays, and Saturdays throughout October.",
                    Hours="Thursda-Saturday by appointment only",
                    PhNumber="304-235-5240"
                }

                
                );


        }
    }
}
