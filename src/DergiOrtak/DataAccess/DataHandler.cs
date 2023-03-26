using DergiOrtak.Entity;

namespace DergiOrtak.DataAccess
{
    public interface IDataHandler
    {
        DergiDataHandler Dergi { get; }
        KategoriDataHandler Kategori { get; }
        SayiDataHandler Sayi { get; }
        MakaleDataHandler Makale { get; }

        void Insert(EntityBase model);
        void Update(EntityBase model);
        void Delete(EntityBase model);
    }

    public class DataHandler : DataHandlerBase, IDataHandler
    {
        private DergiDbContext _context;
        public DataHandler(DergiDbContext context) : base(context)
        {
            _context = context;
        }

        private DergiDataHandler _dergiDataHandler;
        public DergiDataHandler Dergi
        {
            get
            {
                if (_dergiDataHandler == null)
                    _dergiDataHandler = new DergiDataHandler(_context);

                return _dergiDataHandler;
            }
        }

        private KategoriDataHandler _kategoriDataHandler;
        public KategoriDataHandler Kategori
        {
            get
            {
                if (_kategoriDataHandler == null)
                    _kategoriDataHandler = new KategoriDataHandler(_context);

                return _kategoriDataHandler;
            }
        }

        private SayiDataHandler _sayiDataHandler;
        public SayiDataHandler Sayi
        {
            get
            {
                if (_sayiDataHandler == null)
                    _sayiDataHandler = new SayiDataHandler(_context);

                return _sayiDataHandler;
            }
        }

        private MakaleDataHandler _makaleDataHandler;
        public MakaleDataHandler Makale
        {
            get
            {
                if (_makaleDataHandler == null)
                    _makaleDataHandler = new MakaleDataHandler(_context);

                return _makaleDataHandler;
            }
        }
    }
}