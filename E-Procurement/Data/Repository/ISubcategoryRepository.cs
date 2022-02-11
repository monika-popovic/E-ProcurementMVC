using E_Procurement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Procurement.Data.Repository
{
    public interface ISubcategoryRepository
    {
        List<Subcategory> GetSubcategories();
        //Subcategory GetSubcategoryById(int id);
        Subcategory GetSubcategoryById(int id);

        IQueryable<Subcategory> GetSubcategoriesAsQueryable();

        void AddSubcategory(Subcategory subcategory);
        void UpdateSubcategory(Subcategory subcategory);
        void DeleteSubcategory (int id);

        List<Category> GetCategories();
        Task<bool> SaveChangesAsync();
    }
}
