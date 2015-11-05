using ksp_techtree_edit.ViewModels;

namespace ksp_techtree_edit.Controls
{
	/// <summary>
	/// Interaction logic for SideBar.xaml
	/// </summary>
	public partial class SideBar
	{
		public SideBar()
		{
			InitializeComponent();
			var techTreeViewModel = DataContext as TechTreeViewModel;

			if (techTreeViewModel == null)
                return;

			NodePartsListBox.DataContext = techTreeViewModel;

            
            

		}
	}
}
