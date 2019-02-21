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
    public class KisiManager
    {

        KisiRepository _KisiRepository;
        public KisiManager()
        {
            _KisiRepository = new KisiRepository();
        }
        //Newleme işlemim her zaman constructor içerisinde olmalı.

        public string AddKisi(Kisi item)
        {//metodum string çünkü mesaj döndürmesini istiyorum
            try
            {
                _KisiRepository.Add(item);
                return "Ekleme işlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string UpdateKisi(Kisi item)
        {
            try
            {
                _KisiRepository.Update(item);
                return "Update işlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string DeleteKisi(Kisi item)
        {
            try
            {
                _KisiRepository.Delete(item);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public ICollection<Kisi> GetAllKisi(Expression<Func<Kisi, bool>> parameter = null)
        {
            return _KisiRepository.GetAll(parameter);

        }

    }
}
