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
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;

namespace PmangLauncherCacheResetter
{
    /// <summary>
    /// Confirm.xaml の相互作用ロジック
    /// </summary>
    public partial class Confirm : Window
    {
        public Confirm()
        {
            InitializeComponent();
        }

        private void StartCacheDelete_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            string[] AllCache = Directory.GetFiles(MainWindow.CachePathOrigin);
            foreach (string cachefile in AllCache)
            {
                File.SetAttributes(cachefile, FileAttributes.Normal);
                File.Delete(cachefile);
            }
            MessageBox.Show("正常にキャッシュファイルを削除しました。", "削除完了", MessageBoxButton.OK, MessageBoxImage.Information);
            GetCacheName();
            
        }

        private void DeleteSetectedCache_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            try
            {
                File.Delete(CacheList.SelectedItem.ToString());
                MessageBox.Show("正常にキャッシュファイルを削除しました。", "削除完了", MessageBoxButton.OK, MessageBoxImage.Information);
                
                GetCacheName();
                
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("キャッシュファイルが指定されていません。", "未指定", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                GetCacheName();
            }
            
        }

        private void ListUpdate_Click(object sender, RoutedEventArgs e)
        {
            GetCacheName();
            
        }
        public void GetCacheName()
        {
            CacheList.Items.Clear();
            IEnumerable<string> files = Directory.EnumerateFiles(MainWindow.CachePathOrigin, "*", SearchOption.AllDirectories);
            foreach (string f in files)
            {
                CacheList.Items.Add(f);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
    
}
