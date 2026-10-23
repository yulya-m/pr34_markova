using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr34_Markova
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Point p1; //начало
		bool drawing = false;
		public MainWindow()
		{
			InitializeComponent();
			SelectionCanvas.MouseLeftButtonDown += SelDown;
			SelectionCanvas.MouseMove += SelMove;
			SelectionCanvas.MouseLeftButtonUp += SelUp;
		}

		private void SelUp(object sender, MouseButtonEventArgs e)
		{
			drawing = false;
		}

		private void SelMove(object sender, MouseEventArgs e)
		{
			if (drawing)
			{
				Point p2 = e.GetPosition(SelectionCanvas);
				//если тянем вправо-вниз
				if(p2.X > p1.X && p2.Y > p1.Y)
				{
					SelectionRect.Width = p2.X - p1.X;
					SelectionRect.Height = p2.Y - p1.Y;
				}
			}
		}

		private void SelDown(object sender, MouseButtonEventArgs e)
		{
			p1 = e.GetPosition(SelectionCanvas);
			drawing = true;
			SelectionRect.Visibility = Visibility.Visible;
			Canvas.SetLeft(SelectionRect, p1.X);
			Canvas.SetTop(SelectionRect, p1.Y);
			SelectionRect.Width = 0;
			SelectionRect.Height = 0;
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CropButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}