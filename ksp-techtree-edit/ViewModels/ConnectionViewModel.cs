namespace ksp_techtree_edit.ViewModels
{
	public class ConnectionViewModel : NotificationViewModel
	{
		#region Members

		private TechNodeViewModel _startNodeViewModel;
		private TechNodeViewModel _endNodeViewModel;

		public TechNodeViewModel StartNodeViewModel
		{
			get { return _startNodeViewModel; }
			set
			{
				if (_startNodeViewModel == value) return;
				_startNodeViewModel = value;
				OnPropertyChanged();
			}
		}

		public TechNodeViewModel EndNodeViewModel
		{
			get { return _endNodeViewModel; }
			set
			{
				if (_endNodeViewModel == value) return;
				_endNodeViewModel = value;
				OnPropertyChanged();
			}
		}

		#endregion Members

		#region Constructors

		public ConnectionViewModel(TechNodeViewModel startNodeViewModel, TechNodeViewModel endNodeViewModel)
		{
			_startNodeViewModel = startNodeViewModel;
			_endNodeViewModel = endNodeViewModel;
		}

		#endregion Constructors
	}
}
