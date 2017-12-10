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
                Email = "hhthacker@gmail.com",
            };

            userManager.CreateAsync(user, "password").Wait();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Stretches.AddOrUpdate(new Stretch[]
            {
                new Stretch() { StretchName = "Ostrich Stretch", StretchDuration = DateTime.Now, StretchDescription = "Stick that neck out", StretchDifficulty = 1, StretchSequence = 3, StretchImage = "mew mew .jpg" },
                new Stretch() { StretchName = "Kitten Stretch", StretchDuration = DateTime.Now, StretchDescription = "Curl up like a kitten", StretchDifficulty = 1, StretchSequence = 1, StretchImage = "mew mew .jpg" },
                new Stretch() { StretchName = "Donkey Stretch", StretchDuration = DateTime.Now, StretchDescription = "Kick it!", StretchDifficulty = 2, StretchSequence = 2, StretchImage = "mew mew .jpg" },
                new Stretch() { StretchName = "Hippo Stretch", StretchDuration = DateTime.Now, StretchDescription = "Ice cream binge!", StretchDifficulty = 1, StretchSequence = 2, StretchImage = "mew mew .jpg" },
                new Stretch() { StretchName = "Dancer Stretch", StretchDuration = DateTime.Now, StretchDescription = "Don't stop til you get enough", StretchDifficulty = 3, StretchSequence = 1, StretchImage = "mew .jpg" },
                new Stretch() { StretchName = "Mouse Stretch", StretchDuration = DateTime.Now, StretchDescription = "Double click away", StretchDifficulty = 1, StretchSequence = 2, StretchImage = "mewtoo .jpg" },
                new Stretch() { StretchName = "Pretzel Stretch", StretchDuration = DateTime.Now, StretchDescription = "Twisted with a side of mustard", StretchDifficulty = 3, StretchSequence = 2, StretchImage = "mew woof .jpg" },
            });

            context.Goals.AddOrUpdate(new Goal[]
            {
                new Goal() { OriginalGoalDate = DateTime.Now, Intensity = 2, GoalName = "Sun Salutation", GoalDescription = "Say hello to our one and only shining star!" },
                new Goal() { OriginalGoalDate = DateTime.Now, Intensity = 3, GoalName = "Shoulder Flow", GoalDescription = "Roll em back roll em forward, little circles, big, big, big." } 
            });

            context.Foci.AddOrUpdate(new Focus[]
            {
                new Focus() { FocusArea = "Balance", FocusDescription = "Challenges and tightens balances!" },
                new Focus() { FocusArea = "Silence", FocusDescription = "Shhhhhh" },
                new Focus() { FocusArea = "Toes", FocusDescription = "Wiggles the piggles!" }
            });

            context.Reflections.AddOrUpdate(new Reflection[]
            {
                new Reflection() { ReflectionCreation = DateTime.Now, ReflectionTitle = "Hot Breath", ReflectionNotes = "The breath of fire burned my belly like a summer without polar bears", Goal = 1},
                new Reflection() { ReflectionCreation = DateTime.Now, ReflectionTitle = "Slow Shoulder fo sho", ReflectionNotes = "Ouchie mama my girdles are sizzling!", Goal = 2}
            });

            context.SaveChanges();

            //context.GoalStretches.Add
            //highlight line, control + . + shift to create variable
            // context.StretchGoals.addorupdate(
            //  x= > x.whategvermakesitunique,.
            //   new stretchgoal { Stretch = appleStretch, goal = superIntense}
            //   );

            // context.SaveChanges();

        }
    }
}
