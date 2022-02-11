using E_Procurement.Models;

namespace E_Procurement.Data
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticleById(int id);
        void AddArtcle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);

        Task<bool> SaveChangesAsync();

    }
}
