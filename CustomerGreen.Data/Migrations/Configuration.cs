using System;
using System.Linq;
using CustomerGreen.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CustomerGreen.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerGreenDbContext>
    {
        //private readonly bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerGreenDbContext";

            //var migrator = new DbMigrator(this);
            //_pendingMigrations = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(CustomerGreenDbContext context)
        {
            //if (!_pendingMigrations) return;

            //InitializeLicenseTypes(context);
            //InitializeBusinessTypes(context);
            //InitializeBusinessSubTypes(context);
            //InitializeOrgnUser(context);

            //base.Seed(context);
        }

        //public void InitializeOrgnUser(CustomerGreenDbContext context)
        //{
        //    try
        //    {
        //        var organization = new OrganizationProfile
        //        {
        //            About = "Base Org",
        //            BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Id == 1),
        //            BusinessSubType = context.BusinessSubTypes.FirstOrDefault(b => b.Id == 1),
        //            City = "Chabua",
        //            CompanyName = "ITOI",
        //            ContactEmail = "manasi.arora@gmail.com",
        //            Country = "India",
        //            IsActive = true,
        //            LicenseType = context.LicenseTypes.FirstOrDefault(b => b.Id == 1),
        //            Mobile = "8308333954",
        //            OrgKey = "ITOI_ORG",
        //            Phone = "03732863755",
        //            State = "Assam",
        //            StrategicEmail = "manasi.arora@gmail.com",
        //            Street1 = "Street 1",
        //            Street2 = "Street 2",
        //            TacticalEmail = "manasi.arora@gmail.com",
        //            Website = "www.itoi.com",
        //            Zip = "786102"
        //        };

        //        context.Organizations.Add(organization);

        //        context.Commit();

        //        var org = context.Organizations.FirstOrDefault(o => o.CompanyName == "ITOI");

        //        if (org != null)
        //        {
        //            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
        //            {
        //                AllowOnlyAlphanumericUserNames = true
        //            };
        //            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        //            if (!roleManager.RoleExists("Admin"))
        //            {
        //                roleManager.Create(new IdentityRole("Admin"));
        //            }

        //            if (!roleManager.RoleExists("Member"))
        //            {
        //                roleManager.Create(new IdentityRole("Member"));
        //            }

        //            var user = new ApplicationUser()
        //            {
        //                Email = "manasi.arora@gmail.com",
        //                UserName = "admin",
        //                FirstName = "Manasi",
        //                LastName = "Arora",
        //                OrgId = org.Id
        //            };

        //            var userResult = userManager.Create(user, "Admin@123");

        //            if (userResult.Succeeded)
        //            {
        //                userManager.AddToRole<ApplicationUser, string>(user.Id, "Admin");
        //            }

        //            context.Commit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public void InitializeLicenseTypes(CustomerGreenDbContext context)
        //{
        //    var LicenseType1 = new LicenseType
        //    {
        //        Active = true,
        //        Cost = 100,
        //        StartTime = new DateTime(2016, 1, 1),
        //        EndTime = new DateTime(2016, 12, 31),
        //        License = "One - One"
        //    };

        //    var LicenseType2 = new LicenseType
        //    {
        //        Active = true,
        //        Cost = 100,
        //        StartTime = new DateTime(2016, 1, 1),
        //        EndTime = new DateTime(2016, 12, 31),
        //        License = "One - Many"
        //    };

        //    var LicenseType3 = new LicenseType
        //    {
        //        Active = true,
        //        Cost = 100,
        //        StartTime = new DateTime(2016, 1, 1),
        //        EndTime = new DateTime(2016, 12, 31),
        //        License = "Many - Many"
        //    };

        //    context.LicenseTypes.Add(LicenseType1);
        //    context.LicenseTypes.Add(LicenseType2);
        //    context.LicenseTypes.Add(LicenseType3);

        //    context.Commit();
        //}

        //public void InitializeBusinessTypes(CustomerGreenDbContext context)
        //{
        //    var businessType1 = new BusinessType
        //    {
        //        Business = "Online Ordering"
        //    };

        //    var businessType2 = new BusinessType
        //    {
        //        Business = "Food"
        //    };

        //    var businessType3 = new BusinessType
        //    {
        //        Business = "Education"
        //    };

        //    context.BusinessTypes.Add(businessType1);
        //    context.BusinessTypes.Add(businessType2);
        //    context.BusinessTypes.Add(businessType3);

        //    context.Commit();
        //}

        //public void InitializeBusinessSubTypes(CustomerGreenDbContext context)
        //{
        //    var businessSubType11 = new BusinessSubType
        //    {
        //        BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Business == "Online Ordering"),
        //        SubType = "Sub Type 1 1"
        //    };

        //    var businessSubType21 = new BusinessSubType
        //    {
        //        BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Business == "Food"),
        //        SubType = "Sub Type 2 1"
        //    };

        //    var businessSubType31 = new BusinessSubType
        //    {
        //        BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Business == "Education"),
        //        SubType = "Sub Type 3 1"
        //    };

        //    var businessSubType12 = new BusinessSubType
        //    {
        //        BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Business == "Online Ordering"),
        //        SubType = "Sub Type 1 2"
        //    };

        //    var businessSubType32 = new BusinessSubType
        //    {
        //        BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Business == "Education"),
        //        SubType = "Sub Type 3 2"
        //    };

        //    context.BusinessSubTypes.Add(businessSubType11);
        //    context.BusinessSubTypes.Add(businessSubType12);
        //    context.BusinessSubTypes.Add(businessSubType21);
        //    context.BusinessSubTypes.Add(businessSubType31);
        //    context.BusinessSubTypes.Add(businessSubType32);

        //    context.Commit();
        //}
    }
}
