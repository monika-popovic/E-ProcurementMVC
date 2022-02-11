using E_Procurement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Procurement.Data.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly AppDbContext _context;

        public SubcategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
        }

        public void DeleteSubcategory(int id)
        {
            var subcategory = _context.Subcategories.Find(id);
            if (subcategory != null)
                _context.Subcategories.Remove(subcategory);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Subcategory> GetSubcategories()
        {
            return _context.Subcategories
                .Include(c => c.Category)
                .ToList();
        }

        public Subcategory GetSubcategoryById(int id)
        {
            return _context.Subcategories.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
        }
    }
}
