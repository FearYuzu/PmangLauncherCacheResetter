using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace PmangLauncherCacheResetter
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow :  Window
    {
        public static string CachePathOrigin;
        public static string CachePath;
        Confirm confirm = new Confirm();
        public MainWindow()
        {
            InitializeComponent();
            CachePathOrigin = gameInstallPath() + ".gameon\\";
            CachePath = CachePathOrigin.Replace("BlackDesert_live", "BlackDesert__live");
            ClientPath.Content = "キャッシュパス　:　" + CachePath;
            GetCacheName();
            Closed += new System.EventHandler(Closing);
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            confirm.Show();
            

        }
        private string gameInstallPath()
        {
            string keyName = string.Format("HKEY_CURRENT_USER\\SOFTWARE\\GameOn\\Pmang\\BlackDesert_live\\");
            return (string)Registry.GetValue(keyName, "location", "");
        }
        public void GetCacheName()
        {
            //MessageBox.Show("aaa");
            IEnumerable<string> files = Directory.EnumerateFiles(CachePathOrigin, "*", SearchOption.AllDirectories);
            foreach (string f in files)
            {
                confirm.CacheList.Items.Add(f);
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Closing(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
