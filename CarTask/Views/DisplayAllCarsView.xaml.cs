using CarTask.ViewModels;
using System.Windows;
using System.Windows.Media;

namespace CarTask.Views;

public partial class DisplayAllCarsView : Window
{
	public DisplayAllCarsView()
	{
		InitializeComponent();

		DataContext = new DisplayAllCarsViewModel();
	}
}
