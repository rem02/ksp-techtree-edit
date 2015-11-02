using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ksp_techtree_edit.ViewModels;
using Xceed.Wpf.AvalonDock.Controls;

namespace ksp_techtree_edit.Controls
{
	/// <summary>
	/// Interaction logic for TechTreeDiagram.xaml
	/// </summary>
	public partial class TechTreeDiagram
	{
		#region Members

		private Vector _totalDelta = new Vector(0d, 0d);

		private int _nodeStickiness = 25;
		private int _snapDistance = 5;
		private readonly TechTreeViewModel _techTree;

		//TODO: Move this to ViewModel (Workspace?)
		public int NodeStickiness
		{
			get { return _nodeStickiness; }
			set { _nodeStickiness = value; }
		}

		//TODO: Move this to ViewModel (Workspace?)
		public int SnapDistance
		{
			get { return _snapDistance; }
			set { _snapDistance = value; }
		}

		#endregion Members

		#region Constructors

		public TechTreeDiagram()
		{
			InitializeComponent();
			_techTree = DataContext as TechTreeViewModel;
		}

		#endregion Constructors

		#region Methods

		private void TechNode_OnDragDelta(object sender, DragDeltaEventArgs e)
		{
			var nodeThumb = sender as Thumb;
			if (nodeThumb == null) return;
			var techNode = nodeThumb.DataContext as TechNodeViewModel;
			if (techNode == null) return;

			_totalDelta.X += e.HorizontalChange;
			_totalDelta.Y += e.VerticalChange;

			if (_totalDelta.Length < NodeStickiness) return;

			Mouse.OverrideCursor = Cursors.Hand;

			var x = Math.Round(
			                   (techNode.Pos.X + e.HorizontalChange) /
			                   SnapDistance) * SnapDistance;
			var y = Math.Round(
			                   (techNode.Pos.Y - e.VerticalChange) /
			                   SnapDistance) * SnapDistance;

			var newPos = new Point(x, y);
			techNode.Pos = newPos;
		}

		private void Thumb_OnDragCompleted(object sender, DragCompletedEventArgs e)
		{
			_totalDelta = new Vector(0d, 0d);
			Mouse.OverrideCursor = null;
		}

		private void Thumb_OnDragStarted(object sender, DragStartedEventArgs e)
		{
			var techtree = DataContext as TechTreeViewModel;
			if (techtree == null) return;
			var thumb = sender as Thumb;
			if (thumb == null) return;
			var node = thumb.DataContext as TechNodeViewModel;
			if (node == null) return;

			if (Keyboard.IsKeyDown(Key.LeftCtrl))
			{
				var selectedNode = techtree.WorkspaceViewModel.SelectedNode;
				if (selectedNode == node || selectedNode == null) return;

				if (selectedNode.Parents.Contains(node) || node.Parents.Contains(selectedNode))
				{
					node.RemoveParent(selectedNode);
					selectedNode.RemoveParent(node);
					techtree.LinkNodes();
				}
				else
				{
					node.AddParent(selectedNode);
					techtree.LinkNodes();
				}
				return;
			}

			if (techtree.WorkspaceViewModel.SelectedNode != null)
				techtree.WorkspaceViewModel.SelectedNode.IsSelected = false;
			node.IsSelected = true;

			techtree.WorkspaceViewModel.SelectedNode = node;
			techtree.WorkspaceViewModel.StatusBarText = node.NodeName +
			                                            " selected.";
		}

		#endregion Methods

		private void GridOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			var techtree = DataContext as TechTreeViewModel;
			if (techtree == null) return;

			if (!Keyboard.IsKeyDown(Key.LeftShift)) return;

			var grid = (Grid)sender;

			var canvas = grid.FindVisualChildren<Canvas>().First();

			var pos = e.MouseDevice.GetPosition(canvas);
			var x = Math.Round((pos.X / 0.85) - 3400, 2) + 20;
			var y = Math.Round(pos.Y / 0.7, 2) - 20;
			techtree.AddNode(new Point(x, y));
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			_techTree.WorkspaceViewModel.StatusBarText = e.GetPosition(this).ToString();
		}
	}
}
