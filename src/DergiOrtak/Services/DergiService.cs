using DergiOrtak.DataAccess;
using DergiOrtak.Entity;
using DergiOrtak.ViewModels;

namespace DergiOrtak.Services
{
    public interface IDergiService
    {
        List<DergiViewModel> Listele();
        DergiViewModel Getir(int id);
        void DergiEkle(DergiViewModel vm);

        List<KategoriViewModel> KategorileriListele();
    }

    public class DergiService : IDergiService
    {
        private IDataHandler _dataHandler;
        public DergiService(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public List<DergiViewModel> Listele()
        {
            var liste = _dataHandler.Dergi.Listele();
            List<DergiViewModel> vm = new List<DergiViewModel>();

            foreach (var item in liste)
            {
                vm.Add(new DergiViewModel
                {
                    Adi = item.Adi,
                    Aciklama = item.Aciklama,
                    Id = item.Id,
                    KategoriAdi = item.Kategori.Adi,
                    KategoriId = item.KategoriId
                });
            }

            return vm;
        }

        public DergiViewModel Getir(int id)
        {
            var model = _dataHandler.Dergi.Getir(id);
            var vm = new DergiViewModel
            {
                Adi = model.Adi,
                Aciklama = model.Aciklama,
                Id = model.Id,
                KategoriAdi = model.Kategori.Adi,
                KategoriId = model.KategoriId
            };

            return vm;
        }

        public List<KategoriViewModel> KategorileriListele()
        {
            var liste = _dataHandler.Kategori.Listele();
            List<KategoriViewModel> vm = new List<KategoriViewModel>();

            foreach (var item in liste)
            {
                vm.Add(new KategoriViewModel
                {
                    Adi = item.Adi,
                    Id = item.Id
                });
            }

            return vm;
        }

        public void DergiEkle(DergiViewModel vm)
        {
            var model = new Dergi
            {
                Aciklama = vm.Aciklama,
                Adi = vm.Adi,
                KategoriId = vm.KategoriId.Value
            };

            _dataHandler.Insert(model);
        }
    }
}
