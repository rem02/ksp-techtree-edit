using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ksp_techtree_edit.Converters
{
	internal class PosXToCanvasPointConverter : IValueConverter
	{
		public object Convert(
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return ((double)value + 3000) * 0.85;
		}

		public object ConvertBack(
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return Math.Round(((double)value / 0.85) - 3000, 2);
		}
	}

	internal class PosYToCanvasPointConverter : IValueConverter
	{
		public object Convert(
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return ((double)value * 0.7);
		}

		public object ConvertBack(
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return Math.Round((double)value / 0.7, 2);
		}
	}

	internal class PointToCanvasPointConverter : IValueConverter
	{
		public object Convert(
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return new Point
			       {
				       X = ((((Point)value).X + 3400) * 0.85),
				       Y = (((Point)value).Y * 0.7)
			       };
		}

		public object ConvertBack(
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return new Point
			       {
				       X = Math.Round((((Point)value).X / 0.85) - 3400, 2),
				       Y = Math.Round(((Point)value).Y / 0.7, 2)
			       };
		}
	}
}
