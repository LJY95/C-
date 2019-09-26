using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using IOC;

namespace BLL
{
    public class usersBLL : IusersBLL
    {
        IusersDao udao = IocCreate.CreateDAL<IusersDao>("usersDao");
        public int UsersAdd(usersModel um)
        {
            return udao.UsersAdd(um);
        }

        public int UsersDel(usersModel um)
        {
            return udao.UsersDel(um);
        }

        public List<usersModel> UsersFenYe<K>(int currentPage, int PageSize, out int rows)
        {
            throw new NotImplementedException();
        }

        public List<usersModel> UsersFind()
        {
            return udao.UsersFind();
        }

        public List<usersModel> UsersSelectBy(int id)
        {
            return udao.UsersSelectBy(id);
        }

        public int UsersUpdate(usersModel um)
        {
            return udao.UsersUpdate(um);
        }
    }
}
