using System.Linq;
using CustomerGreen.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace CustomerGreen.Data
{
    public class BigBangInitializer : DropCreateDatabaseIfModelChanges<CustomerGreenDbContext>
    {
        protected override void Seed(CustomerGreenDbContext context)
        {
 
            
            base.Seed(context);
        }

 
    }
}