using EFEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class DaoBase<T> where T :class
    {
        public static MyDbContext CreateContext()
        {
            MyDbContext mdc = CallContext.GetData("s") as MyDbContext;
            if (mdc == null)
            {
                mdc = new MyDbContext();
                CallContext.SetData("s", mdc);
            }
            return mdc;
        }

        /// <summary>
        /// 分离Context对象
        /// </summary>
        public void FenLi(T t)
        {
            //创建ObjectDbContext对象
            MyDbContext mdc = CreateContext();
            var ObjContext = ((IObjectContextAdapter)mdc).ObjectContext;
            //创建新的objSet<Entity>实例
            var objSet = ObjContext.CreateObjectSet<T>();
            //为特定对象创建实体键，如果实体键存在，则返回该键
            var objKey = ObjContext.CreateEntityKey(objSet.EntitySet.Name, mdc);
            //返回具有指定实体键的对象
            object objT;
            var ext = ObjContext.TryGetObjectByKey(objKey, out objT);
            //从对象上下文移除对象
            if (ext)
            {
                ObjContext.Detach(objT);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(T t)
        {
            MyDbContext mdc = CreateContext();
            mdc.Set<T>().Add(t);
            return mdc.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(T t)
        {
            MyDbContext mdc = CreateContext();
            mdc.Set<T>().Attach(t);
            mdc.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return mdc.SaveChanges();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete(T t)
        {
            MyDbContext mdc = CreateContext();
            mdc.Set<T>().Attach(t);
            mdc.Entry(t).State = System.Data.Entity.EntityState.Deleted;
            return mdc.SaveChanges();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<T> Select()
        {
            MyDbContext mdc = CreateContext();
            return mdc.Set<T>().AsNoTracking().Select(e => e).ToList();
        }

    }
}
