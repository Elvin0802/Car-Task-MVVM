using CarTask.ViewModels;
using System.Windows;

namespace CarTask.Views;

public partial class AppCoreView : Window
{
	public AppCoreView()
	{
		InitializeComponent();
		DataContext = new AppCoreViewModel();
	}
}
