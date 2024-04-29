using CarTask.Models;
using CarTask.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarTask.Views;

public partial class EditCarView : Window
{
	public EditCarView()
	{
		InitializeComponent();

		DataContext = new EditCarViewModel();
	}

}
