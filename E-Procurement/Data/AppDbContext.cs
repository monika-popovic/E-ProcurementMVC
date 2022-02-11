using E_Procurement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Procurement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories  { get; set; }
        public DbSet<Subcategory> Subcategories  { get; set; }
        public DbSet<Article> Articles  { get; set; }
    }
}
