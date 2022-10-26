namespace EntityDataAccess.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityDataAccess.HouseholdManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EntityDataAccess.HouseholdManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var account = new Account { Username = "admin", Type = AccountType.Admin };
            context.Accounts.AddOrUpdate(account);

            var household = new Household { Owner = "Đăng ký tạm trú", Address = "Tri phương Tiên Du Bắc Ninh", MemberCount = 1 };
            context.Households.AddOrUpdate(household);

            var person = new Person { Name = "Vũ Quang Long", Address = "Tri phương Tiên Du Bắc Ninh" };
            context.People.AddOrUpdate(person);

            var donate = new Donate();
            context.Donates.AddOrUpdate(donate);

            var fee = new Fee();
            context.Fees.AddOrUpdate(fee);

            var donateInfo = new DonateInfo { Donate = donate, Household = household };
            context.DonateInfos.AddOrUpdate(donateInfo);

            var feeInfo = new FeeInfo { Fee = fee, Household = household };
            context.FeeInfos.AddOrUpdate(feeInfo);

            context.SaveChanges();

        }
    }
}
