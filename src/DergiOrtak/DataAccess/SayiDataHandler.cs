using DergiOrtak.Entity;

namespace DergiOrtak.DataAccess
{
    public class SayiDataHandler
    {
        private DergiDbContext _context;
        public SayiDataHandler(DergiDbContext context)
        {
            _context = context;
        }

        public List<Sayi> Listele(int dergiId)
        {
            return _context.Sayi
                .Where(x => x.SilindiMi == false && x.DergiId == dergiId)
                .OrderByDescending(x=> x.YayinTarihi)
                .ToList();
        }
    }
}