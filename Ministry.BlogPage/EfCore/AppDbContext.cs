using Microsoft.EntityFrameworkCore;
using Ministry.BlogPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.EfCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<RuleFiles> RuleFiles { get; set; }
    }
}
