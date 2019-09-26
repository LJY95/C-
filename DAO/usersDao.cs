using EFEntity;
using IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAO
{
    public class usersDao : DaoBase<users>, IusersDao
    {
        public int UsersAdd(usersModel um)
        {
            users uu = new users
            {
              u_id=um.u_id,
              u_name=um.u_name,
              u_password=um.u_password,
              u_true_name=um.u_true_name,

            };
            return Add(uu);
        }

        public int UsersDel(usersModel um)
        {
            users uu = new users
            {
                u_id = um.u_id,
                u_name = um.u_name,
                u_password = um.u_password,
                u_true_name = um.u_true_name,
            };
            return Delete(uu);
        }

        public List<usersModel> UsersFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<usersModel> UsersFind()
        {
            List<users> list = Select();
            List<usersModel> umlist = new List<usersModel>();
            foreach (var item in umlist)
            {
                usersModel um = new usersModel()
                {
                    u_id = item.u_id,
                    u_name = item.u_name,
                    u_password = item.u_password,
                    u_true_name = item.u_true_name,
                };
                umlist.Add(um);
            }
            return umlist;
        }

        public List<usersModel> UsersSelectBy(int id)
        {
            MyDbContext mdc = CreateContext();
            List<users> list = mdc.users.AsNoTracking().Where(e => e.u_id == id).Select(e => e).ToList();
            List<usersModel> umlist = new List<usersModel>();
            foreach (var item in list)
            {
               usersModel um = new usersModel()
                {
                   u_id = item.u_id,
                   u_name = item.u_name,
                   u_password = item.u_password,
                   u_true_name = item.u_true_name,
               };
                umlist.Add(um);
            }
            return umlist;
        }

        public int UsersUpdate(usersModel um)
        {
            users uu = new users
            {
                u_id = um.u_id,
                u_name = um.u_name,
                u_password = um.u_password,
                u_true_name = um.u_true_name,
            };
            return Update(uu);
        }
    }
}
