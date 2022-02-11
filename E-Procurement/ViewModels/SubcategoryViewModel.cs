using E_Procurement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Procurement.ViewModels
{
    public class SubcategoryViewModel
    {
        public int Id { get; set; }
        public string CPVCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public SelectList Categories { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
