using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Data.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MsSqlDbContext(serviceProvider.GetRequiredService<DbContextOptions<MsSqlDbContext>>()))
            {
                if(context.WebSites.Any())
                {
                    return;
                }

                context.WebSites.Add(new WebSite
                {
                    Name = "Test",
                    Url = "www.test.com",
                    Category = new Category { Name = "news" },
                    SnapshotUrl = "www.img.com",
                    LoginEmail = "mail@mail.bg",
                    LoginPassword = "123"
                });

                context.SaveChanges();
            }
        }
   }
}
