using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.RehberRepository
{
   public interface IRepositoryBase<TEntity> where TEntity :class
    {
        //Ekleme
        //Silme
        //Güncelleme
        //Listeleme
        //Yukarıdaki işlemlerin iskeletini vermiş oluyorum burada
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);

        //Listeleme için özelleşiyor
        //Sebebi de classın içerisindeki tüm veriyi I colection
        //Yani liste olarak dönmek istediği için
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> parameter = null);




    }
}
