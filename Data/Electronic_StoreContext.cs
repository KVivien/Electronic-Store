using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Electronic_Store.Models;

namespace Electronic_Store.Data
{
    public class Electronic_StoreContext : DbContext
    {
        public Electronic_StoreContext (DbContextOptions<Electronic_StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Electronic_Store.Models.Product> Product { get; set; } = default!;

        public DbSet<Electronic_Store.Models.Vendor>? Vendor { get; set; }
    }
}
