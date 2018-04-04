using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebForum.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebForumContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebForumContext>>()))
            {
                // Look for any movies.
                if (context.Tread.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tread.AddRange(
                     new Tread
                     {
                         Title = "When Harry Met Sally",
                         Author = "Бабай",
                         Text = "Автоган летит по шоссе"
                     },

                     new Tread
                     {
                         Title = "Ghostbusters ",
                         Author = "Дункан",
                         Text = "Меч отражает лучи солнца"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
