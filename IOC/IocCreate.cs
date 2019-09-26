using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;

namespace IOC
{
    public class IocCreate
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static UnityContainer CreateObject(string name)
        {
            //产生容器
            UnityContainer uc = new UnityContainer();
            //把配置文件转换成文件对象
            ExeConfigurationFileMap ef = new ExeConfigurationFileMap();
            ef.ExeConfigFilename = @"D:\毕业项目\HRS\HRS\Unity.config";
            //将文件对象转换成配置对象             OpenMappedExeConfiguration：  指定客户端配置文件作为使用指定文件映射和用户级别的Configuration对象打开
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);
            //读取Unity配置文件的节点(业务逻辑层)
            UnityConfigurationSection cs = cf.GetSection("unity") as UnityConfigurationSection;
            //从容器里加载业务逻辑层的配置块
            uc.LoadConfiguration(cs, name);
            return uc;
        }
        /// <summary>
        /// 产生DAL对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typedal"></param>
        /// <returns></returns>
        public static T CreateDAL<T>(string typedal)
        {
            //在容器中添加子节点
            UnityContainer uc = CreateObject("containerOne");
            //定位配置文件中的节点
            T dal = uc.Resolve<T>(typedal);
            //返回创建好的DAL对象
            return dal;
        }
        /// <summary>
        /// 产生BLL对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typebll"></param>
        /// <returns></returns>
        public static T CreateBLL<T>(string typebll)
        {
            //在容器中添加子节点
            UnityContainer uc = CreateObject("containerTwo");
            //定位配置文件中的节点
            T bll = uc.Resolve<T>(typebll);
            //返回创建好的DAL对象
            return bll;
        }
    }
}
