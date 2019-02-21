using Rehber.DAL.RehberManagament;
using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.KisiService
{
    public class AdresManager
    {
        //Insert-Update-Delete işlemleri için buradan yönlendirilecek
        //CRUD olarak geçer bu işlemler
        //Create,Read,Update,Delete
        //Mesajlarımı burdan göndereceğim

        AdresRepository _adresRepository;
        public AdresManager()
        {
            _adresRepository = new AdresRepository();
        }
        //Newleme işlemim her zaman constructor içerisinde olmalı.

        public string AddAdres(Adres item)
        {//metodum string çünkü mesaj döndürmesini istiyorum
            try
            {
                _adresRepository.Add(item);
                return "Ekleme işlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string UpdateAdres(Adres item)
        {
            try
            {
                _adresRepository.Update(item);
                return "Update işlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string DeleteAdres(Adres item)
        {
            try
            {
                _adresRepository.Delete(item);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public ICollection<Adres> GetAllAdres(Expression<Func<Adres, bool>> parameter=null)
        {
            return _adresRepository.GetAll(parameter);

        }



    }
}
