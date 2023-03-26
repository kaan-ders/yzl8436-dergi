using DergiOrtak.Entity;

namespace DergiOrtak.DataAccess
{
    public class MakaleDataHandler
    {
        private DergiDbContext _context;
        public MakaleDataHandler(DergiDbContext context)
        {
            _context = context;
        }

        public List<Makale> Listele(int sayiId)
        {
            return _context.Makale.Where(x=> x.SilindiMi == false && x.SayiId == sayiId).ToList();
        }

        public Makale Getir(int id)
        {
            return _context.Makale.FirstOrDefault(x => x.Id == id);
        }
    }
}
