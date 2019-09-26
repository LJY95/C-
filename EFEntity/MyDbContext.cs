using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
   public class MyDbContext:DbContext
    {
        public MyDbContext() {
            //若数据库表稳定，则无需删除建表
            Database.SetInitializer<MyDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //加载EO中对应的实体配置类
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<users> users { get;set; } 
    }
}
