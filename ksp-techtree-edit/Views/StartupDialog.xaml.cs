using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using ksp_techtree_edit.Annotations;
using ksp_techtree_edit.Properties;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using ksp_techtree_edit.Models;

namespace ksp_techtree_edit.Views
{
	/// <summary>
	/// Interaction logic for StartupDialog.xaml
	/// </summary>
	public partial class StartupDialog : INotifyPropertyChanged
	{
		private bool _canLoad;

		public bool CanLoad
		{
			get { return _canLoad; }
			set
			{
				if (_canLoad == value) return;
				_canLoad = value;
				OnPropertyChanged();
			}
		 }

		public StartupDialog()
		{
			try
			{
				var kspDir = new DirectoryInfo(Settings.Default.KspPath);
				CanLoad = kspDir.Exists;
				Console.WriteLine(kspDir.FullName);
				Console.WriteLine(kspDir.Exists);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				CanLoad = false;
			}
			InitializeComponent();
		}

        /**
         * TODO check is ksp directory
         */
		private void SetKSPFolder(object sender, RoutedEventArgs e)
		{
			var dlg = new CommonOpenFileDialog { Title = "Select your KSP installation folder", IsFolderPicker = true };
			var result = dlg.ShowDialog();       
			if (result != CommonFileDialogResult.Ok)
                return;
			Settings.Default.KspPath = dlg.FileName;
			Settings.Default.Save();
			CanLoad = true;
		}

        private void Load(String title, TreeType type) {
            var mainWindow = Owner as MainWindow;
            if (mainWindow == null)
                return;
            var dlg = new OpenFileDialog
            {
                DefaultExt = ".cfg",
                Filter = "Tech Tree Config Files|*.cfg",
                Title = title,
            };
            var result = dlg.ShowDialog();
            if (result == false)
                return;
            CanLoad = false;
            try
            {
                mainWindow.LoadTree(dlg.FileName, type);
                mainWindow.FindParts(type);
                Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                CanLoad = true;
            }
        }

        private void LoadYongeTree(object sender, RoutedEventArgs e)
        {
            Load("Select TechMananger tree to load", TreeType.YongeTech);
        }


        /**
         * TODO check if exist stock.cfg 
         */
		private void NewStockTree(object sender, RoutedEventArgs e)
		{
			var mainWindow = Owner as MainWindow;
			if (mainWindow == null)
                return;
			CanLoad = false;
			try
			{
				mainWindow.LoadTree(Settings.Default.StockTreePath);
				mainWindow.FindParts();
				Close();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				CanLoad = true;
			}
		}

		private void NewBlankTree(object sender, RoutedEventArgs e)
		{
			var mainWindow = Owner as MainWindow;
			if (mainWindow == null)
                return;
			mainWindow.NewTree();
			mainWindow.FindParts();
			Close();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
