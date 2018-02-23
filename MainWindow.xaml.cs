using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using COB_Manager.Common;
using System.IO;



namespace COB_Manager
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        //FileSystemWatcher object
        public static FileSystemWatcher watcher = new FileSystemWatcher();
        public static DateTime dt;
        private ModelInfo CurrModel;
        public MainWindow()
        {
            InitializeComponent();
            InitEvent();
        }
        //sungho.kang file IO added code 02.22-------------------------------------------------------------------------------------------------------------

        private void InitEvent()
        {
            this.btnFileOpen.Click += BtnFileOpen_Click;

        }


        private void BtnFileOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "csv Files (*.csv)|*.csv";
            dlg.InitialDirectory = "d:\\Mapdata";



            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string path = dlg.FileName;
                CurrModel = new ModelInfo(path, true);
                if (CurrModel.IsEdit()) lblEdit.Content = "편집 필요";
                else lblEdit.Content = "편집 불필요";
                grdModelInfo.DataContext = CurrModel;
            }


        }

        private void btnFileOpen_Click_1(object sender, RoutedEventArgs e)
        {

        }

        //Created event에 대한 FileSystemEventHandler를 추가해서, 이 때 받게 되는
        //FileSystemEventArgs.FullPath로 새롭게 추가된 CSV file의 full path


        public static void OnCreated(object source, FileSystemEventArgs e)
        {
  
        }

        private void Auto_Open_ClickFile(object sender, RoutedEventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            string[] filters = new[] { "*.csv", "*CSV" };
            string[] filePaths = filters.SelectMany(f => Directory.GetFiles("d:\\Mapdata", f)).ToArray();

            watcher.Path = @"d:\\Mapdata";
            watcher.NotifyFilter = NotifyFilters.LastAccess |
                                   NotifyFilters.LastWrite |
                                   NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName;

            watcher.Filter = "csv Files (*.csv)|*.csv";
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.EnableRaisingEvents = true;
        


            Nullable<bool> result = watcher.EnableRaisingEvents;
            if (result == true)
            {
                string path = watcher.Path;
                CurrModel = new ModelInfo(path, true);
                if (CurrModel.IsEdit()) lblEdit.Content = "편집 필요";
                else lblEdit.Content = "편집 불필요";
                grdModelInfo.DataContext = CurrModel;
            }


        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {

        }
    }
}
