using PriceUpdater.Entities;

namespace PriceUpdater.Repository
{
    public interface IZlatnePoluge
    {
        Task AddPoluge(Zlatne_poluge zlatne_Poluge);
        bool ArticleExists(Guid zlatnepolugeId);
        void DeleteArticle(Zlatne_poluge zlatne_Poluge);
        void Dispose();
        Task<IEnumerable<Zlatne_poluge>> GetPolugeAsync();
        Task<Zlatne_poluge> GetPolugeAsync(Guid kovaniceId);
        Task<bool> Save();
        Task UpdateArticle(Zlatne_poluge zlatne_Poluge);
    }
}