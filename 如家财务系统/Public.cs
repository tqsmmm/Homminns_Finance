using System;
using System.Windows;
using IWshRuntimeLibrary;

namespace 如家财务系统
{
    internal class Public
    {
        public static void Sys_MsgBox(string strMsg)
        {
            MessageBox.Show(strMsg, AppSetter.strApplicationName, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static bool Sys_MsgYN(string strMsg)
        {
            if (MessageBox.Show(strMsg, AppSetter.strApplicationName, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CreateDesktopLink(bool Created)
        {
            if (Created == true)
            {
                if (!System.IO.File.Exists(string.Format("{0}//{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), AppSetter.strApplicationName)))
                {
                    var shell = new WshShell();
                    var shortcut = (IWshShortcut)shell.CreateShortcut(
                        string.Format("{0}//{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), AppSetter.strApplicationName)
                        );
                    shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    shortcut.WorkingDirectory = Environment.CurrentDirectory;
                    shortcut.WindowStyle = 1;
                    shortcut.Description = "龙岩科技软件";
                    shortcut.Save();
                }
            }
            else
            {
                if (System.IO.File.Exists(string.Format("{0}//{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), AppSetter.strApplicationName)))
                {
                    System.IO.File.Delete(string.Format("{0}//{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), AppSetter.strApplicationName));
                }
            }
        }
    }
}
