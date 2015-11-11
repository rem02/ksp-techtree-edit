using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using KerbalParser;
using ksp_techtree_edit.Properties;
using ksp_techtree_edit.Util;
using ksp_techtree_edit.ViewModels;
using Microsoft.Win32;
using ksp_techtree_edit.Saver;
using ksp_techtree_edit.Models;
using ksp_techtree_edit.Loader;


namespace ksp_techtree_edit.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
        // KerblaParser object.
		private KerbalConfig _config;

		private TechTreeViewModel _treeData;

        // Loader of cfg file
        private TreeLoader _treeLoader = null;

        /**
         * Constructor
         */
		public MainWindow()
		{
			InitializeComponent();
			_treeData = TechTreeDiagram.TechTreeGrid.DataContext as TechTreeViewModel;

			if (_treeData == null)
                return;
			var workspaceViewModel = new WorkspaceViewModel();
			_treeData.WorkspaceViewModel = workspaceViewModel;

			var sidebar = MainSideBar.DataContext as TechTreeViewModel;
			if (sidebar == null)
                return;

            DataContext = workspaceViewModel;
            ContentGrid.DataContext = workspaceViewModel;
            sidebar.WorkspaceViewModel = workspaceViewModel;

        }

        /**
         * Method for create a new TechTree
         * Status: OK
         */
		public void NewTree()
		{
			ResetTree();
		}

        /**
         * Method for load tree
         * Status: OK
         * Note: if you add a new treeLoader, update the switch...
         */
        public void LoadTree(string path, TreeType treeType = TreeType.StockTechTree) 
		{
			ResetTree();

			if (_treeData == null)
			{
				return;
			}
            var parser = new Parser();
            _config = parser.ParseConfig(path);
			switch (treeType)
			{
                case TreeType.StockTechTree:
                    _treeLoader = new StockTechTreeLoader();                    
                    break;
                case TreeType.YongeTech:
                    _treeLoader = new YongeTechTreeLoader();
                    break;
                default:
                    throw new Exception("The techtree's file format is not reconized !");

			}
            _treeLoader.LoadTree(_config, _treeData);
			_treeData.LinkNodes();
			_treeData.WorkspaceViewModel.StatusBarText = "Tree Loaded";
		}

        /**
         * Method for initialize de partCollectionModelView
         * Status: OK
         */
        public void FindParts()
        {
            var partCollectionViewModel = PartsListBox.DataContext as PartCollectionViewModel;
            if (partCollectionViewModel == null)
                return;
            // Load squad parts
            partCollectionViewModel.LoadParts(Settings.Default.KspPath+ Path.DirectorySeparatorChar +"GameData");

            var sidebar = MainSideBar.DataContext as TechTreeViewModel;
            if (sidebar == null)
                return;
            sidebar.PartCollectionViewModel = partCollectionViewModel;

            _treeData.PartCollectionViewModel = partCollectionViewModel;

           if( _treeLoader != null)
                _treeLoader.PopulateParts(partCollectionViewModel, _treeData);

            PartsListBox.AddPartButton.DataContext = _treeData;
        }

        /**
         * Method for reset a techtree
         * Status: OK
         */
        private void ResetTree()
		{
			_treeData.TechTree.Clear();
			_treeData.Connections.Clear();
			var partCollection = PartsListBox.DataContext as PartCollectionViewModel;
			if (partCollection == null)
                return;
			partCollection.PartCollection.Clear();
		}

        /**
         * Method for show the startup dialog
         * Status: OK
         */
		private void MainWindow_LoadButtonClick(object sender, RoutedEventArgs e)
		{
			var dlg = new StartupDialog { Owner = this };
			dlg.ShowDialog();
		}

        /**
         * Method for show the save dialog and the techtree
         * Status: OK
         */
        private void Save(TreeSaver treesaver)
        {
            var dlg = new SaveFileDialog
            {
                DefaultExt = ".cfg",
                Filter = "Tech Tree Config Files|*.cfg",
                Title = "Select where to save...",
                AddExtension = true,
            };
            var result = dlg.ShowDialog();
            if (result==true) { 
                try
                {
                    treesaver.Save(_treeData, dlg.FileName);
                    _treeData.WorkspaceViewModel.StatusBarText = "saving to file... done";
                }
                catch (Exception)
                {
                    _treeData.WorkspaceViewModel.StatusBarText = "Failed saving to file..";
                }
            } 
        }

        /**
         * Method for save the techtree in Stock format
         * Status: OK
         */
        private void MainWindow_SaveStockTechClick(object sender, RoutedEventArgs e)
        {
            this.Save(new StockTreeSaver());
        }

        /**
         * Method for save the techtree in Stock YongeTech
         * Status: OK
         */
        private void MainWindow_SaveYongeTechClick(object sender, RoutedEventArgs e)
        {
            this.Save(new YongeTechSaver());
        }

        /**
         * Method for OnLoaded event
         * Status: OK
         */
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			var dlg = new StartupDialog { Owner = this };
			dlg.ShowDialog();
		}

        /**
         * Method for OnClosed event
         * Status: OK
         */
        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Logger.Log("Application closed");
        }

        /**
         * Method for KeyBinding delete command
         * Status: OK
         */
        private void MainWindow_DeleteOnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			_treeData.DeleteNode(_treeData.WorkspaceViewModel.SelectedNode);
		}

        /**
         * Method for KeyBinding delete command
         * Status: OK
         */
        private void MainWindow_DeleteOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = _treeData.WorkspaceViewModel.SelectedNode != null;
		}

        /**
         * Method for show the helpdialog
         * Status: OK        
         */
        private void MainWindow_HelpClick(object sender, RoutedEventArgs e)
		{
			var dlg = new HelpDialog { Owner = this };
			dlg.ShowDialog();
		}

        private void MainWindow_AddPartClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
