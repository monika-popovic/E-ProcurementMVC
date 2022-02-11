using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Procurement.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = 0.0;

        public int SubCategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
