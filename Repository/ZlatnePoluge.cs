using Microsoft.EntityFrameworkCore;
using PriceUpdater.DbContexts;
using PriceUpdater.Entities;

namespace PriceUpdater.Repository
{
    public class ZlatnePoluge : IZlatnePoluge
    {
        private readonly PriceUpdaterContext _context;

        public ZlatnePoluge(PriceUpdaterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));

        }

        public async Task<IEnumerable<Zlatne_poluge>> GetPolugeAsync()
        {
            var kovanice = await _context.ZlatnePoluge.ToListAsync();
            return kovanice;
        }

        public async Task<Zlatne_poluge> GetPolugeAsync(Guid kovaniceId)
        {
            var kovanice = _context.ZlatnePoluge.Where(c => c.id == kovaniceId).FirstOrDefault();
            return kovanice;
        }

        public async Task AddPoluge(Zlatne_poluge zlatne_Poluge)
        {

            await _context.ZlatnePoluge.AddAsync(zlatne_Poluge);
            _context.SaveChanges();

        }
        public void DeleteArticle(Zlatne_poluge zlatne_Poluge)
        {
            _context.ZlatnePoluge.Remove(zlatne_Poluge);
        }

        public async Task UpdateArticle(Zlatne_poluge zlatne_Poluge)
        {

        }
        public bool ArticleExists(Guid zlatnepolugeId)
        {
            return _context.ZlatnePoluge.Any(c => c.id == zlatnepolugeId);
        }
        public async Task<bool> Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }




    }
}
