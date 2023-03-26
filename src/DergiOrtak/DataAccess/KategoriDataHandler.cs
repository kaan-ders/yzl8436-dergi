using DergiOrtak.Entity;

namespace DergiOrtak.DataAccess
{
    public class KategoriDataHandler
    {
        private DergiDbContext _context;
        public KategoriDataHandler(DergiDbContext context)
        {
            _context = context;
        }

        public List<Kategori> Listele()
        {
            return _context.Kategori.ToList();
        }
    }
}
