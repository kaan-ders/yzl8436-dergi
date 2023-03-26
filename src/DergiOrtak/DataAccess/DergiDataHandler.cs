using DergiOrtak.Entity;
using Microsoft.EntityFrameworkCore;

namespace DergiOrtak.DataAccess
{
    public class DergiDataHandler
    {
        private DergiDbContext _context;
        public DergiDataHandler(DergiDbContext context)
        {
            _context = context;
        }

        public List<Dergi> Listele()
        {
            return _context.Dergi.Include(x=> x.Kategori).Where(x => x.SilindiMi == false).ToList();
        }

        public Dergi Getir(int id)
        {
            return _context.Dergi.FirstOrDefault(x => x.Id == id);
        }
    }
}