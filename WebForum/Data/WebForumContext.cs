using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebForum.Models
{
    public class WebForumContext : DbContext
    {
        public WebForumContext (DbContextOptions<WebForumContext> options)
            : base(options)
        {
        }

        public DbSet<WebForum.Models.Tread> Tread { get; set; }
    }
}
