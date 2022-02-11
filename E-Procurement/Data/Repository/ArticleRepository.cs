using E_Procurement.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Procurement.Data
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddArtcle(Article article)
        {
            _context.Articles.Add(article);
        }

        public void DeleteArticle(int id)
        {
            Article article = _context.Articles.Find(id);
            _context.Articles.Remove(article);
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
        }
    }
}
