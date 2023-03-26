using DergiOrtak.DataAccess;
using DergiOrtak.Entity;
using DergiOrtak.ViewModels;

namespace DergiOrtak.Services
{
    public interface ISayiService
    {
        List<SayiViewModel> Listele(int dergiId);
        void Ekle(SayiViewModel vm);
    }

    public class SayiService : ISayiService
    {
        private IDataHandler _dataHandler;
        public SayiService(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public List<SayiViewModel> Listele(int dergiId)
        {
            var liste = _dataHandler.Sayi.Listele(dergiId);
            List<SayiViewModel> vm = new List<SayiViewModel>();

            foreach (var item in liste)
            {
                vm.Add(new SayiViewModel
                {
                    No = item.No,
                    Id = item.Id,
                    YayinTarihi = item.YayinTarihi,
                    DergiId = item.DergiId
                });
            }

            return vm;
        }

        public void Ekle(SayiViewModel vm)
        {
            Sayi model = new Sayi
            {
                DergiId = vm.DergiId.Value,
                No = vm.No,
                YayinTarihi = vm.YayinTarihi
            };

            _dataHandler.Insert(model);
        }
    }
}