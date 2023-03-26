﻿using DergiOrtak.DataAccess;
using DergiOrtak.Entity;
using DergiOrtak.ViewModels;

namespace DergiOrtak.Services
{
    public interface IMakaleService
    {
        List<MakaleViewModel> Listele(int sayiId);
        MakaleViewModel Getir(int id);
        void Ekle(MakaleViewModel vm);
    }

    public class MakaleService : IMakaleService
    {
        private IDataHandler _dataHandler;
        public MakaleService(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public List<MakaleViewModel> Listele(int sayiId)
        {
            var liste = _dataHandler.Makale.Listele(sayiId);
            List<MakaleViewModel> vm = new List<MakaleViewModel>();

            foreach (var item in liste)
            {
                vm.Add(new MakaleViewModel
                {
                    Id = item.Id,
                    Baslik = item.Baslik,
                    Icerigi = item.Icerigi,
                    Ozet = item.Ozet,
                    SayiId = item.SayiId 
                });
            }

            return vm;
        }

        public MakaleViewModel Getir(int id)
        {
            var model = _dataHandler.Makale.Getir(id);
            return new MakaleViewModel
            {
                SayiId = model.SayiId,
                Baslik = model.Baslik,
                Icerigi = model.Icerigi,
                Id = model.Id,
                Ozet = model.Ozet
            };
        }

        public void Ekle(MakaleViewModel vm)
        {
            Makale model = new Makale
            {
                Baslik = vm.Baslik,
                Icerigi = vm.Icerigi,
                Ozet = vm.Ozet,
                SayiId = vm.SayiId
            };

            _dataHandler.Insert(model);
        }
    }
}
