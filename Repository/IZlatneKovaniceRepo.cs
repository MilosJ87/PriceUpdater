using PriceUpdater.Entities;

namespace PriceUpdater.Repository
{
    public interface IZlatneKovaniceRepo
    {
        Task AddKovanice(Zlatne_Kovanice zlatne_Kovanice);
        bool ArticleExists(Guid zlatneKovaniceId);
        void DeleteArticle(Zlatne_Kovanice zlatne_Kovanice);
        void Dispose();
        Task<IEnumerable<Zlatne_Kovanice>> GetKovanice();
        Task<Zlatne_Kovanice> GetKovaniceAsync(Guid kovaniceId);
        Task<bool> Save();
        Task UpdateArticle(Zlatne_Kovanice zlatne_Kovanice);
    }
}