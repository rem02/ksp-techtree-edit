using System.Windows;
using ksp_techtree_edit.ViewModels;

namespace ksp_techtree_edit.Controls
{
	/// <summary>
	/// Interaction logic for NodePartsList.xaml
	/// </summary>
	public partial class NodePartsList
	{
		public NodePartsList()
		{
			InitializeComponent();
		}

		private void RemovePartClick(object sender, RoutedEventArgs e)
		{
			var part = PartsListBox.SelectedItem as PartViewModel;
			if (part == null) return;

			var techTree = DataContext as TechTreeViewModel;
			if (techTree == null) return;

			var node = techTree.WorkspaceViewModel.SelectedNode;

			techTree.PartCollectionViewModel.RemovePartFromNode(part, node);
		}
	}
}
