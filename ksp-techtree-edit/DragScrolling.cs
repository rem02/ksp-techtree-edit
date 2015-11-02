using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ksp_techtree_edit
{
	public class DragScrolling : DependencyObject
	{
		public static bool GetIsEnabled(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsEnabledProperty);
		}

		public static void SetIsEnabled(DependencyObject obj, bool value)
		{
			obj.SetValue(IsEnabledProperty, value);
		}

		public bool IsEnabled
		{
			get { return (bool)GetValue(IsEnabledProperty); }
			set { SetValue(IsEnabledProperty, value); }
		}

		public static readonly DependencyProperty IsEnabledProperty =
			DependencyProperty.RegisterAttached(
			                                    "IsEnabled",
			                                    typeof (bool),
			                                    typeof (DragScrolling),
			                                    new UIPropertyMetadata(false, IsEnabledChanged));

		private static readonly Dictionary<object, MouseCapture> Captures = new Dictionary<object, MouseCapture>();

		private static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var target = d as ScrollViewer;
			if (target == null) return;

			if ((bool)e.NewValue)
			{
				target.Loaded += target_Loaded;
			}
			else
			{
				target_Unloaded(target, new RoutedEventArgs());
			}
		}

		private static void target_Unloaded(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Target Unloaded");

			var target = sender as ScrollViewer;
			if (target == null) return;

			Captures.Remove(sender);

			target.Loaded -= target_Loaded;
			target.Unloaded -= target_Unloaded;
			target.PreviewMouseLeftButtonDown -= target_PreviewMouseLeftButtonDown;
			target.PreviewMouseMove -= target_PreviewMouseMove;

			target.PreviewMouseLeftButtonUp -= target_PreviewMouseLeftButtonUp;
		}

		private static void target_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var target = sender as ScrollViewer;
			if (target == null) return;
			if (Mouse.DirectlyOver as Canvas == null) return;

			Captures[sender] = new MouseCapture
			                   {
				                   VerticalOffset = target.VerticalOffset,
				                   HorizontalOffset = target.HorizontalOffset,
				                   Point = e.GetPosition(target),
			                   };
		}

		private static void target_Loaded(object sender, RoutedEventArgs e)
		{
			var target = sender as ScrollViewer;
			if (target == null) return;

			System.Diagnostics.Debug.WriteLine("Target Loaded");

			target.Unloaded += target_Unloaded;
			target.PreviewMouseLeftButtonDown += target_PreviewMouseLeftButtonDown;
			target.PreviewMouseMove += target_PreviewMouseMove;

			target.PreviewMouseLeftButtonUp += target_PreviewMouseLeftButtonUp;
		}

		private static void target_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			var target = sender as ScrollViewer;
			if (target == null) return;

			target.ReleaseMouseCapture();
		}

		private static void target_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (!Captures.ContainsKey(sender)) return;

			if (e.LeftButton != MouseButtonState.Pressed)
			{
				Captures.Remove(sender);
				return;
			}

			var target = sender as ScrollViewer;
			if (target == null) return;

			var capture = Captures[sender];

			var point = e.GetPosition(target);

			var dx = point.X - capture.Point.X;
			var dy = point.Y - capture.Point.Y;
			if (Math.Abs(dy) > 5 && Math.Abs(dx) > 5)
			{
				target.CaptureMouse();
			}

			target.ScrollToVerticalOffset(capture.VerticalOffset - dy);
			target.ScrollToHorizontalOffset(capture.HorizontalOffset - dx);
		}

		internal class MouseCapture
		{
			public Double VerticalOffset { get; set; }
			public Double HorizontalOffset { get; set; }
			public Point Point { get; set; }
		}
	}
}
