using System.Data.SqlClient;

namespace 如家财务系统
{
    internal class AppSetter
    {
        public static string strApplicationName = "如家财务管理系统";

        public static SqlConnection SqlConn = new SqlConnection(string.Format("Server={0},{1};Database={2};Uid={3};Pwd={4};Persist Security Info=True", "172.194.76.165", "1433", "HomeInns", "sa", "23long"));
    }
}
