using Microsoft.EntityFrameworkCore;
using PriceUpdater.DbContexts;
using PriceUpdater.Entities;

namespace PriceUpdater.Repository
{
    public class ZlatneKovaniceRepo : IZlatneKovaniceRepo
    {
        private readonly PriceUpdaterContext _context;

        public ZlatneKovaniceRepo(PriceUpdaterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Zlatne_Kovanice>> GetKovanice()
        {
            var kovanice = await _context.ZlatneKovanice.ToListAsync();
            return kovanice;
        }

        public async Task<Zlatne_Kovanice> GetKovaniceAsync(Guid kovaniceId)
        {
            var kovanice = _context.ZlatneKovanice.Where(c => c.id == kovaniceId).FirstOrDefault();
            return kovanice;
        }

        public async Task AddKovanice(Zlatne_Kovanice zlatne_Kovanice)
        {

            await _context.ZlatneKovanice.AddAsync(zlatne_Kovanice);
            _context.SaveChanges();

        }
        public void DeleteArticle(Zlatne_Kovanice zlatne_Kovanice)
        {
            _context.ZlatneKovanice.Remove(zlatne_Kovanice);
        }

        public async Task UpdateArticle(Zlatne_Kovanice zlatne_Kovanice)
        {

        }
        public bool ArticleExists(Guid zlatneKovaniceId)
        {
            return _context.ZlatneKovanice.Any(c => c.id == zlatneKovaniceId);
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
