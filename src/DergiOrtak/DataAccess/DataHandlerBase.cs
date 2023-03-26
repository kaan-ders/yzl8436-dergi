using DergiOrtak.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.DataAccess
{
    //insert, update, delete
    public abstract class DataHandlerBase
    {
        private DergiDbContext _context;
        public DataHandlerBase(DergiDbContext context)
        {
            _context = context;
        }

        public void Insert(EntityBase model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Update(EntityBase model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }

        public void Delete(EntityBase model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }
    }
}