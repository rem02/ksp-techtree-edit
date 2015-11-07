using System.Windows;
using ksp_techtree_edit.ViewModels;

namespace ksp_techtree_edit.Controls
{
    /// <summary>
    /// Logique d'interaction pour MyPartCatalog.xaml
    /// </summary>
    public partial class MyPartCatalog
    {
        public MyPartCatalog()
        {
            InitializeComponent();
        }

        private void AddPartClick(object sender, RoutedEventArgs e)
        {
            var techTreeViewModel = AddPartButton.DataContext as TechTreeViewModel;
            if (techTreeViewModel == null)
                return;

            var selectedNode = techTreeViewModel.WorkspaceViewModel.SelectedNode;
            if (selectedNode == null)
                return;

            var part = PartsList.SelectedItem as PartViewModel;
            if (part == null)
                return;

            techTreeViewModel.PartCollectionViewModel.AddPartToNode(part, selectedNode);
        }
    }
}
