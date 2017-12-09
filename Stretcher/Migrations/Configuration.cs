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



            Focus shoulderGirdle = new Focus { FocusArea = "Shoulder Girdle", Description = "Breathe in and gargle the girdle." };
            context.Foci.AddOrUpdate(
                f => f.FocusArea,
                shoulderGirdle

                );

            Stretch appleStretch = new Stretch { StretchName = "Apple Pose", StretchDuration = DateTime.Now, StretchDescription = "It keeps the doctor away", StretchDifficulty = 1, StretchSequence = 2, StretchImage = "blah blah .jpg" };
            context.Stretches.AddOrUpdate(
                s => s.StretchName,
                appleStretch
               );

            Goal superIntense = new Goal { Intensity = 3, OriginalGoalDate = DateTime.Now };
            context.Goals.AddOrUpdate(
                g => g.Intensity,
                superIntense

                );

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
