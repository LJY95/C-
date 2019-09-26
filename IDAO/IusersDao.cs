using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
   public interface IusersDao
    {
        int UsersAdd(usersModel um);
        int UsersUpdate(usersModel um);
        int UsersDel(usersModel um);
        List<usersModel> UsersFind();
        List<usersModel> UsersSelectBy(int id);
        List<usersModel> UsersFenYe<K>(int currentPage, int PageSize, out int rows);
    }
}
