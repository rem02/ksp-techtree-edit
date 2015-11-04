namespace ksp_techtree_edit.Views
{
	/// <summary>
	/// Interaction logic for HelpDialog.xaml
	/// </summary>
	public partial class HelpDialog
	{
        /**
         *Constructor
         */
		public HelpDialog()
		{
			InitializeComponent();
		}

        /**
         * Method for the hyperlink
         * Status: OK
         */
        private void HelpDialog_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
