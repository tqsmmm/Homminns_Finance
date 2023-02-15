using System.Windows;

namespace 如家财务系统
{
    /// <summary>
    /// frmLogin.xaml 的交互逻辑
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string strSQL = "SELECT id FROM Users WHERE Code='" + tbCode.Text + "' AND Pwd='" + tbPwd.Password + "'";

            System.Data.DataSet Ds = DB_Work.DataSetCmd(strSQL, AppSetter.SqlConn);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
