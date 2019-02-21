using Rehber.DAL.RehberRepository;
using Rehber.Entities.Contex;
using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.RehberManagament
{
    public class KisiRepository : IKisi
    {
        RehberDbContext _db;
        public KisiRepository()
        {
            _db = new RehberDbContext();
        }
        public void Add(Kisi item)
        {
            _db.Kisi.Add(item);
            _db.SaveChanges();
        }
        public void Delete(Kisi item)
        {
            _db.Kisi.Remove(item);
            _db.SaveChanges();
        }

        public ICollection<Kisi> GetAll(Expression<Func<Kisi, bool>> parameter = null)
        {
            return parameter == null ?
                _db.Kisi.ToList() :
                _db.Kisi.Where(parameter).ToList();
        }

        public void Update(Kisi item)
        {
            Kisi eskiKisi = _db.Kisi.Where(x => x.KisiID == item.KisiID).FirstOrDefault();
            eskiKisi.Adi = item.Adi;
            eskiKisi.Soyadi = item.Soyadi;
            eskiKisi.Yas = item.Yas;
            _db.SaveChanges();
        }
    }
}

