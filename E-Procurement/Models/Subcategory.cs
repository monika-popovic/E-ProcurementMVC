namespace E_Procurement.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string CPVCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
