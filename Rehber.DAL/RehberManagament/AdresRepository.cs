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
    public class AdresRepository : IAdres
    {
        RehberDbContext _db;//burda newlemedim  her tıkladığımda yeni bir instance almasın diye
        //Şuan açık açık olan bağlantıya devam edicek

        public AdresRepository()
        {
            _db = new RehberDbContext();
        }
        public void Add(Adres item)
        {
            _db.Adres.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Adres item)
        {
            _db.Adres.Remove(item);
            _db.SaveChanges();
        }

        public ICollection<Adres> GetAll(Expression<Func<Adres, bool>> parameter = null)
        {
            return parameter == null ?
                _db.Adres.ToList() :
            _db.Adres.Where(parameter).ToList();
        }

        public void Update(Adres item)
        {
            Adres EskiAdres = _db.Adres.Find(item.AdresID);
            EskiAdres.AdresID = item.AdresID;
            EskiAdres.Il = item.Il;
            EskiAdres.Ilce = item.Ilce;
            _db.SaveChanges();
        }
    }
}
