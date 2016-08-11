using System.Collections.ObjectModel;
using System.Linq;
using CustomerGreen.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CustomerGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedControlTables1 : DbMigration
    {
        public override void Up()
        {
            try
            {
                InitializeLicenseTypes();
                InitializeBusinessTypes();
                InitializeOrgnUser();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void InitializeOrgnUser()
        {
            using (var context = new CustomerGreenDbContext())
            {
                var organization = new OrganizationProfile
                {
                    About = "Base Org",
                    BusinessType = context.BusinessTypes.FirstOrDefault(b => b.Business == "Online Ordering"),
                    BusinessSubType = context.BusinessSubTypes.FirstOrDefault(b => b.SubType == "Sub Type 1 2"),
                    City = "Chabua",
                    CompanyName = "ITOI",
                    ContactEmail = "manasi.arora@gmail.com",
                    Country = "India",
                    IsActive = true,
                    LicenseType = context.LicenseTypes.FirstOrDefault(b => b.License == "One - One"),
                    Mobile = "8308333954",
                    OrgKey = "ITOI_ORG",
                    Phone = "03732863755",
                    State = "Assam",
                    StrategicEmail = "manasi.arora@gmail.com",
                    Street1 = "Street 1",
                    Street2 = "Street 2",
                    TacticalEmail = "manasi.arora@gmail.com",
                    Website = "http://www.itoi.com",
                    Zip = "786102"
                };

                context.Organizations.Add(organization);

                context.SaveChanges();

                var org = context.Organizations.FirstOrDefault(o => o.CompanyName == "ITOI");

                if (org != null)
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                    {
                        AllowOnlyAlphanumericUserNames = true
                    };
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                    if (!roleManager.RoleExists("Admin"))
                    {
                        roleManager.Create(new IdentityRole("Admin"));
                    }

                    if (!roleManager.RoleExists("Member"))
                    {
                        roleManager.Create(new IdentityRole("Member"));
                    }

                    var user = new ApplicationUser()
                    {
                        Email = "manasi.arora@gmail.com",
                        UserName = "admin",
                        FirstName = "Manasi",
                        LastName = "Arora",
                        OrgId = org.Id
                    };

                    var userResult = userManager.Create(user, "Admin@123");

                    if (userResult.Succeeded)
                    {
                        userManager.AddToRole<ApplicationUser, string>(user.Id, "Admin");
                    }

                    context.SaveChanges();
                }
            }
        }

        public void InitializeLicenseTypes()
        {
            var licenseType1 = new LicenseType
            {
                Active = true,
                Cost = 100,
                StartTime = new DateTime(2016, 1, 1),
                EndTime = new DateTime(2016, 12, 31),
                License = "One - One"
            };

            var licenseType2 = new LicenseType
            {
                Active = true,
                Cost = 100,
                StartTime = new DateTime(2016, 1, 1),
                EndTime = new DateTime(2016, 12, 31),
                License = "One - Many"
            };

            var licenseType3 = new LicenseType
            {
                Active = true,
                Cost = 100,
                StartTime = new DateTime(2016, 1, 1),
                EndTime = new DateTime(2016, 12, 31),
                License = "Many - Many"
            };
            using (var context = new CustomerGreenDbContext())
            {
                context.LicenseTypes.Add(licenseType1);
                context.LicenseTypes.Add(licenseType2);
                context.LicenseTypes.Add(licenseType3);

                context.SaveChanges();
            }
        }

        public void InitializeBusinessTypes()
        {
            var businessType1 = new BusinessType
            {
                Business = "Online Ordering",
                SubType = new Collection<BusinessSubType>()
            };
            businessType1.SubType.Add(new BusinessSubType { SubType = "Sub Type 1 1" });
            businessType1.SubType.Add(new BusinessSubType { SubType = "Sub Type 1 2" });


            var businessType2 = new BusinessType
            {
                Business = "Food",
                SubType = new Collection<BusinessSubType>()
            };
            businessType2.SubType.Add(new BusinessSubType { SubType = "Sub Type 2 1" });
            businessType2.SubType.Add(new BusinessSubType { SubType = "Sub Type 2 2" });


            var businessType3 = new BusinessType
            {
                Business = "Education",
                SubType = new Collection<BusinessSubType>()
            };
            businessType3.SubType.Add(new BusinessSubType { SubType = "Sub Type 3 1" });
            businessType3.SubType.Add(new BusinessSubType { SubType = "Sub Type 3 2" });


            using (var context = new CustomerGreenDbContext())
            {
                context.BusinessTypes.Add(businessType1);
                context.BusinessTypes.Add(businessType2);
                context.BusinessTypes.Add(businessType3);

                context.SaveChanges();
            }
        }

        public override void Down()
        {
            Sql("DELETE from [BusinessSubTypes]");
            Sql("DELETE from [BusinessTypes]");
            Sql("DELETE from [LicenseTypes]");
        }
    }
}