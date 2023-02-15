using System.Windows;

namespace 如家财务系统
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            frmLogin frm = new frmLogin();
            frm.ShowDialog();

            if (frm.DialogResult.Value && frm.DialogResult.HasValue)
            {
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            else
            {
                Shutdown();
            }

        }
    }
}
