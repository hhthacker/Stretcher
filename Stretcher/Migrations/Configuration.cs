namespace Stretcher.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Stretcher.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Stretcher.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Stretcher.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "heather",
                Email = "hhthacker@gmail.com"
            };

            userManager.CreateAsync(user, "password").Wait();

            context.Stretches.AddOrUpdate( s => s.StretchName,
                new Stretch() { StretchName = "Ostrich Stretch", StretchDescription = "Stick that neck out", StretchDifficulty = 1 },
                new Stretch() { StretchName = "Kitten Stretch", StretchDescription = "Curl up like a kitten", StretchDifficulty = 1 },
                new Stretch() { StretchName = "Donkey Stretch", StretchDescription = "Kick it!", StretchDifficulty = 2 },
                new Stretch() { StretchName = "Hippo Stretch", StretchDescription = "Ice cream binge!", StretchDifficulty = 1 },
                new Stretch() { StretchName = "Dancer Stretch", StretchDescription = "Don't stop til you get enough", StretchDifficulty = 3 },
                new Stretch() { StretchName = "Mouse Stretch", StretchDescription = "Double click away", StretchDifficulty = 1 },
                new Stretch() { StretchName = "Pretzel Stretch", StretchDescription = "Twisted with a side of mustard", StretchDifficulty = 3 },
                new Stretch() { StretchName = "Tree Stretch", StretchDescription = "Grow bb Grow", StretchDifficulty= 3 }
            );

            context.Goals.AddOrUpdate( g => g.GoalName,
                new Goal() { Intensity = 2, GoalName = "Sun Salutation", GoalDescription = "Say hello to our one and only shining star!" },
                new Goal() { Intensity = 3, GoalName = "Shoulder Flow", GoalDescription = "Roll em back roll em forward, little circles, big, big, big." },
                new Goal() { Intensity = 1, GoalName = "Fetal Flow", GoalDescription = "Curl up and cry" }
            );

            context.Reflections.AddOrUpdate( r => r.ReflectionTitle,
                new Reflection() { ReflectionCreation = DateTime.Now, ReflectionTitle = "Hot Breath", ReflectionNotes = "The breath of fire burned my belly like a summer without polar bears"},
                new Reflection() { ReflectionCreation = DateTime.Now, ReflectionTitle = "Slow Shoulder fo sho", ReflectionNotes = "Ouchie mama my girdles are sizzling!"},
                new Reflection() { ReflectionCreation = DateTime.Now, ReflectionTitle = "Child poser", ReflectionNotes = "Still a baby, not yet a toddler"}
            );

            context.SaveChanges();

        }
    }
}
