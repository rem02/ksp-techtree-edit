using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using KerbalParser;
using ksp_techtree_edit.Properties;
using ksp_techtree_edit.Util;
using ksp_techtree_edit.ViewModels;
using Microsoft.Win32;
using ksp_techtree_edit.Saver;
using ksp_techtree_edit.Models;

namespace ksp_techtree_edit.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private KerbalConfig _config;
		private TechTreeViewModel _treeData;

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
			sidebar.WorkspaceViewModel = workspaceViewModel;

			ContentGrid.DataContext = workspaceViewModel;
			DataContext = workspaceViewModel;
		}

        //OK
		public void NewTree()
		{
			ResetTree();
		}

        // OK
		public void LoadTree(string path, TreeType treeType = TreeType.YongeTech)
		{
			ResetTree();
			var nameNodeHashtable = new Dictionary<string, TechNodeViewModel>();
			if (_treeData == null)
			{
				return;
			}
			_config = ParseTree(path);
            // Here if you add a new treetype
			switch (treeType)
			{
                case TreeType.StockTechTree:

                    break;
                case TreeType.YongeTech:
                    LoadYongeTree(nameNodeHashtable);
                    break;
			}
			_treeData.LinkNodes();
			_treeData.WorkspaceViewModel.StatusBarText = "Tree Loaded";
		}

        private KerbalConfig ParseTree(string path)
        {
            var parser = new Parser();
            return parser.ParseConfig(path);
        }

        //OK
        private void LoadYongeTree(Dictionary<string, TechNodeViewModel> nameNodeHashtable)
        {
            var techNodes = _config.First(child => child.Name == "TechTree").Children.Where(node => node.Name == "RDNode").ToArray();

            foreach (KerbalNode node in techNodes.Where(kerbalNode => kerbalNode.Values.ContainsKey("nodepart"))) {
                var v = node.Values;
                var id = v["id"].First();
                TechNodeViewModel techNodeViewModel;
                if (nameNodeHashtable.ContainsKey(id))
                {
                    techNodeViewModel = nameNodeHashtable[id];
                }
                else
                {
                    techNodeViewModel = new TechNodeViewModel();
                    nameNodeHashtable.Add(id, techNodeViewModel);
                }
                techNodeViewModel.TechNode.PopulateFromSource(node);

                // Find parent
                foreach (KerbalNode parentNode in node.Children.Where(child => child.Name == "Parent"))
                {
                    var parentKeyValuePairs = parentNode.Values.Where(pair => pair.Key == "parentID");
                    var parents = new List<string>();
                    foreach (var parentKeyValuePair in parentKeyValuePairs)
                    {
                        parents.Add( parentKeyValuePair.Value.First() );
                    }
                    foreach (var parent in parents.Where(parent => !nameNodeHashtable.ContainsKey(parent)))
                    {
                        nameNodeHashtable.Add(parent, new TechNodeViewModel());
                    }
                    foreach (var parent in parents.Where(parent => !String.IsNullOrEmpty(parent) && nameNodeHashtable.ContainsKey(parent)))
                    {
                        techNodeViewModel.Parents.Add(nameNodeHashtable[parent]);
                    }
                }
                _treeData.TechTree.Add(techNodeViewModel);


            }
        }

        public void FindParts(TreeType type = TreeType.YongeTech)
        {
            var partCollectionViewModel = MainSideBar.PartsListBox.DataContext as PartCollectionViewModel;

            if (partCollectionViewModel == null)
                return;
            partCollectionViewModel.LoadParts(Settings.Default.KspPath);

            var sidebar = MainSideBar.DataContext as TechTreeViewModel;
            if (sidebar == null)
                return;
            sidebar.PartCollectionViewModel = partCollectionViewModel;
            _treeData.PartCollectionViewModel = partCollectionViewModel;
            foreach (var node in _treeData.TechTree)
            {
                node.PopulateParts(partCollectionViewModel, type);
            }
        }

        private void ResetTree()
		{
			_treeData.TechTree.Clear();
			_treeData.Connections.Clear();
			var partCollection = MainSideBar.PartsListBox.DataContext as PartCollectionViewModel;
			if (partCollection == null)
                return;
			partCollection.PartCollection.Clear();
		}

		private void LoadButtonClick(object sender, RoutedEventArgs e)
		{
			var dlg = new StartupDialog { Owner = this };
			dlg.ShowDialog();
		}

        //OK
        private void Save(TreeSaver saver)
        {
            var dlg = new SaveFileDialog
            {
                DefaultExt = ".cfg",
                Filter = "Tech Tree Config Files|*.cfg",
                Title = "Select where to save...",
                AddExtension = true,
            };
            var result = dlg.ShowDialog();
            if (result == false)
                return;
           // var saver = new TechManagerSaver();
            try
            {
                saver.Save(_treeData, dlg.FileName);
                //_treeData.Save(saver, dlg.FileName);
            }
            catch (Exception)
            {
                _treeData.WorkspaceViewModel.StatusBarText = "Failed saving to file..";
            }
        }

        //OK        
        private void SaveYongeTechClick(object sender, RoutedEventArgs e)
        {
            this.Save(new YongeTechSaver());
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
		{
			var dlg = new StartupDialog { Owner = this };
			dlg.ShowDialog();
		}

		private void DeleteOnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			_treeData.DeleteNode(_treeData.WorkspaceViewModel.SelectedNode);
		}

		private void DeleteOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = _treeData.WorkspaceViewModel.SelectedNode != null;
		}

		private void HelpClick(object sender, RoutedEventArgs e)
		{
			var dlg = new HelpDialog { Owner = this };
			dlg.ShowDialog();
		}

		private void OnClosed(object sender, EventArgs e)
		{
			Logger.Log("Application closed");
		}

        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
