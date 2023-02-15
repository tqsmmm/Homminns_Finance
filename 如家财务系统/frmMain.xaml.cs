using System;
using System.Windows;
using System.Data;

namespace 如家财务系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string strSQL = string.Format("INSERT INTO Invoices(Code,No,Name,Amount,Receiver,DateTime,Writer) VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}')", tbCode.Text, tbNo.Text, cmbName.Text, tbAmount.Text, cmbReceiver.Text, dpDateTime.Text, tbWriter.Text);

            if (DB_Work.ExecuteCmd(strSQL, AppSetter.SqlConn))
            {
                Public.Sys_MsgBox("添加成功！");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            string strSQL = string.Format("SELECT id AS [序号],Code AS [代码],No AS [流水号],Name AS [付款单位],Amount AS [金额],Receiver AS [收款人],DateTime AS [时间],Writer AS [开票人] FROM [Invoices] WHERE CONVERT(VARCHAR(10),DateTime,120)>='{0:yyyy-MM-dd}' AND CONVERT(VARCHAR(10),DateTime,120)<='{1:yyyy-MM-dd}' ORDER BY id", Convert.ToDateTime(dpFrom.Text), Convert.ToDateTime(dpTo.Text));

            DataSet Ds = DB_Work.DataSetCmd(strSQL, AppSetter.SqlConn);
            dgList.ItemsSource = Ds.Tables[0].DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = AppSetter.strApplicationName;

            dpDateTime.Text = DateTime.Now.ToString();

            dpFrom.Text = DateTime.Now.ToString();
            dpTo.Text = DateTime.Now.ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string strSQL = "DELETE FROM Invoices WHERE id=" + ((DataRowView)dgList.SelectedItem)[0];

            if (DB_Work.ExecuteCmd(strSQL, AppSetter.SqlConn))
            {
                Public.Sys_MsgBox("删除成功！");

                btnList_Click(null, null);
            }
        }
    }
}
